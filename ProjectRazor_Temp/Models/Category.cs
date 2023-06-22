using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectRazor_Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("DisPlay Order")]
        [Range(1, 100, ErrorMessage = "Giá trị không hợp lệ ! Vui lòng thử lại")]
        public int DisplayOrder { get; set; }
    }
}
