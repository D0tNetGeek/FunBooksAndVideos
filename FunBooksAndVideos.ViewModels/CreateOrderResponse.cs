namespace FunBooksAndVideos.ViewModels
{
    public class CreateOrderResponse
    {
        public string OrderId { get; set; }
        public bool IsMembershipSubscribed { get; set; }
        public bool IsProductPurchased { get; set; }
    }
}
