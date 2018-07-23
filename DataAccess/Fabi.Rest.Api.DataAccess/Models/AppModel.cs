namespace Fabi.Rest.Api.DataAccess.Models
{
    public class AppModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Icon { get; set; }
        public bool IsBeta { get; set; }
        public int AppType { get; set;}
    }
}