using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class Reserve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [ForeignKey("user_id")]
        public int user_id { get; set; }
        
        [Required]
        [ForeignKey("book_id")]
        public int book_id { get; set; }

        [Required]
        public DateTime? reserved_at { get; set;}
    }
}