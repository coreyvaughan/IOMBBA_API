using Objects.Models;
using System.Collections.Generic;


namespace Objects.Interfaces
{
    public interface ICompetition
    {
        /// <summary>
        /// Gets all competitions from the database.
        /// </summary>
        /// <returns>A list of competition models</returns>
        IEnumerable<CompetitionModel> GetAllCompetitions();
    }
}