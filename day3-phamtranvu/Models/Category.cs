using System.ComponentModel.DataAnnotations;

namespace day3_phamtranvu.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id {  get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Ten danh muc phai co tu 2 den 100 ki tu")]
        public string Name { get; set; } = string.Empty;
    }
}
