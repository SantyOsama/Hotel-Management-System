
namespace HotelMangementSystem.Repositories
{
    public class FileRepo : IFileRepo
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileRepo(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> Upload(IFormFile ProfilePic, string location, string userName)
        {

            try
            {
                var path = webHostEnvironment.WebRootPath + location;
                var extension = Path.GetExtension(ProfilePic.FileName);
                var fileName = userName + extension; // change fileName to  user username



                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //saving
                using (FileStream fileStream = File.Create(path + fileName))
                {
                    await ProfilePic.CopyToAsync(fileStream);
                    fileStream.Flush();
                    return $"{location}/{fileName}";
                }
            }
            catch (Exception e)
            {
                return e.Message;

            }












        }
    }
}
