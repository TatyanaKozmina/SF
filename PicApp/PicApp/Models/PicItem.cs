using System;

namespace PicApp.Models
{
    public class PicItem
    {
        public string Description { get; set; } = string.Empty;
        public string PicPath { get; set; } = string.Empty;
        public DateTime? PicDate { get; set; }

        public PicItem(string description, string picPath, DateTime? picDate = null)
        {
            Description = description;
            PicPath = picPath;
            PicDate = picDate;
        }
    }
}
