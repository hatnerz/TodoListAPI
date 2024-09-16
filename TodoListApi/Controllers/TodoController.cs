using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListApi.Interfaces;
using TodoListApi.Models;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            var todos = await _todoService.GetAllItemsAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(int id)
        {
            var todo = await _todoService.GetItemByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodo(TodoItem todoItem)
        {
            await _todoService.CreateItemAsync(todoItem);
            return CreatedAtAction("GetTodo", new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _todoService.UpdateItemAsync(todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _todoService.GetItemByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            await _todoService.DeleteItemAsync(id);
            return NoContent();
        }

        private async Task<bool> TodoExists(int id)
        {
            var todo = await _todoService.GetItemByIdAsync(id);
            return todo != null;
        }
    }
}
