using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [ForeignKey("customer_id")]
        public int customer_id { get; set; }
        
        [Required]
        [ForeignKey("dish_id")]
        public int dish_id { get; set; }

        [Required]
        public DateTime created_at { get; set;}
        
        [Required]
        public DateTime updated_at { get; set;}

    }
}