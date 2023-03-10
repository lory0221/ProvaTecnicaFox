using Microsoft.AspNetCore.Mvc;
using ProvaTecnicaFox.Core.Context;
using ProvaTecnicaFox.Core.Models;

namespace ProvaTecnicaFox.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        protected readonly SqlContext db;

        public RoomController(SqlContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllRooms()
        {
            try
            {
                List<RoomModel> rooms = db.Rooms.ToList();
                if (rooms != null)
                {
                    return Ok(rooms);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");

            }

        }
        [HttpGet("[action]")]
        public IActionResult GetRoomsFromAccomodationId(int accomodationId)
        {
            try
            {
                List<RoomModel> rooms = db.Rooms.Where(r => r.AccomodationId.Equals(accomodationId)).ToList();
                if (rooms != null)
                {
                    return Ok(rooms);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }

        [HttpPost("[action]")]
        public IActionResult SetNewRoom([FromBody] RoomModel newRoom)
        {
            try
            {
                db.Rooms.Add(newRoom);
                db.Accomodations.SingleOrDefault(a => a.Id.Equals(newRoom.AccomodationId)).Rooms.Add(newRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
        [HttpGet("[action]")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                RoomModel oldRoom = db.Rooms.SingleOrDefault(a => a.Id== id);
                db.Rooms.Remove(oldRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
        [HttpPost("[action]")]
        public IActionResult UpdateRoom(int id, [FromBody] RoomModel updatedRoom)
        {
            try
            {
                RoomModel oldRoom = db.Rooms.SingleOrDefault(a => a.Id.Equals(id));
                oldRoom = updatedRoom;
                db.SaveChanges();
                return Ok("Accomodation set");
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
    }
}
