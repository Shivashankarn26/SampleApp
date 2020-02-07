using MediatR;
using SampleApp_api.Models;
using System.Collections.Generic;

namespace SampleApp_api.App
{
    public class GetProgramsByDateRequest : IRequest<List<ProgramModel>>
    {
        public string Date { get; set; }
    }
}
