using BIT.NET.hw3.WebScraper.Response.Entities;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BIT.NET.hw3.WebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // WebScraper https://jsonplaceholder

            var urlUsers = "https://jsonplaceholder.typicode.com/users";
            var urlAlbums = "https://jsonplaceholder.typicode.com/albums";
            var urlPhotos = "https://jsonplaceholder.typicode.com/photos";

            var userEntity = new User();
            var users = await requestHandler(userEntity, urlUsers);

            var albumEntity = new Album();
            var albums = await requestHandler(albumEntity, urlAlbums);

            var photoEntity = new Photo();
            var photos = await requestHandler(photoEntity, urlPhotos);


            var query = from user in users
                        join album in albums on user.Id equals album.UserId
                        join photo in photos on album.Id equals photo.AlbumId
                        where user.Name == "Mrs. Dennis Schulist"
                        select photo.Url;

            Console.WriteLine("Mrs.Dennis Schulist photos urls:");

            foreach (var url in query)
                Console.WriteLine(url);

            // WebScraper cvonline job titles

            Console.WriteLine("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos");
            await requestHandlerCvOnline();
            
        }

        public static async Task<List<T>> requestHandler<T>(T entity, string url)
        {
            using var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<T>>(responseBody);            
        }


        public static async Task requestHandlerCvOnline()
        {
            HttpClient client = new HttpClient();
           
            var response = await client.GetAsync("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(responseBody);

            var jobTitleLinks = htmlDoc.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Contains("offer_primary_info")).ToList();

            var jobTitleList = jobTitleLinks.Select(l => l.FirstChild.FirstChild.InnerHtml);
      
            foreach (var item in jobTitleList.ToList())
            {
                Console.WriteLine("Job title: " + item);               
            }
        }
    }
}
