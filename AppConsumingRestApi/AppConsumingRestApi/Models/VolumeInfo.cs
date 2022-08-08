namespace AppConsumingRestApi.Models
{
    public class VolumeInfo
    {
        public string Title { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }

        public ImageLinks ImageLinks { get; set; }
    }
}