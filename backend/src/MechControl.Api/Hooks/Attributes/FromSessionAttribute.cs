using MechControl.Api.Hooks.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MechControl.Api.Hooks.Attributes;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
public class FromSessionAttribute(string claimType) : Attribute, IBindingSourceMetadata
{
    public string ClaimType { get; } = claimType;

    public BindingSource BindingSource => BindingSource;
	
	public static readonly BindingSource Source = new(
		"FromSession",
		"From Session",
		isGreedy: false,
		isFromRequest: true
	);
}