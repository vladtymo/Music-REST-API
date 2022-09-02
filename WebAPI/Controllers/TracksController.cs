using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        public TracksController()
        {

        }

        [HttpGet]
        //[Route("all")]           // localhost:port/api/tracks/all
        //[Route("/get-tracks")] // localhost:port/get-tracks
        public IActionResult GetAll()
        {
            return Ok(MockData.GetTrackList(5));
        }

        // Get data from route parameters
        [HttpGet]
        [Route("{id:int}")] // route parameters
        public IActionResult Get([FromRoute] int id)
        {
            if (id < 0) return NotFound();

            return Ok(MockData.GetTrack());
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

            // TODO: create a new track in db

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Track track)
        {
           // TODO: validations

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id < 0) return NotFound();

            return Ok();
        }
    }
}
