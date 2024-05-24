using System.ComponentModel.DataAnnotations;

namespace Imtahan.ViewModels
{
    public class GetVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
