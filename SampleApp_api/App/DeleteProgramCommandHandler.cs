using MediatR;
using SampleApp_api.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp_api.App
{
    public class DeleteProgramCommandHandler : IRequestHandler<DeleteProgramCommand, int>
    {
        private readonly IProgramRepository _programRepository;

        public DeleteProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<int> Handle(DeleteProgramCommand request, CancellationToken cancellationToken)
        {
            request.ProgramModel.Validate();

            return await _programRepository.DeleteProgram(request.ProgramModel);
        }
    }
}
