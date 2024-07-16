using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MechControl.Api.Controllers.Customer;

public sealed record GetAllCustomersRequest(
	[property: Required, DefaultValue(0)] int Offset,
	[property: Required, DefaultValue(10)] int Fetch,
	[property: AllowedValues("individual", "corporate")] string? CustomerType
);
