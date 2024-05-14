using System.ComponentModel.DataAnnotations;

namespace DynamicForm.Models
{
    public class FormDataResponseModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
        public string? Nationality { get; set; }
        public int IdNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public List<QuestionInputModel> Questions { get; set; }
    }
}
