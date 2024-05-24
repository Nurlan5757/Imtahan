using System.ComponentModel.DataAnnotations;

namespace Imtahan.ViewModels
{
    public class UpdateVM
    {
       
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
