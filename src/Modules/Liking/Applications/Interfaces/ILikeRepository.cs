using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Liking.Applications.Interfaces
{
    public interface ILikeRepository
    {
        Task AddAsync(Like like);
        Task<IEnumerable<Like>> GetLikesByUserAsync(int userId);
        Task<int> CountLikesReceivedAsync(int userId);
    }
}