using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDP.Domain.Entities
{
    [Table(name: "Products", Schema = "Production")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Productid { get; set; }
        public string Productname { get; set; } = string.Empty;
        public int Supplierid { get; set; }
        public int Categoryid { get; set; }
        public decimal Unitprice { get; set; }
        public byte Discontinued { get; set; }
    }
}
