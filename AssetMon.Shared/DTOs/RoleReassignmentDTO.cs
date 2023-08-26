namespace AssetMon.Shared.DTOs
{
    public class RoleReassignmentDTO
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
