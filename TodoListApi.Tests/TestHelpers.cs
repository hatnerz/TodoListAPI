using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApi.Models;

namespace TodoListApi.Tests
{
    public static class TestHelpers
    {
        public static DbContextOptions<TodoContext> CreateInMemoryDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryTodoDatabase")
                .Options;
            return options;
        }
    }
}
