using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Application.DTOs;
using Application.Interfaces.External;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure.ExternalServices
{
    public class MarvelApiService(HttpClient httpClient, IConfiguration configuration) : IMarvelApiService
    {
        public async Task<List<MarvelComicDto>> GetComicsAsync()
        {
            var publicKey = configuration["MarvelApi:PublicKey"];
            var privateKey = configuration["MarvelApi:PrivateKey"];
            var ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var hash = CreateMd5Hash(ts + privateKey + publicKey);

            var url = $"https://gateway.marvel.com/v1/public/comics?ts={ts}&apikey={publicKey}&hash={hash}";

            var response = await httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);
            var data = json["data"]?["results"];
            var comicTokens = json["data"]?["results"];

            var comics = new List<MarvelComicDto>();

            if (comicTokens != null)
                foreach (var comicToken in comicTokens)
                {
                    comicToken["modified"] = null;
                    var thumbnail = comicToken["thumbnail"];
                    var path = thumbnail?["path"]?.ToString().Replace("http://", "https://");
                    var extension = thumbnail?["extension"];
                    var imageUrl = $"{path}.{extension}";
                    comicToken["thumbnail"]!["path"] = imageUrl;
                    var datesJToken = comicToken["dates"];
                    if (datesJToken != null)
                        foreach (var dates in datesJToken)
                        {
                            dates["date"] = null;
                        }

                    try
                    {
                        var comicDto = comicToken.ToObject<MarvelComicDto>();

                        var modifiedString = comicToken["modified"]?.ToString();
                        if (DateTime.TryParse(modifiedString, out DateTime modifiedDate))
                        {
                            if (comicDto != null) comicDto.Modified = modifiedDate;
                        }
                        else
                        {
                            if (comicDto != null) comicDto.Modified = null;
                        }


                        if (comicDto != null) comics.Add(comicDto);
                    }
                    catch (JsonReaderException ex)
                    {
                        Console.WriteLine($"Error parsing comic: {ex.Message}");
                    }
                }

            return comics;
        }
        
        private string CreateMd5Hash(string input)
        {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        
    }
}
