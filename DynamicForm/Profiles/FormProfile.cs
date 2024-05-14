using AutoMapper;
using DynamicForm.Entities;
using DynamicForm.Models;

namespace DynamicForm.Profiles
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<FormData, QuestionInputModel>();
            CreateMap<QuestionResponseModel, FormData>();
            CreateMap<QuestionInputModel, FormData>();
            CreateMap<FormData, QuestionResponseModel>();
        }
    }
}
