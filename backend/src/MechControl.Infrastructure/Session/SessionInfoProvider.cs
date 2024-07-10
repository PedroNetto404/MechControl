using MechControl.Application.Interfaces;
using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Features.MechShops;
using Microsoft.AspNetCore.Http;

namespace MechControl.Infrastructure.Session;

public sealed class SessionInfoProvider(
    IHttpContextAccessor httpContextAccessor
) : ICurrentMechShopProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    public MechShopId GetCurrentId()
    {
        var context = _httpContextAccessor.HttpContext;
        if(context.User is not { Identity.IsAuthenticated: true } user)
            throw new InvalidOperationException("User is not authenticated");

        var mechShopId = context.User.Claims
            .FirstOrDefault(claim => claim.Type == "MechShopId")?.Value;

        if(!Guid.TryParse(mechShopId, out var id))
            throw new InvalidOperationException("MechShopId is not a valid GUID");

        return StrongId.From<MechShopId>(id);
    }
}