using MediatR;
using SampleApp_api.Models;
using System.Collections.Generic;

namespace SampleApp_api.App
{
    public class GetProgramsBySeriesIdRequest : IRequest<List<ProgramModel>>
    {
        public string SeriesId { get; set; }
    }
}
