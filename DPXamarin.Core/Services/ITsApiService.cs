using System.Collections.Generic;
using System.Threading.Tasks;

using DPXamarin.Core.Models;

namespace DPXamarin.Core.Services
{
    public interface ITsApiService
    {
        Task<List<Personagem>> GetComics();
        Task<Personagem> GetComicById(int id);
    }
}
