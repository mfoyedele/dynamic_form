namespace DynamicForm.Models
{
    public class QuestionResponseModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public required List<string> Options { get; set; }
    }
}
