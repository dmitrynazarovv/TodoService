using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.Exceptions;
using TodoApiDTO.Interfaces;
using TodoApiDTO.ModelsDTO;

namespace TodoApiDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ILogger<TodoItemsController> logger;
        private readonly ITodoItemService todoItemService;

        public TodoItemsController(
            ITodoItemService todoItemService,
            ILogger<TodoItemsController> logger)
        {
            this.todoItemService = todoItemService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<List<TodoItemDTO>> GetTodoItemsAsync()
        {
            var result = await todoItemService.GetTodoItemsAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItemAsync(long id)
        {
            try
            {
                var result = await todoItemService.GetTodoItemAsync(id);
                return result;
            }
            catch (TodoItemNotFoundException ex)
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unknown error when getting todoitem by id: {id}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItemAsync(TodoItemDTO todoItemDTO)
        {
            try
            {
                var result = await todoItemService.CreateTodoItemAsync(todoItemDTO);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unknown error occurred while creating todoitem");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItemAsync(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                logger.LogInformation($"Todoitem update request called." + $"Id mismatch found: {id} and {todoItemDTO.Id}");
                return BadRequest();
            }

            try
            {
                await todoItemService.UpdateTodoItemAsync(todoItemDTO);
            }
            catch (TodoItemNotFoundException ex)
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unknown error when updating a todoitem with id: {id}");
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItemAsync(long id)
        {
            try
            {
                await todoItemService.DeleteTodoItemAsync(id);
                return NoContent();
            }
            catch (TodoItemNotFoundException ex) 
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unknown error when deleting a todoItem with id : {id}");
                return BadRequest();
            }
        }
    }
}
