using System.ComponentModel.DataAnnotations;
using MechControl.Application.Features.Customers.Commands.CreateCustomer;
using MechControl.Domain.Shared.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace MechControl.Api.Controllers.Customer;

public partial class CustomerController
{
 
  [HttpPost]
  public Task<IActionResult> CreateAsync([FromBody]CreateCustomerRequest request) =>
    HandleResultAsync(_sender.Send(new CreateCustomerCommand(
        request.Name,
        request.Document,
        request.Email,
        request.Phone,
        request.DocumentType,
        request.BirthDate is not null ? 
          DateOnly.FromDateTime(request.BirthDate.Value) :
          null,
        request.AddressStreet,
        request.AddressNumber,
        request.AddressNeighborhood,
        request.AddressCity,
        request.AddressStateCode,
        request.AddressCountryCode,
        request.AddressZipCode,
        request.AddressComplement,
        request.AddressReference,
        request.IsMei
      )));

       public record CreateCustomerRequest(
    [Required, MaxLength(100)] string Name,
    [Required, MaxLength(14)] string Phone,
    [Required, MaxLength(100)] string Email,
    [Required, MaxLength(14), AllowedValues(nameof(Cpf), nameof(Cnpj))] string DocumentType,
    [Required, MaxLength(14)] string Document,
    DateTime? BirthDate,
    [Required] string AddressStreet,
    [Required] string AddressNumber,
    [Required] string AddressNeighborhood,
    [Required] string AddressCity,
    [Required] string AddressStateCode,
    [Required] string AddressCountryCode,
    [Required] string AddressZipCode,
    string? AddressComplement,
    string? AddressReference,
    bool? IsMei
);

}
