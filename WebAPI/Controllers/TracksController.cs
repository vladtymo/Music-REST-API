using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Helpers;
using Core.Entities;
using Core;
using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService trackService;

        public TracksController(ITrackService trackService)
        {
            this.trackService = trackService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        //[Route("all")]           // localhost:port/api/tracks/all
        //[Route("/get-tracks")] // localhost:port/get-tracks
        public async Task<IActionResult> GetAll()
        {
            return Ok(await trackService.GetAllAsync());
        }

        // Get data from route parameters
        [HttpGet]
        [Route("{id:int}")] // route parameters
        public IActionResult Get([FromRoute] int id)
        {
            // TODO: generate excepitons

            return Ok(trackService.Get(id));
        }

        // Get data from query parameters
        //[HttpGet]
        //public IActionResult Get([FromQuery] int id) // query parameters
        //{
        //    if (id < 0) return NotFound();

        //    return Ok(new
        //    {
        //        Id = id,
        //        Name = "Blue Sky",
        //        Rating = 8.5,
        //        Duration = "2:35"
        //    });
        //}


        // Get data from body
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult Create([FromBody] TrackDTO track)
        {
            if (!ModelState.IsValid) return BadRequest();

            trackService.Create(track);

            return Ok();
        }

        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public IActionResult Update([FromBody] TrackDTO track)
        {
            // TODO: validations

            trackService.Update(track);

            return Ok();
        }

        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            trackService.Delete(id);

            return Ok();
        }
    }
}
