namespace WebAPI.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime DeliveryDate { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
