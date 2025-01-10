using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Company { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool DataConsent { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool InfoConsent { get; set; }
    }
}
