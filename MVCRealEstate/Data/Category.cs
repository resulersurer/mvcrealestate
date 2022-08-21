using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCRealEstate.Data
{
    public class Category
    {
        public Guid Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();

    }
}
