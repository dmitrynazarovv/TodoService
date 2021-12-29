using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApiDTO.Helpers;
using TodoApiDTO.Interfaces;
using TodoApiDTO.ModelsDTO;

namespace TodoApiDTO.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public async Task<List<TodoItemDTO>> GetTodoItemsAsync()
        {
            var items = await todoItemRepository.GetTodoItemsAsync();
            var result = items.Select(x => TodoItemConverter.GetConvertItemToDTO(x)).ToList();

            return result;
        }

        public async Task<TodoItemDTO> GetTodoItemAsync(long id)
        {
            var item  = await todoItemRepository.GetTodoItemAsync(id);
            var result = TodoItemConverter.GetConvertItemToDTO(item);
            return result;
        }

        public async Task<TodoItemDTO> CreateTodoItemAsync(TodoItemDTO todoItemDTO)
        {
            var resultItemTo = TodoItemConverter.GetConvertItemTo(todoItemDTO);
            var item = await todoItemRepository.CreateTodoItemAsync(resultItemTo);

            var result = TodoItemConverter.GetConvertItemToDTO(item);

            return result;
        }

        public async Task UpdateTodoItemAsync(TodoItemDTO todoItemDTO)
        {
            var todoItem = TodoItemConverter.GetConvertItemTo(todoItemDTO);
            await todoItemRepository.UpdateTodoItemAsync(todoItem);
        }

        public async Task DeleteTodoItemAsync(long id)
        {
            await todoItemRepository.DeleteTodoItemAsync(id);
        }

    }
}
