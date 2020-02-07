using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp_api.Models
{
    public class ProgramModel
    {
        public string SeriesId { get; set; }
        public DateTime Date { get; set; }
        public string Screen { get; set; }
        public int Views { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(SeriesId))
            {
                throw new ArgumentNullException("SeriesId is required.");
            }
            if (string.IsNullOrWhiteSpace(Screen))
            {
                throw new ArgumentNullException("Screen is required.");
            }
        }
    }
}
