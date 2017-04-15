using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TempConverter.Models
{
    public class TemperatureConverterViewModel
    {
       public List<string> Temp         { get; set; }
        [Required(ErrorMessage = "Please select a conversion option")]
        [DisplayName("Conversion Option")]
        public string ConversionType    { get; set; }

        [Required(ErrorMessage = "Please enter a starting Temperature")]
        [DisplayName("Starting Temp")]
        public string StartingTemp      { get; set; }
    }
}