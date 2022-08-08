using System.Collections.Generic;

namespace AppConsumingRestApi.Models
{
    public class Response
    {
        public int TotalItems { get; set; }
        public List<Item> Items { get; } = new List<Item>();
    }
}