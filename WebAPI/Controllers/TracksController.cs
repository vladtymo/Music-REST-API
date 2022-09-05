using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using DataAccess.Models;
using DataAccess;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
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
        [HttpPost]
        public IActionResult Create([FromBody]Track track)
        {
            if (!ModelState.IsValid) return BadRequest();

            trackService.Create(track);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Track track)
        {
            // TODO: validations

            trackService.Update(track);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            trackService.Delete(id);

            return Ok();
        }
    }
}
