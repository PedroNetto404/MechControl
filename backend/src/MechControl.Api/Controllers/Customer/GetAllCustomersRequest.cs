using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

public sealed record GetAllCustomersRequest(
	[property: Required, DefaultValue(0), FromQuery(Name = "offset")] int Offset,
	[property: Required, DefaultValue(10), FromQuery(Name = "fetch")] int Fetch,
	[property: AllowedValues("individual", "corporate"), FromQuery(Name = "customer_type")] string? CustomerType
);
