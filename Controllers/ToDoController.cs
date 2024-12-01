using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private static List<ToDoItem> toDoItems = new List<ToDoItem>
    {
        new ToDoItem { Id = 1, Name = "Aprender .NET 9", IsComplete = false }
    };

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItem>> Get()
    {
        return toDoItems;
    }

    [HttpGet("{id}")]
    public ActionResult<ToDoItem> Get(int id)
    {
        var item = toDoItems.FirstOrDefault(t => t.Id == id);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost]
    public ActionResult<ToDoItem> Post(ToDoItem newItem)
    {
        toDoItems.Add(newItem);
        return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
    }
}
