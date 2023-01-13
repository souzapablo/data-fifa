using DataFIFA.Core.Constants;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;
using System.Net;

namespace DataFIFA.Application.Features.Careers.Commands.DeleteCareer
{
    public class DeleteCareerCommandHandler : IRequestHandler<DeleteCareerCommand, Unit>
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IMessageHandler _messageHandler;

        public DeleteCareerCommandHandler(ICareerRepository careerRepository, IMessageHandler messageHandler)
        {
            _careerRepository = careerRepository;
            _messageHandler = messageHandler;
        }

        public async Task<Unit> Handle(DeleteCareerCommand request, CancellationToken cancellationToken)
        {
            var career = await _careerRepository.GetByIdAsync(request.CareerId);

            if (career is null)
            {
                _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.BadRequest, ErrorConstants.CareerNotFound(request.CareerId)));
                return Unit.Value;
            }

            await _careerRepository.Delete(career);

            return Unit.Value;
        }
    }
}
