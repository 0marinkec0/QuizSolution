using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Application.Common.Interfaces;

namespace Quiz.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
        protected ICurrentUserService _currentUserService => HttpContext.RequestServices.GetService<ICurrentUserService>();
    }
}
