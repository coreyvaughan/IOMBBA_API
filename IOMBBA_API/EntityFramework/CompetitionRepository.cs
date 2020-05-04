using IOMBBA_System.Models;
using Objects.Interfaces;
using Objects.Models;
using System.Collections.Generic;

namespace EntityFramework
{
    public class CompetitionRepository : ICompetition
    {
        // Initialise the database context.
        private readonly DbContextClass _context;

        public CompetitionRepository(DbContextClass context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all competitions from the database.
        /// </summary>
        /// <returns>A list of competition models</returns>
        public IEnumerable<CompetitionModel> GetAllCompetitions()
        {
            return _context.Competition;
        }
    }
}
