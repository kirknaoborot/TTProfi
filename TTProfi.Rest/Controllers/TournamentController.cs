using Microsoft.AspNetCore.Mvc;
using TTProfi.Core.Models.Tournament;
using TTProfi.Service.InputModels;
using TTProfi.Service.Interfaces;

namespace TTProfi.Rest.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        /// <summary>
        /// Метод получения списка турниров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<TournamentModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Tournaments()
        {
            var result = await _tournamentService.GetTournaments();

            return Ok(result);
        }

        /// <summary>
        /// Метод добавления турнира
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Tournament([FromBody] CreateTournamentInputModel model)
        {
            await _tournamentService.Create(model);

            return Ok();
        }

        /// <summary>
        /// Метод добавления игроков на турнир
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Players([FromBody] RegisterPlayersInputModel model)
        {
            try
            {
                await _tournamentService.RegisterPlayers(model);

                return Ok();
            }
            catch (InvalidOperationException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Метод добавления типа турнира
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Type([FromBody] string name)
        {
            await _tournamentService.CreateTypeTournament(name);

            return Ok();
        }

        /// <summary>
        /// метод получения списка типов турниров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<TypeTournamentModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Type()
        {
            var result = await _tournamentService.GetTypeTournaments();

            return Ok(result);
        }
    }
}
