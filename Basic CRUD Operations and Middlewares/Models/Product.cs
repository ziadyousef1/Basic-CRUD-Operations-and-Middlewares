using System.ComponentModel.DataAnnotations;

namespace Basic_CRUD_Operations_and_Middlewares.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
