namespace AssetMon.Shared.DTOs
{
    public class ResultDTO<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
