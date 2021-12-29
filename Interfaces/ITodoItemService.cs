using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.ModelsDTO;

namespace TodoApiDTO.Interfaces
{
    public interface ITodoItemService
    {
        Task<List<TodoItemDTO>> GetTodoItemsAsync();
        Task<TodoItemDTO> GetTodoItemAsync(long id);
        Task<TodoItemDTO> CreateTodoItemAsync(TodoItemDTO todoItemDTO);
        Task UpdateTodoItemAsync(TodoItemDTO todoItemDTO);
        Task DeleteTodoItemAsync(long id);
    }
}
