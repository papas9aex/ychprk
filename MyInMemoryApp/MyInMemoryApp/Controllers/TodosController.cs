using Microsoft.AspNetCore.Mvc;
using MyInMemoryApp.Models;

namespace MyInMemoryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly InMemoryDataStore _dataStore;

        public TodosController(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetTodos()
        {
            return _dataStore.GetTodos();
        }

        [HttpPost]
        public ActionResult<TodoItem> CreateTodo([FromBody] TodoItem todoItem)
        {
            _dataStore.AddTodo(todoItem);
            return CreatedAtAction(nameof(GetTodos), new { id = todoItem.Id }, todoItem);
        }
    }
}
