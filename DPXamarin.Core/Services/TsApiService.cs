using System.Collections.Generic;
using System.Threading.Tasks;
using DPXamarin.Core.Models;

namespace DPXamarin.Core.Services
{
    public class TsApiService : BaseProvider, ITsApiService
    {
        public TsApiService()
        {
            _baseUrl = "http://gateway.marvel.com:80/v1/public/comics?apikey=a2cfff2c08621b9d7a829ca6c4cb0828";
        }

        public async Task<List<Personagem>> GetComics()
        {
            return await Get<List<Personagem>>("");
        }

        public async Task<Personagem> GetComicById(int id)
        {
            return await Get<Personagem>($"comics/{id}?apikey=a2cfff2c08621b9d7a829ca6c4cb0828");
        }
    }
}
