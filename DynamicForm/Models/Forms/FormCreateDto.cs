﻿using System.ComponentModel.DataAnnotations;

namespace DynamicForm.Models.Forms
{
    public class FormCreateDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string? Nationality { get; set; }
        [Required]
        public int IdNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public List<QuestionInputModel> Questions { get; set; }
    }
}