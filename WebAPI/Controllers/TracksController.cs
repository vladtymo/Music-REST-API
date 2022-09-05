using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using DataAccess.Models;
using DataAccess;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly MusicCollectionDb context;

        public TracksController(MusicCollectionDb context)
        {
            this.context = context;
        }

        [HttpGet]
        //[Route("all")]           // localhost:port/api/tracks/all
        //[Route("/get-tracks")] // localhost:port/get-tracks
        public IActionResult GetAll()
        {
            var tracks = context.Tracks.ToList();

            return Ok(tracks);
        }

        // Get data from route parameters
        [HttpGet]
        [Route("{id:int}")] // route parameters
        public IActionResult Get([FromRoute] int id)
        {
            if (id < 0) return NotFound();

            var track = context.Tracks.Find(id);

            if (track == null) return NotFound();

            return Ok(track);
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

            context.Tracks.Add(track);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Track track)
        {
            // TODO: validations

            context.Tracks.Update(track);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id < 0) return NotFound();

            var track = context.Tracks.Find(id);

            if (track == null) return NotFound();

            context.Tracks.Remove(track);
            context.SaveChanges();

            return Ok();
        }
    }
}
