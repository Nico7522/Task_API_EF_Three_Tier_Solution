namespace Task_EF_Three_Tier.API.Models.Forms
{
    public class FileForm
    {
        #nullable disable
        public string Directory { get; private set; } 
        public IFormFile File { get; set; }

        public FileForm()
        {
            Directory = "K:\\DEV\\.NET\\Projets perso\\Task_API_EF_Three_Tier_Solution\\Task_EF_Three_Tier.API\\wwwroot\\Images";
        }

    }
}
