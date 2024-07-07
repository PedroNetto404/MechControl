using MechControl.Domain.Core.Abstractions;
using MechControl.Domain.Core.Primitives;

namespace MechControl.Domain.Features.MechShops;

public sealed class MechShopId : StrongId
{
    private MechShopId(Guid value) : base(value)
    {
    }
}