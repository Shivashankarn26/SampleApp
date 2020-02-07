using MediatR;
using SampleApp_api.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp_api.App
{
    public class InsertProgramCommandHandler : IRequestHandler<InsertProgramCommand, bool>
    {
        private readonly IProgramRepository _programRepository;

        public InsertProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<bool> Handle(InsertProgramCommand request, CancellationToken cancellationToken)
        {
            request.ProgramModel.Validate();

            return await _programRepository.AddProgram(request.ProgramModel);
        }
    }
}
