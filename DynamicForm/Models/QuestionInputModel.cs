namespace DynamicForm.Models
{
    public class QuestionInputModel
    {

        public string Type { get; set; }
        public string Text { get; set; }
        public required List<string> Options { get; set; }
    }
}
