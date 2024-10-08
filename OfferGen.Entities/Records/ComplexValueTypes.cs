using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferGen.Entities.Records;

public class ComplexValueTypes
{
    public record class ContactInfo
    {
        [Required(ErrorMessage = "Email is Required", AllowEmptyStrings = false), EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;
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
}
