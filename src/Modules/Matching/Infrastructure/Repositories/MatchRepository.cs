using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Campuslove_Sheyla_Fabio.src.Modules.Matching.Infrastructure.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly AppDbContext _context;

        public MatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Match> AddAsync(Match match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<IEnumerable<Match>> GetMatchesForUserAsync(int userId)
        {
            return await _context.Matches
                .Where(m => m.User1Id == userId || m.User2Id == userId)
                .Include(m => m.User1)
                .Include(m => m.User2)
                .ToListAsync();
        }
    }
}