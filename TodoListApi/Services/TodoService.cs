using TodoListApi.Interfaces;
using TodoListApi.Models;

namespace TodoListApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllItemsAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(int id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task CreateItemAsync(TodoItem todoItem)
        {
            await _todoRepository.AddAsync(todoItem);
        }

        public async Task UpdateItemAsync(TodoItem todoItem)
        {
            await _todoRepository.UpdateAsync(todoItem);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _todoRepository.DeleteAsync(id);
        }
    }
}
