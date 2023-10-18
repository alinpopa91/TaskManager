namespace TaskManager.BLL.Utils
{
    public class ClientRequest
    {
        public Guid ID { get; set; }
        public string UserAgent { get; set; }
        public string Host { get; set; }
        public string WebPath { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string IP { get; set; }
        public DateTime Timestamp { get; set; }
        public string AreaAccessed { get; set; }
        public bool IsMobile { get; set; }
        public string Enterprise { get; set; }
        public Guid SessionId { get; set; }
    }
}
