namespace SDP.Domain.Dtos
{
    public class CreateOrderDetailDto
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
