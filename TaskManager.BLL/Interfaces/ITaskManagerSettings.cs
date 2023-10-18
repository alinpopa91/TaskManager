namespace TaskManager.BLL.Interfaces
{
    public interface ITaskManagerSettings
    {
        string OpenAIBaseAddress { get; set; }
        string OpenAIKey { get; set; }
        string OpenAIUrl { get; set; }
        string ChatGBTEngine { get; set; }
        string InMemoryDatabaseName { get; set; }

    }
}
