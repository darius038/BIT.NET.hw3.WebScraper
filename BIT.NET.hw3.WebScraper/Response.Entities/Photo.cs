using System;
using System.Collections.Generic;
using System.Text;

namespace BIT.NET.hw3.WebScraper.Response.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return $"Photo Id: {Id} Album id: {AlbumId} Url: {Url}";
        }

    }
}
