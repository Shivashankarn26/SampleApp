using MediatR;
using SampleApp_api.Models;

namespace SampleApp_api.App
{
    public class InsertProgramCommand : IRequest<bool>
    {
        public ProgramModel ProgramModel { get; set; }
    }
}
