namespace TaskManager.BLL.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GenerateResponse(string prompt);
    }
}
