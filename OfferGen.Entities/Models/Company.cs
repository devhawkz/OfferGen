using OfferGen.Entities.Models.CompanyRelations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfferGen.Entities.Models;

public record class Email
{
    [Required(ErrorMessage = "Email is Required", AllowEmptyStrings = false), EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;
}
public record class Address
{
    [Required(ErrorMessage = "Street is Required", AllowEmptyStrings = false)]
    public string Street { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is Required", AllowEmptyStrings = false)]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "ZIP Code is Required", AllowEmptyStrings = false), DataType(DataType.PostalCode)]
    public string ZIPCode { get; set; } = string.Empty;
}

public class Company
{
    [Key, Column("CompanyId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name of the company is required", AllowEmptyStrings = false)]
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; }
    public Email Email { get; set; }

    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Url]
    public string Website { get; set; } = string.Empty;
    [Required(ErrorMessage = "TaxIdentifier of the company is required", AllowEmptyStrings = false)]
    public string TaxIdentifier { get; set; } = string.Empty;

    [Required(ErrorMessage = "RegistrationNumber of the company is required", AllowEmptyStrings = false)]
    public string RegistrationNumber {  get; set; } = string.Empty;

    // relation 1:N with BankAccounts
    public HashSet<BankAccounts> Accounts { get; set; } = new HashSet<BankAccounts>();

    public Company(Email email, Address address)
    {
        Email = email;
        Address = address;
    }
}
