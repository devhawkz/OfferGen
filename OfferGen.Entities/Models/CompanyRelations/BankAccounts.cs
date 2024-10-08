using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace OfferGen.Entities.Models.CompanyRelations;

public record class BankAccountDetails
{
    [Required(ErrorMessage = "Bank name is required", AllowEmptyStrings = false)]
    public string Name { get; init; } = string.Empty;

    [Required(ErrorMessage = "Bank account number is requied", AllowEmptyStrings = false), CreditCard]
    public string AccountNumber { get; init; } = string.Empty;

    [MaxLength(50)]
    public string Description { get; init; } = string.Empty;
}
public class BankAccounts
{
    [Key, Column("BankAccountId")]
    public Guid Id { get; set; }
    public BankAccountDetails AccountDetails { get; }

    // relation N:1 with Company
    [ForeignKey(nameof(CompanyId))]
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public BankAccounts()
    {
        
    }

    public BankAccounts(BankAccountDetails accountDetails, Guid companyId)
    {
        AccountDetails = accountDetails;
        CompanyId = companyId;
    }
}