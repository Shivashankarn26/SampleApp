using MediatR;
using SampleApp_api.Models;
using SampleApp_api.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp_api.App
{
    public class GetProgramsByDeviceRequestHandler : IRequestHandler<GetProgramsByDeviceRequest, List<ProgramModel>>
    {
        private readonly IProgramRepository _programRepository;
        public GetProgramsByDeviceRequestHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<List<ProgramModel>> Handle(GetProgramsByDeviceRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.Device))
            {
                DeviceType device = (request.Device.ToLower()) switch
                {
                    "tv" => DeviceType.TV,
                    "tablet" => DeviceType.TABLET,
                    "mobile" => DeviceType.MOBILE,
                    "desktop" => DeviceType.DESKTOP,
                    _ => DeviceType.NODEVICE,
                };
                if (device != DeviceType.NODEVICE)
                {
                    return await _programRepository.GetPrograms(device);
                }
                else
                {
                    throw new ArgumentException("Invalid Screen argument.");
                }
            }
            else
            {
                throw new ArgumentException("Screen cannot be empty.");
            }
        }
    }
}
