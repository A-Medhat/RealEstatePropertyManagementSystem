using System.ComponentModel.DataAnnotations;

namespace realEstate1.Models
{
    public class PropertyImage
    {
        [Key]
        public int ImageID { get; set; }

        public string ImagePath { get; set; } // Path to the image file

        // Foreign Key
        public int PropertyID { get; set; }

        
        public Property Property { get; set; }
    }
}
