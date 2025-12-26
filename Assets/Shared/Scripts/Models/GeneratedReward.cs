using System;

namespace Shared.Models
{
    public class GeneratedReward
    {
        public int id { get; set; }
        public DateTime timestamp { get; set; }
        public string username { get; set; }
        public Item item { get; set; }
        public int itemId { get; set; }
    }
}