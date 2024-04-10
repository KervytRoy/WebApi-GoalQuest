using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Domain.Entities
{
    public class Goal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        // Relación uno a muchos con Activity
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
