using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public bool Important { get; set; }
        public int GoalId { get; set; }
        public bool Selected { get; set; } = false;
    }
}
