using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Objects.Interfaces
{
    public interface IGameplayStat
    {
        /// <summary>
        /// Creates a new shot record on the database.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>GameplayStatDetails object with details of the new records that have been added</returns>
        Task<GameplayStatDetails> AddShot(GameplayStatDetails statObject);

        /// <summary>
        /// Creates a new foul record on the database.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>A StatDetails object including the new foul information that has been added to the database.</returns>
        Task<GameplayStatDetails> AddFoul(GameplayStatDetails statObject);

        /// <summary>
        /// Creates new substitution records on the database.
        /// </summary>
        /// <param name="statObject">The statistic details to be added to the database</param>
        /// <returns>A list of the stat IDs of the new substitution stats that have been added.</returns>
        Task<List<Guid>> AddSubstitution(GameplayStatDetails statObject);

        /// <summary>
        /// Remove corresponding GameplayStat records from database related to stat ids list.
        /// </summary>
        /// <param name="statIds">The StatIds of the substitution statistics to be removed</param>
        Task DeleteSubstitutions(List<Guid> statIds);

        /// <summary>
        /// Remove Shot and corresponding GameplayStat records from database.
        /// </summary>
        /// <param name="statId">The StatId of the statistics to be removed</param>
        /// <returns>GameplayStatDetails object with details of the new records that have been added</returns>
        Task DeleteShot(Guid statId);

        /// <summary>
        /// Creates a new general stat record on the database. General stats include rebounds, turnovers, steals, blocks etc.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>GameplayStat object with details of the new records that have been added</returns>
        Task<GameplayStatModel> AddGeneralStat(GameplayStatModel statObject);

        /// <summary>
        /// Returns a list of all gameplay stats related to a given player
        /// </summary>
        /// <param name="id">the id of the player</param>
        /// <returns>List of gameplay stat objects.</returns>
        Task<List<GameplayStatObject>> GetAllPlayerStats(int id);



        /// <summary>
        /// Returns a list of all gameplay stats related to a given fixture
        /// </summary>
        /// <param name="id">the id of the fixture</param>
        /// <returns>List of gameplay stat objects.</returns>
        Task<List<List<GameplayStatObject>>> GetAllGameplayStats(Guid id);
    }
}
