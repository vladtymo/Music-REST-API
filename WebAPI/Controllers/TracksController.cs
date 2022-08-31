using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("all")]           // localhost:port/api/tracks/all
        //[Route("/get-tracks")] // localhost:port/get-tracks
        public IActionResult GetAll()
        {
            return Ok(new
            {
                Id = 1,
                Name = "Blue Sky",
                Rating = 8.5,
                Duration = "2:35"
            });
        }

        // Get data from query parameters
        [HttpGet]
        public IActionResult GetWithQueryParam([FromQuery] int id) // query parameters
        {
            return Ok(new
            {
                Id = id,
                Name = "Blue Sky",
                Rating = 8.5,
                Duration = "2:35"
            });
        }

        // Get data from route parameters
        //[HttpGet]
        //[Route("{id:int}")] // route parameters
        //public IActionResult GetWithRouteParam([FromRoute]int id)
        //{
        //    return Ok(new
        //    {
        //        Id = id,
        //        Name = "Blue SKy",
        //        Rating = 9.1,
        //        Duration = "2:35"
        //    });
        //}

        // Get data from body
        [HttpGet("get-next")]
        public IActionResult GetNextTrack([FromBody]Track track)
        {
            track.Id++;

            return Ok(track);
        }
    }
}
