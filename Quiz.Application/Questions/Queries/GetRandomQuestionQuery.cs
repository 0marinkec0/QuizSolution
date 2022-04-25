using MediatR;
using Quiz.Application.Common.Interfaces;
using Quiz.Application.Common.Models.Questions;
using Quiz.Domain.Entites;
using Quiz.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Application.Questions.Queries
{
    public record GetRandomQuestionQuery(int category) : IRequest<QuestionModel>;
    public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionModel>
    {
        private readonly IRepository _repository;

        public GetRandomQuestionQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<QuestionModel> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
        {
            var question = (await _repository.GetListAsync<Question>())
                            .Where(a => (int)a.Category == request.category)
                            .Select(a => new QuestionModel 
                            { 
                                Answer = a.Answer,
                                AnswerOne = a.AnswerOne,
                                AnswerTwo = a.AnswerTwo,
                                AnswerThree = a.AnswerThree,
                                AnswerFour = a.AnswerFour,
                                Title = a.Title
                            })
                            .OrderBy(a => new Random().Next()).ToList();

            return question[0];
        }
    }
}
