using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using static OfferGen.Entities.Records.ComplexValueTypes;

namespace OfferGen.Entities.Models;

public class Clients
{
    [Key, Column("ClientId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage ="Company name is required", AllowEmptyStrings =false)]
    public string CompanyName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Tax Identifier is required",AllowEmptyStrings =false)]
    public string TaxIdentifier { get; init; } = string.Empty;

    [Required(ErrorMessage = "Registration Number is required", AllowEmptyStrings = false)] 
    public string RegistrationNumber { get; init; } = string.Empty;
    public Address ClientAddress { get; set; } 

    public ContactInfo ClientContactInfo { get; set; }

    public Clients()
    {
        
    }

    public Clients(Address clientAddress, ContactInfo clientContactInfo)
    {
        ClientAddress = clientAddress;
        ClientContactInfo = clientContactInfo;
    }

}
