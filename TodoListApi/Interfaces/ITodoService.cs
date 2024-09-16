using TodoListApi.Models;

namespace TodoListApi.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllItemsAsync();
        Task<TodoItem> GetItemByIdAsync(int id);
        Task CreateItemAsync(TodoItem todoItem);
        Task UpdateItemAsync(TodoItem todoItem);
        Task DeleteItemAsync(int id);
    }
}
