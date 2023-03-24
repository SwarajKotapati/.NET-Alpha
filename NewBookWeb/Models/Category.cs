using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Enter Order")]
        [Range(1,100,ErrorMessage ="Please limit your input between 1 and 100 inclusive")]
        public string DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
