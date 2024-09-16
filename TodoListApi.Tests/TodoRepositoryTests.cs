using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using TodoListApi.Models;
using TodoListApi.Repositories;
using TodoListApi.Tests;

namespace TodoListApi.Tests;

public class TodoRepositoryTests : IAsyncLifetime
{
    private readonly TodoContext _context;
    private readonly TodoRepository _repository;

    public TodoRepositoryTests()
    {
        var options = TestHelpers.CreateInMemoryDbContextOptions();
        _context = new TodoContext(options);
        _repository = new TodoRepository(_context);
    }

    public async Task InitializeAsync()
    { }

    public async Task DisposeAsync()
    {
        await _context.Database.EnsureDeletedAsync();
        _context.Dispose();
    }

    [Fact]
    public async Task AddAsync_ShouldAddTodoItem()
    {
        var todoItem = new TodoItem { Title = "New Task", Description = "Test Description" };
        await _repository.AddAsync(todoItem);

        var items = await _context.TodoItems.ToListAsync();
        items.Should().HaveCount(1);
        items.First().Title.Should().Be("New Task");
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllItems()
    {
        _context.TodoItems.Add(new TodoItem { Title = "Task 1", Description = "Description 1" });
        _context.TodoItems.Add(new TodoItem { Title = "Task 2", Description = "Description 2" });
        await _context.SaveChangesAsync();

        var items = await _repository.GetAllAsync();
        items.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectItem()
    {
        var todoItem = new TodoItem { Title = "Task 1", Description = "Description 1" };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        var item = await _repository.GetByIdAsync(todoItem.Id);
        item.Title.Should().Be("Task 1");
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateItem()
    {
        var todoItem = new TodoItem { Title = "Original Title", Description = "Original Description" };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        todoItem.Title = "Updated Title";
        await _repository.UpdateAsync(todoItem);

        var updatedItem = await _context.TodoItems.FindAsync(todoItem.Id);
        updatedItem.Title.Should().Be("Updated Title");
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveItem()
    {
        var todoItem = new TodoItem { Title = "Task to Delete", Description = "Delete this task" };
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(todoItem.Id);

        var item = await _context.TodoItems.FindAsync(todoItem.Id);
        item.Should().BeNull();
    }
}