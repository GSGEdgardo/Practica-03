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
        public virtual User user { get; set; }
        
        [Required]
        [ForeignKey("book_id")]
        public virtual Book book { get; set; }

        [Required]
        public DateTime? reserved_at { get; set;}
    }
}