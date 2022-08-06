namespace MVCRealEstate.Data
{
    public class Category
    {
        #region Scalar Properties
        public Guid Id { get; set; }

        public string Name { get; set; }

        #endregion

        #region Navigation Properties
        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();

        #endregion
    }
}
