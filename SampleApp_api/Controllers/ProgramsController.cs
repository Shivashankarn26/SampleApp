using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApp_api.App;
using SampleApp_api.Models;

namespace SampleApp_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [Produces("application/json", Type = typeof(List<ProgramModel>))]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetProgramsReportRequest());
            return Ok(result);
        }

        [HttpGet("byseriesid/{seriesId}", Name = nameof(GetbySeriesId))]
        [Produces("application/json", Type = typeof(List<ProgramModel>))]
        public async Task<IActionResult> GetbySeriesId(string seriesId)
        {
            var result = await _mediator.Send(new GetProgramsBySeriesIdRequest { SeriesId = seriesId });
            return Ok(result);
        }

        [HttpGet("byscreen/{screen}", Name = nameof(GetbyScreen))]
        [Produces("application/json", Type = typeof(List<ProgramModel>))]
        public async Task<IActionResult> GetbyScreen(string screen)
        {
            var result = await _mediator.Send(new GetProgramsByDeviceRequest { Device = screen });
            return Ok(result);
        }

        [HttpGet("bydate/{date}", Name = nameof(GetbyDate))]
        [Produces("application/json", Type = typeof(List<ProgramModel>))]
        public async Task<IActionResult> GetbyDate(string date)
        {
            var result = await _mediator.Send(new GetProgramsByDateRequest { Date = date });
            return Ok(result);
        }

        [HttpPost("", Name = nameof(AddProgram))]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> AddProgram([FromBody] ProgramModel programModel)
        {
            var result = await _mediator.Send(new InsertProgramCommand { ProgramModel = programModel });
            return Ok(result);
        }

        [HttpPatch("", Name = nameof(DeleteProgram))]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteProgram([FromBody] ProgramModel programModel)
        {
            var result = await _mediator.Send(new DeleteProgramCommand { ProgramModel = programModel });
            return Ok(result);
        }
    }
}