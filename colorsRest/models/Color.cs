
using System.ComponentModel.DataAnnotations;

namespace colorsRest.Models
{
    public class Color
    {
        private const string RGB_ERROR = "Must be '#' plus a six digits hexadecimal value. Ex #CACACA";

        public static string getRGBError()
        {
            return RGB_ERROR;
        }
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        [RegularExpression(@"^#[0-9A-Fa-f]{6}$", ErrorMessage = RGB_ERROR)]
        public string Rgb { get; set; }
    }

}