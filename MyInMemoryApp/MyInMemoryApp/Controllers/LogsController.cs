using Microsoft.AspNetCore.Mvc;
using MyInMemoryApp.Models;

namespace MyInMemoryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly InMemoryDataStore _dataStore;

        public LogsController(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        public ActionResult<List<LogItem>> GetLogs()
        {
            return _dataStore.GetLogs();
        }

        [HttpPost]
        public ActionResult<LogItem> CreateLog([FromBody] LogItem logItem)
        {
            _dataStore.AddLog(logItem);
            return CreatedAtAction(nameof(GetLogs), new { id = logItem.Id }, logItem);
        }
    }
}
