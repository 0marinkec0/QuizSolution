using MediatR;
using Quiz.Application.Common.Interfaces;
using Quiz.Application.Common.Models.Players;
using Quiz.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Application.Players.Queries
{
    public record GetPlayersByHighscoreQuery() : IRequest<List<PlayerViewModel>>;
    public class GetPlayerByHighscoreQueryHandler : IRequestHandler<GetPlayersByHighscoreQuery, List<PlayerViewModel>>
    {
        private readonly IRepository _repository;

        public GetPlayerByHighscoreQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PlayerViewModel>> Handle(GetPlayersByHighscoreQuery request, CancellationToken cancellationToken)
        {
            var list = (await _repository.GetListAsync<Player>())
                .OrderByDescending(a => a.HighScore)
                .Select(b => new PlayerViewModel
                {
                    UserName = b.UserName,
                    HighScore = b.HighScore
                }).ToList();

            return list;
        }
    }
}
