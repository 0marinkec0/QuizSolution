using MediatR;
using Quiz.Application.Common.Interfaces;
using Quiz.Application.Common.Models.Questions;
using Quiz.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Application.Questions.Command
{
    public record CreateQuestionCommand(QuestionModel model) : IRequest;
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand>
    {
        private readonly IRepository _repository;

        public CreateQuestionCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question()
            {
                Title = request.model.Title,
                Answer = request.model.Answer,
                AnswerOne = request.model.AnswerOne,
                AnswerTwo = request.model.AnswerTwo,
                AnswerThree = request.model.AnswerThree,
                AnswerFour = request.model.AnswerFour
            };

            await _repository.AddAsync(question);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
