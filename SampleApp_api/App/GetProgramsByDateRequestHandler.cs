using MediatR;
using SampleApp_api.Models;
using SampleApp_api.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp_api.App
{
    public class GetProgramsByDateRequestHandler : IRequestHandler<GetProgramsByDateRequest, List<ProgramModel>>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramsByDateRequestHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<List<ProgramModel>> Handle(GetProgramsByDateRequest request, CancellationToken cancellationToken)
        {
            DateTime date = GetDateTime(request.Date);
            return await _programRepository.GetPrograms(date);
        }

        private DateTime GetDateTime(string date)
        {
            try
            {
                return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(date + " is invalid date. Accepted date format YYYYMMDD : " + ex.Message);
            }
        }
    }
}
