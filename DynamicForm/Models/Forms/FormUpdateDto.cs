using System.ComponentModel.DataAnnotations;

namespace DynamicForm.Models.Forms
{
    public class FormUpdateDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Nationality { get; set; }
        [Required]
        public int IdNumber { get; set; }
        [Required]        
        public string? DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public List<QuestionInputModel> Questions { get; set; }
    }
}
