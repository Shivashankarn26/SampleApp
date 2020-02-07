using MediatR;
using SampleApp_api.Models;
using SampleApp_api.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp_api.App
{
    public class GetProgramsReportRequestHandler : IRequestHandler<GetProgramsReportRequest, List<ProgramModel>>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramsReportRequestHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<List<ProgramModel>> Handle(GetProgramsReportRequest request, CancellationToken cancellationToken)
        {
            return await _programRepository.GetPrograms();
        }
    }
}
