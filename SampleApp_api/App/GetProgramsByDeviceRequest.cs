using MediatR;
using SampleApp_api.Models;
using System.Collections.Generic;

namespace SampleApp_api.App
{
    public class GetProgramsByDeviceRequest : IRequest<List<ProgramModel>>
    {
        public string Device { get; set; }
    }
}
