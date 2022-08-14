namespace MVCRealEstate.Data
{

    public enum PropertyTypes
    {
        ForSale, ForRent, TimeShared
    }

    public class Property
    {

        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Guid CategoryId { get; set; }

        public string Headline { get; set; }

        public decimal Price { get; set; }

        public string Descriptions { get; set; }

        public byte[]? Image { get; set; }

        public PropertyTypes Type { get; set; }

        #region navigation

        public Category? Category { get; set; }

        #endregion

    }
}
