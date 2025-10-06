using AutoMapper;
using StarterApp.Interfaces.Repositories;
using StarterApp.Interfaces.Services;
using StarterApp.Models.ViewModels;
using StarterApp.Utils;

namespace StarterApp.Services
{
    /// <summary>
    /// This is just a demo
    /// </summary>
    public class TodolistService : ITodolistService
    {
        private readonly ITodolistRepository _repository;
        private readonly IMapper _mapper;
        
        public TodolistService(ITodolistRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ViewTodolist>> GetAllTodolist()
        {
            var data = await _repository.GetAllTodos();
            return _mapper.Map<IEnumerable<ViewTodolist>>(data);
        }

        public async Task<ViewTodolist> GetViewTodolist(int id)
        {
            var data = await _repository.GetById(id) ?? 
                throw new NotFoundException("Todolist not found.");

            return _mapper.Map<ViewTodolist>(data);
        }
    }
}
