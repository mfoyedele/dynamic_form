namespace DynamicForm.Entities
{
    public class QuestionTypes
    {
        public class ParagraphQuestion : Question
        {
            public ParagraphQuestion(string text) : base("paragraph", text) { }
        }

        public class YesNoQuestion : Question
        {
            public YesNoQuestion(string text) : base("yesno", text) { }
        }

        public class DropdownQuestion : Question
        {
            public List<string> Options { get; set; }

            public DropdownQuestion(string text, List<string> options) : base("dropdown", text)
            {
                Options = options;
            }
        }

        public class MultipleChoiceQuestion : Question
        {
            public List<string> Options { get; set; }

            public MultipleChoiceQuestion(string text, List<string> options) : base("multiplechoice", text)
            {
                Options = options;
            }
        }

        public class DateQuestion : Question
        {
            public DateQuestion(string text) : base("date", text) { }
        }

        public class NumberQuestion : Question
        {
            public NumberQuestion(string text) : base("number", text) { }
        }
    }
}
