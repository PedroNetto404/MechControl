using System.Reflection;
using MechControl.Api.Hooks.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace MechControl.Api.Hooks.Binders;
public class FromSessionBinder : IModelBinder
{
	public Task BindModelAsync(ModelBindingContext bindingContext)
	{
		ArgumentNullException.ThrowIfNull(bindingContext, nameof(bindingContext));

		var user = bindingContext.HttpContext.User;
		ArgumentNullException.ThrowIfNull(user, nameof(user));

		if (
			bindingContext is not
			{
				ModelMetadata.BinderType: Type binderType,
			}
		)
		{
			bindingContext.Result = ModelBindingResult.Failed();
			return Task.CompletedTask;
		}

		var claimType = binderType.GetCustomAttribute<FromSessionAttribute>()?.ClaimType;

		if (user!.Identity!.IsAuthenticated)
		{
			bindingContext.Result = ModelBindingResult.Failed();
			return Task.CompletedTask;
		}

		var claim = user!.Claims.FirstOrDefault(c => c.Type == claimType);
		if (claim is null || !Guid.TryParse(claim.Value, out var value))
		{
			bindingContext.Result = ModelBindingResult.Failed();
			return Task.CompletedTask;
		}

		bindingContext.Result = ModelBindingResult.Success(value);
		return Task.CompletedTask;
	}

	public class Provider : IModelBinderProvider
	{
		public IModelBinder GetBinder(ModelBinderProviderContext context)
		{
			ArgumentNullException.ThrowIfNull(context, nameof(context));

			if (
				context.Metadata.ModelType == typeof(Guid) &&
				context.BindingInfo.BindingSource == FromSessionAttribute.Source
			) return new BinderTypeModelBinder(typeof(FromSessionBinder));

			return null!;
		}
	}
}

