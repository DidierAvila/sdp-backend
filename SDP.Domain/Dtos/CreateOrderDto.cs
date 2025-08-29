namespace SDP.Domain.Dtos
{
    public class CreateOrderDto
    {
        public int CustId { get; set; }
        public int EmpId { get; set; }
        public DateTime RequiredDate { get; set; }
        public int ShipperId { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; } = string.Empty;
        public string ShipAddress { get; set; } = string.Empty;
        public string ShipCity { get; set; } = string.Empty;
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string ShipCountry { get; set; } = string.Empty;
    }
}
