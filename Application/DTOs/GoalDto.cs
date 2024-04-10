using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class GoalDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        public List<ActivityDto> Activities { get; set; }
    }
}
