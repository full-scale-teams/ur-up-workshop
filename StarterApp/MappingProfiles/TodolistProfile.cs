using AutoMapper;
using StarterApp.Models.Entities;
using StarterApp.Models.ViewModels;

namespace StarterApp.MappingProfiles
{
    public class TodolistProfile : Profile
    {
        public TodolistProfile()
        {
            CreateMap<Todolist, ViewTodolist>();
        }
    }
}
