using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDP.Domain.Entities
{
    [Table(name: "Customers", Schema = "Sales")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Custid { get; set; }
        public string Companyname { get; set; } = string.Empty;
        public string Contactname { get; set; } = string.Empty;
        public string Contacttitle { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Postalcode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
    }
}
