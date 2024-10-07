using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfferGen.Entities.Models.CompanyRelations;

public class OfferHeader
{
    [Key, Column("OfferHeaderId")]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string HeaderCaption { get; set; } = string.Empty;

    public string? CompanyLogo { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

}
