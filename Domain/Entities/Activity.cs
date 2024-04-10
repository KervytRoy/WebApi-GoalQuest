using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public bool Important { get; set; }
        [ForeignKey("Goal")]
        public int GoalId { get; set; }
        public virtual Goal Goal { get; set; }
    }
}
