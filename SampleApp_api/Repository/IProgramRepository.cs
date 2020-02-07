using SampleApp_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp_api.Repository
{
    public interface IProgramRepository
    {
        Task<List<ProgramModel>> GetPrograms();
        Task<List<ProgramModel>> GetPrograms(string SeriesId);
        Task<List<ProgramModel>> GetPrograms(DateTime date);
        Task<List<ProgramModel>> GetPrograms(DeviceType deviceType);

        Task<bool> AddProgram(ProgramModel programModel);
        Task<int> DeleteProgram(ProgramModel programModel);
    }
}
