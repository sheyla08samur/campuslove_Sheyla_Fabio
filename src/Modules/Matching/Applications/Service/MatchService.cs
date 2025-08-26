using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Matching.Applications.Service
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<Match>> GetUserMatchesAsync(int userId)
        {
            return await _matchRepository.GetMatchesForUserAsync(userId);
        }

        public async Task<IEnumerable<Match>> ConsultarPorUsuarioAsync(int userId)
        {
            return await _matchRepository.GetMatchesForUserAsync(userId);
        }

        public async Task<Match> RegistrarMatchAsync(int user1Id, int user2Id)
        {
            if (user1Id == user2Id)
            {
                throw new ArgumentException("Un usuario no puede hacer match consigo mismo.");
            }
            var nuevoMatch = new Match
            {
                User1Id = user1Id,
                User2Id = user2Id,
                CreatedAt = DateTime.UtcNow
            };

            return await _matchRepository.AddAsync(nuevoMatch);
        }
    }
}