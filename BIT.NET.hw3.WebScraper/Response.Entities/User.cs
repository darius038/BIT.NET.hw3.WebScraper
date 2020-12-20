using System;
using System.Collections.Generic;
using System.Text;

namespace BIT.NET.hw3.WebScraper.Response.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"User Id: {Id} User name: {Name}";
        }
    }
}
