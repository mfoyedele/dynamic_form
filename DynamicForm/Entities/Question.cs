namespace DynamicForm.Entities
{
    public abstract class Question
    {
        public int Id { get; }
        public string Type { get; }
        public string Text { get; set; }

        protected Question(string type, string text)
        {
            Id = GenerateId();
            Type = type;
            Text = text;
        }

        protected Question(string text)
        {
            Text = text;
        }

        private static int GenerateId()
        {

            return Guid.NewGuid().GetHashCode();
        }
    }
}
