namespace AppConsumingRestApi.Models
{
    public class ImageLinks
    {
        private string _thumbnail;
        public string Thumbnail
        {
            set { _thumbnail = value; }
            get
            {
                var parts = _thumbnail.Split(':');
                return string.Join("s:", parts);

            }
        }
        public string SmallThumbnail { get; set; }
    }
}