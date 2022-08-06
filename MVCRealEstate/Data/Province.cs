namespace MVCRealEstate.Data
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
