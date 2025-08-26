using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.Liking.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Shared.Context;

namespace Campuslove_Sheyla_Fabio.src.Modules.Liking.Infrastructure
{
    public class LikeRepository : ILikeRepository
    {
        private readonly AppDbContext _context;

        public LikeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Like>> GetLikesByUserAsync(int userId)
        {
            return await _context.Likes
                .Where(l => l.ReceptorUsuarioId == userId && l.IsLike)
                .ToListAsync();
        }

        public async Task<int> CountLikesReceivedAsync(int userId)
        {
            return await _context.Likes
                .CountAsync(l => l.ReceptorUsuarioId == userId && l.IsLike);
        }
    }
}
