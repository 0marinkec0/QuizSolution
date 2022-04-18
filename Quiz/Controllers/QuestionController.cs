using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Common.Models.Questions;
using Quiz.Application.Questions.Command;
using Quiz.Application.Questions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.UI.Controllers
{
    public class QuestionController : BaseController
    {
        [Route("AddQuestion")]
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionModel model)
        {
            await Mediator.Send(new CreateQuestionCommand(model));
            return Ok();
        }

        [Route("RandomQuestion")]
        [HttpGet]
        public async Task<IActionResult> GetRandomQuestion()
        {
            var question = await Mediator.Send(new GetRandomQuestionQuery());
            return Ok(question);
        }
    }
}
