using System.ComponentModel.DataAnnotations;

namespace MVCRealEstate.Data
{

    public enum PropertyTypes
    {
        [Display(Name = "Satılık")]
        ForSale,
        [Display(Name = "Kiralık")]
        ForRent,
        [Display(Name = "Devremülk")]
        TimeShared
    }

    public class Property
    {

        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        
        public DateTime DateModified { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public string Headline { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [RegularExpression("[0-9]+", ErrorMessage = "Lütfen geçerli bir fiyat yazınız!")]
        public decimal Price { get; set; }

        [Display(Name = "Açıklamalar")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public string Descriptions { get; set; }

        [Display(Name = "Görsel")]
        public byte[]? Image { get; set; }

        [Display(Name = "İlan Tipi")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public PropertyTypes Type { get; set; }

        [Display(Name = "Etkin")]
        public bool Enabled { get; set; }

        #region navigation

        public Category? Category { get; set; }

        #endregion

    }
}
