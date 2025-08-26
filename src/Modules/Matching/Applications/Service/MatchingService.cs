using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Matching.Applications.Service
{
    public class MatchingService : IMatchService
    {
        private readonly IMatchRepository _repo;

        public MatchingService(IMatchRepository repo)
        {
            _repo = repo;
        }

        public Task<Match> ConsultarTodosAsync()
        {
            return _repo.GetMatchesForUserAsync(userId);
        }

        public async Task<IEnumerable<Match>> ConsultarPorUsuarioAsync(int userId)
        {
            var allMatches = await _repo.GetAllAsync();
            return allMatches.Where(m => m.User1Id == userId || m.User2Id == userId);
        }

        public async Task<Match> RegistrarMatchAsync(int user1Id, int user2Id)
        {
            var existentes = await _repo.GetAllAsync();

            // Evitar duplicados
            if (existentes.Any(m =>
                (m.User1Id == user1Id && m.User2Id == user2Id) ||
                (m.User1Id == user2Id && m.User2Id == user1Id)))
            {
                throw new InvalidOperationException("Este match ya existe.");
            }

            var match = new Match
            {
                Id = Guid.NewGuid(),
                User1Id = user1Id,
                User2Id = user2Id,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(match);
            await _repo.SaveChangesAsync();

            return match;
        }
    }
}