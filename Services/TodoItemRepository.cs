using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.Exceptions;
using TodoApiDTO.Helpers;
using TodoApiDTO.Interfaces;
using TodoApiDTO.Models;

namespace TodoApiDTO.Services
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext context;

        public TodoItemRepository(TodoContext context)
        {
            this.context = context;
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            var items = await context.TodoItems.ToListAsync();
            return items;
        }

        public async Task<TodoItem> GetTodoItemAsync(long id)
        {
            var item = await context.TodoItems.FindAsync(id);
            return item is null
                ? throw new TodoItemNotFoundException($"Todoitem not found by id: {id}")
                : item;
        }

        public async Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem)
        {
            var item = new TodoItem
            {
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete          
            };

            context.TodoItems.Add(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            var item = await GetTodoItemAsync(todoItem.Id);

            item.Name = todoItem.Name;
            item.IsComplete = todoItem.IsComplete;
            await context.SaveChangesAsync();
        }

        public async Task DeleteTodoItemAsync(long id)
        {
            var item = await GetTodoItemAsync(id);
            context.TodoItems.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
