using MediatR;

namespace DataFIFA.Application.Features.Careers.Commands.DeleteCareer
{
    public class DeleteCareerCommand : IRequest
    {
        public DeleteCareerCommand(Guid careerId)
        {
            CareerId = careerId;
        }

        public Guid CareerId { get; set; }
    }
}
