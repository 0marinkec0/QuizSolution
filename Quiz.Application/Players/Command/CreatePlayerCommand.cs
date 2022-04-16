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
    public record CreatePlayerCommand(string UserName)  : IRequest;
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand>
    {
        private readonly IRepository _repository;

        public CreatePlayerHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player()
            {
                UserName = request.UserName
            };

            await _repository.AddAsync(player);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
