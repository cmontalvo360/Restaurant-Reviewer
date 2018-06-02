using System.ComponentModel.DataAnnotations;
namespace restauranter.Models
{
    public class RestaurantViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 1 letter")]
        public string ReviewerName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 1 letter")]
        public string RestaurantName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Must be more than 9 letters")]
        public string Review { get; set; }
        [Required]
        public int Stars { get; set; }
        [Required]
        public string VisitDate { get; set; }
    }
}