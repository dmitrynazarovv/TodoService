using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.Models;

namespace TodoApiDTO.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemAsync(long id);
        Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem);
        Task UpdateTodoItemAsync(TodoItem todoItem);
        Task DeleteTodoItemAsync(long id);
    }
}
