using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campuslove_Sheyla_Fabio.src.Modules.Liking.Applications.Interfaces
{
    public interface ILikeService
    {
        Task GiveLikeAsync(int emisorId, int receptorId, bool isLike);
        Task<int> GetLikesReceivedAsync(int userId);
        Task<int> GetDislikesReceivedAsync(int userId);
    }
}