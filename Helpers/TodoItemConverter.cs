using TodoApiDTO.Models;
using TodoApiDTO.ModelsDTO;

namespace TodoApiDTO.Helpers
{
    public static class TodoItemConverter
    {
        public static TodoItemDTO GetConvertItemToDTO(TodoItem todoItem)
        {
            var result = new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
            return result;
        }

        public static TodoItem GetConvertItemTo(TodoItemDTO todoItemDTO)
        {
            var result = new TodoItem
            {
                Id = todoItemDTO.Id,
                Name = todoItemDTO.Name,
                IsComplete = todoItemDTO.IsComplete
            };
            return result;
        }
    }
}
