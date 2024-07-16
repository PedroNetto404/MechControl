using MechControl.Domain.Features.MechShops;

namespace MechControl.Application.Interfaces;

public interface ICurrentMechShopProvider
{
    MechShopId Current { get; }
}
