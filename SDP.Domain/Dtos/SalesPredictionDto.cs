namespace SDP.Domain.Dtos
{
    public class SalesPredictionDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
