using Microsoft.EntityFrameworkCore;
using TinyToDo.Models;

namespace TinyToDo.Data;

public class ToDoContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ToDoItem> Items { get; set; }
}