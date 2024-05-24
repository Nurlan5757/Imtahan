using System.ComponentModel.DataAnnotations;

namespace Imtahan.ViewModels
{
    public class CreateVM
    {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
