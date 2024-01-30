using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace LastRevision.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(511)]
        [DisplayName("CategoryName")]
        public string Name { get; set; }
        [Range(0,255)]
        public int DisPlayOrder { get; set; }
    }
}
