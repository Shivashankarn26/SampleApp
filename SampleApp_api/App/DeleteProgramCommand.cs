using MediatR;
using SampleApp_api.Models;

namespace SampleApp_api.App
{
    public class DeleteProgramCommand : IRequest<int>
    {
        public ProgramModel ProgramModel { get; set; }
    }
}
