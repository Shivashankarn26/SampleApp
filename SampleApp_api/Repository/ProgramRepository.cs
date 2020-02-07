using SampleApp_api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp_api.Repository
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly string inputFile = @"~\..\programdata.csv";
        public async Task<bool> AddProgram(ProgramModel programModel)
        {
            try
            {
                string data = $@"{programModel.SeriesId},{programModel.Date.ToString("yyyyMMdd")},{programModel.Screen},{programModel.Views}" + Environment.NewLine;
                await File.AppendAllTextAsync(inputFile, data);
                //File.AppendAllText(inputFile, data);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteProgram(ProgramModel programModel)
        {
            List<ProgramModel> programs = await GetPrograms();
            var newlist = programs.Where(p => p.SeriesId != programModel.SeriesId
                                        && p.Date != programModel.Date
                                        && p.Screen != programModel.Screen
                                        && p.Views != programModel.Views).Select(p => p).ToList();
            if (programs.Count == newlist.Count)
            {
                return 0;
            }
            else
            {
                StringBuilder sb = new StringBuilder("seriesId,date,screen,views" + Environment.NewLine);

                foreach (ProgramModel item in newlist)
                {
                    sb.Append($@"{item.SeriesId},{item.Date.ToString("yyyyMMdd")},{item.Screen},{item.Views}" + Environment.NewLine);
                }

                await File.WriteAllTextAsync(inputFile, sb.ToString());

                return programs.Count - newlist.Count;
            }
        }

        public async Task<List<ProgramModel>> GetPrograms()
        {
            using (StreamReader sr = new StreamReader(inputFile))
            {
                List<ProgramModel> programs = new List<ProgramModel>();
                string[] allData = sr.ReadToEnd().Split('\n');
                for (int i = 1; i < allData.Length - 1; i++)
                {
                    programs.Add(GetProgramModel(allData[i].Split(',')));
                }
                return programs;
            }
        }

        public async Task<List<ProgramModel>> GetPrograms(string SeriesId)
        {
            List<ProgramModel> programs = await GetPrograms();
            return programs.Where(p => p.SeriesId == SeriesId).Select(p => p).ToList();
        }

        public async Task<List<ProgramModel>> GetPrograms(DateTime date)
        {
            List<ProgramModel> programs = await GetPrograms();
            return programs.Where(p => p.Date == date).Select(p => p).ToList();
        }

        public async Task<List<ProgramModel>> GetPrograms(DeviceType deviceType)
        {
            List<ProgramModel> programs = await GetPrograms();

            string screen = string.Empty;
            screen = deviceType switch
            {
                DeviceType.TV => "tv",
                DeviceType.TABLET => "tablet",
                DeviceType.MOBILE => "mobile",
                _ => "desktop",
            };
            return programs.Where(p => p.Screen.ToLower() == screen).Select(p => p).ToList();
        }

        private ProgramModel GetProgramModel(string[] program)
        {
            try
            {
                return new ProgramModel
                {
                    SeriesId = program[0] ?? string.Empty,
                    Date = DateTime.ParseExact(program[1] ?? DateTime.Now.ToString("yyyyMMdd"), "yyyyMMdd", CultureInfo.InvariantCulture),
                    Screen = program[2] ?? string.Empty,
                    Views = Convert.ToInt32(program[3] ?? "0")
                };
            }
            catch (Exception ex)
            {
                throw new Exception(program[0]);
            }
        }
    }
}
