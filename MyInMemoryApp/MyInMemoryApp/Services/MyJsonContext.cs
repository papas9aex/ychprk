using MyInMemoryApp.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyInMemoryApp
{
    [JsonSerializable(typeof(TodoItem))]
    [JsonSerializable(typeof(List<TodoItem>))]
    public partial class MyJsonContext : JsonSerializerContext
    {
    }
}
