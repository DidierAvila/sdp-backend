using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDP.Domain.Entities
{
    [Table(name: "Shippers", Schema = "Sales")]
    public class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Shipperid { get; set; }
        public string Companyname { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
