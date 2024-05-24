using System.ComponentModel.DataAnnotations;

namespace Imtahan.Models
{
    public class Chefs
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image {  get; set; }
    }
}
