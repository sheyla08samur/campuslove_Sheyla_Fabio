using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Matching.Applications.Interfaces
{
    public interface IMatchRepository
    {
        Task AddAsync(Match match);
        Task<IEnumerable<Match>> GetMatchesForUserAsync(int userId);
        Task<Match> GetMatchesForUserAsync(object userId);
    }
}