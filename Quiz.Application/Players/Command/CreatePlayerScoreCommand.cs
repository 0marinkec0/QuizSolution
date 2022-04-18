using MediatR;
using Quiz.Application.Common.Interfaces;
using Quiz.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Application.Players.Command
{
    public record CreatePlayerScoreCommand(int highScore, int userId) : IRequest;
    public class CreatePlayerScoreCommandHandler : IRequestHandler<CreatePlayerScoreCommand>
    {
        private readonly IRepository _repository;

        public CreatePlayerScoreCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreatePlayerScoreCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync<Player>(request.userId);

            user.HighScore = request.highScore;

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
