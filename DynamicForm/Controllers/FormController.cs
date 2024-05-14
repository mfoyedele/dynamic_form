using DynamicForm.Entities;
using DynamicForm.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DynamicForm.Entities.QuestionTypes;

namespace ApplicationFormAPI.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private static List<Question> questions = new List<Question>();

        // POST api/questions
        [HttpPost]
        public ActionResult<FormDataResponseModel> PostQuestion([FromBody] FormData formData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<QuestionResponseModel> questionResponses = new List<QuestionResponseModel>();

            foreach (var input in formData.Questions)
            {
                Question question = null;
                switch (input.Type.ToLower())
                {
                    case "paragraph":
                        question = new ParagraphQuestion(input.Text);
                        break;
                    case "yesno":
                        question = new YesNoQuestion(input.Text);
                        break;
                    case "dropdown":
                        question = new DropdownQuestion(input.Text, input.Options);
                        break;
                    case "multiplechoice":
                        question = new MultipleChoiceQuestion(input.Text, input.Options);
                        break;
                    case "date":
                        question = new DateQuestion(input.Text);
                        break;
                    case "number":
                        question = new NumberQuestion(input.Text);
                        break;
                    default:
                        return BadRequest("Invalid question type.");
                }

                questions.Add(question);
                questionResponses.Add(new QuestionResponseModel
                {
                    Id = question.Id,
                    Type = question.Type,
                    Text = question.Text,
                    Options = question is DropdownQuestion dropdown ? dropdown.Options : question is MultipleChoiceQuestion multipleChoice ? multipleChoice.Options : new List<string>()
                });
            }

            return new FormDataResponseModel
            {
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                Email = formData.Email,
                PhoneNumber = formData.PhoneNumber,
                Nationality = formData.Nationality,
                IdNumber = formData.IdNumber,
                Gender = formData.Gender,
                DateOfBirth = formData.DateOfBirth,
                Questions = questionResponses
            };
        }

        // PUT api/questions/{id}
        [HttpPut("{id}")]
        public ActionResult<QuestionResponseModel> PutQuestion(int id, [FromBody] QuestionInputModel input)
        {
            var question = questions.Find(q => q.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            // Update question
            question.Text = input.Text;
            if (question is DropdownQuestion dropdownQuestion)
            {
                dropdownQuestion.Options = input.Options;
            }
            else if (question is MultipleChoiceQuestion multipleChoiceQuestion)
            {
                multipleChoiceQuestion.Options = input.Options;
            }

            return new QuestionResponseModel
            {
                Id = question.Id,
                Type = question.Type,
                Text = question.Text,
                Options = question is DropdownQuestion dropdown ? dropdown.Options : question is MultipleChoiceQuestion multiplechoice ? multiplechoice.Options : new List<string>()
            };
        }

        // GET api/questions/{id}
        [HttpGet("{id}")]
        public ActionResult<QuestionResponseModel> GetQuestion(int id)
        {
            var question = questions.Find(q => q.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return new QuestionResponseModel
            {
                Id = question.Id,
                Type = question.Type,
                Text = question.Text,
                Options = question is DropdownQuestion dropdown ? dropdown.Options : question is MultipleChoiceQuestion multiplechoice ? multiplechoice.Options : new List<string>()
            };
        }


        // DELETE api/questions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            var question = questions.Find(q => q.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            questions.Remove(question);

            return NoContent();
        }

    }
}