using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public string book { get; set; }
        public int? cant_reserved { get; set; }
        [Required]
        public string description { get; set; }


    }
}