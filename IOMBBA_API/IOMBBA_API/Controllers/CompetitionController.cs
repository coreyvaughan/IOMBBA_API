using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Objects.Interfaces;
using Objects.Models;

namespace IOMBBA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]

    public class CompetitionController : ControllerBase
    {
        // Declare the interface.
        private readonly ICompetition competitionService;

        public CompetitionController(ICompetition context)
        {
            competitionService = context;
        }

        /// <summary>
        /// Gets all competitions from the database.
        /// </summary>
        /// <returns>A list of competition models</returns>
        [HttpGet]
        [Route("GetCompetitions")]

        public IEnumerable<CompetitionModel> GetAllCompetitions()
        {
            return competitionService.GetAllCompetitions();
        }
    }
}