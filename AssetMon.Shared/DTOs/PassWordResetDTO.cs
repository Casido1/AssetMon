namespace AssetMon.Shared.DTOs
{
    public class PassWordResetDTO
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
