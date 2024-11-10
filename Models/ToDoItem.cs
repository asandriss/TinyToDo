namespace TinyToDo.Models;

public class ToDoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public bool Completed { get; set; }

}