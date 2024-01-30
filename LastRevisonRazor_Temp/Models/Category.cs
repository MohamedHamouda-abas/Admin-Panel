using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LastRevisonRazor_Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(511)]
        [DisplayName("CategoryName")]
        public string Name { get; set; }
        [Range(0, 255)]
        public int DisPlayOrder { get; set; }
    }
}
