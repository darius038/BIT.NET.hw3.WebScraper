using System;
using System.Collections.Generic;
using System.Text;

namespace BIT.NET.hw3.WebScraper.Response.Entities
{
    class Album
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return $"Album Id: {Id} User id: {UserId} Title: {Title}";
        }
    }
}
