using MediatR;
using SampleApp_api.Models;
using SampleApp_api.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp_api.App
{
    public class GetProgramsBySeriesIdRequestHandler : IRequestHandler<GetProgramsBySeriesIdRequest, List<ProgramModel>>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramsBySeriesIdRequestHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<List<ProgramModel>> Handle(GetProgramsBySeriesIdRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.SeriesId))
            {
                return await _programRepository.GetPrograms(request.SeriesId);
            }
            else
            {
                throw new ArgumentException("SeriesId cannot be empty.");
            }
        }
    }
}
