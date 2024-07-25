using System.ComponentModel.DataAnnotations;

namespace MechControl.Api.Controllers.Customer;

public record CreateCustomerRequest(
    [Required, MaxLength(100)]
    string Name,
    [Required, MaxLength(14)]
    string Phone,
    [Required, MaxLength(100)]
    string Email,
    [Required, MaxLength(14)]
    [AllowedValues("individual", "corporate")]
    string Type,
    [Required, MaxLength(14)]
    string Document,
    DateTime? BirthDate,
    [Required]
    string AddressStreet,
    [Required]
    string AddressNumber,
    [Required]
    string AddressNeighborhood,
    [Required]
    string AddressCity,
    [Required]
    string AddressStateCode,
    [Required]
    string AddressCountryCode,
    [Required]
    string AddressZipCode,
    string? AddressComplement,
    string? AddressReference,
    bool? IsMei
);
