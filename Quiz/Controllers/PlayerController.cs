using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Players.Command;
using Quiz.Application.Players.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.UI.Controllers
{
    [Authorize]
    public class PlayerController : BaseController
    {
        [Route("HighScore")]
        [HttpGet]
        public async Task<IActionResult> HighScore()
        {
            var playerHighscore = await Mediator.Send(new GetPlayersByHighscoreQuery());
            return Ok(playerHighscore);
        }

        [Route("SetScore")]
        [HttpPost]
        public async Task<IActionResult> SetScore(int score)
        {
            await Mediator.Send(new CreatePlayerScoreCommand(score, _currentUserService.UserId));
            return Ok(_currentUserService.UserName);
        }
    }
}
