namespace HotelMangementSystem.Repositories
{
    public interface IFileRepo
    {
        public Task<string> Upload(IFormFile ProfilePic, string location, string userName);
    }
}
