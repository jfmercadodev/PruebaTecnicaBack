using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.External
{
    public interface IMarvelApiService
    {
        Task<List<MarvelComicDto>> GetComicsAsync();
    }
}
