using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDP.Domain.Entities
{
    [Table(name: "Orders", Schema = "Sales")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Orderid { get; set; }
        public int Custid { get; set; }
        public int Empid { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime Shippeddate { get; set; }
        public int Shipperid { get; set; }
        public decimal freight { get; set; }
        public string Shipname { get; set; } = string.Empty;
        public string Shipaddress { get; set; } = string.Empty;
        public string Shipcity { get; set; } = string.Empty;
        public string Shipregion { get; set; } = string.Empty;
        public string Shippostalcode { get; set; } = string.Empty;
        public string Shipcountry { get; set; } = string.Empty;
    }
}
