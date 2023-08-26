using AssetMon.Shared.DTOs;

namespace AssetMon.Services.Interface
{
    public interface IEmailService
    {
        Task SendMailAsync(EmailDTO emailDTO);
    }
}
