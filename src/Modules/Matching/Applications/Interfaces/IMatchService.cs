using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Modules.Matching.Domain.Entities;

namespace Campuslove_Sheyla_Fabio.src.Modules.Matching.Applications.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<Match>> GetUserMatchesAsync(int userId);
    }
}