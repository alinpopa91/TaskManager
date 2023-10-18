using TaskManager.BLL.Interfaces;

namespace TaskManager.BLL.Models
{
    public class TaskManagerSettings : ITaskManagerSettings
    {
        public string OpenAIBaseAddress { get; set; }
        public string OpenAIKey { get; set; }
        public string OpenAIUrl { get; set; }
        public string ChatGBTEngine { get; set; }
        public string InMemoryDatabaseName { get; set; }
    }
}
