namespace MVCRealEstate.Data
{
    public enum PropertyTypes 
    {
        ForSale, ForRent, TimeShare
    }

    public class Property
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Headline { get; set; }

        public PropertyTypes Type { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public string Descriptions { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public Category Category { get; set; }

    }
}
