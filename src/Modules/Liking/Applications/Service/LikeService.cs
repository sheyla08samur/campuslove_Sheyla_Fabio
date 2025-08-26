using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Liking.Applications.Service
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task GiveLikeAsync(int emisorId, int receptorId, bool isLike)
        {
            var like = new Like
            {
                EmisorUsuarioId = emisorId,
                ReceptorUsuarioId = receptorId,
                IsLike = isLike,
                Fecha = DateTime.UtcNow
            };

            await _likeRepository.AddAsync(like);
        }

        public async Task<int> GetLikesReceivedAsync(int userId)
        {
            return await _likeRepository.CountLikesReceivedAsync(userId);
        }

        public async Task<int> GetDislikesReceivedAsync(int userId)
        {
            var dislikes = await _likeRepository.GetLikesByUserAsync(userId);
            return dislikes.Count(l => l.IsLike == false);
        }
    }
}