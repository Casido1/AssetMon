namespace AssetMon.Services.Interface
{
    public interface IPictureService
    {
        Task<string> GetPictureUrl(string pictureId);
        Task<string> UploadPicture(Stream stream, string fileName);
    }
}
