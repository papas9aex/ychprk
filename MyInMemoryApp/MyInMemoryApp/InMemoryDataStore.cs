using System.Collections.Generic;
using MyInMemoryApp.Models;


namespace MyInMemoryApp
{
    public class InMemoryDataStore
    {
        private readonly List<TodoItem> _todos = new();
        private readonly List<User> _users = new();
        private readonly List<LogItem> _logs = new();
        private int _nextTodoId = 1;
        private int _nextUserId = 1;
        private int _nextLogId = 1;

        // Методы для работы с TodoItem
        public List<TodoItem> GetTodos()
        {
            return _todos;
        }

        public void AddTodo(TodoItem todoItem)
        {
            todoItem.Id = _nextTodoId++;
            _todos.Add(todoItem);
        }

        // Методы для работы с User
        public List<User> GetUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            user.Id = _nextUserId++;
            _users.Add(user);
        }

        public User Authenticate(string username, string password)
        {
            // Найти пользователя по имени и паролю
            return _users.Find(u => u.Username == username && u.Password == password);
        }

        // Методы для работы с LogItem
        public List<LogItem> GetLogs()
        {
            return _logs;
        }

        public void AddLog(LogItem logItem)
        {
            logItem.Id = _nextLogId++;
            _logs.Add(logItem);
        }
    }
}
