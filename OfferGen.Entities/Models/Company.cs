using OfferGen.Entities.Models.CompanyRelations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OfferGen.Entities.Records.ComplexValueTypes;

namespace OfferGen.Entities.Models;

public class Company
{
    [Key, Column("CompanyId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name of the company is required", AllowEmptyStrings = false)]
    public string Name { get; set; } = string.Empty;
    public Address CompanyAddress { get; set; }
    public ContactInfo CompanyContactInfo { get; set; }

    [Url]
    public string Website { get; set; } = string.Empty;
    [Required(ErrorMessage = "TaxIdentifier of the company is required", AllowEmptyStrings = false)]
    public string TaxIdentifier { get; set; } = string.Empty;

    [Required(ErrorMessage = "RegistrationNumber of the company is required", AllowEmptyStrings = false)]
    public string RegistrationNumber {  get; set; } = string.Empty;

    // relation 1:N with BankAccounts
    public HashSet<BankAccounts> Accounts { get; set; } = new HashSet<BankAccounts>();
    
    // relation 1:1 with OfferHeader
    public OfferHeader OfferHeader { get; set; }
    public Company()
    {
        
    }

    public Company(ContactInfo contactInfo, Address address)
    {
        CompanyContactInfo = contactInfo;
        CompanyAddress = address;
    }
}
