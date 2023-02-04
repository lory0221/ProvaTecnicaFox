using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaTecnicaFox.Core.Context;
using ProvaTecnicaFox.Core.Models;

namespace ProvaTecnicaFox.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationController : Controller
    {
        protected readonly SqlContext db;

        public AccomodationController(SqlContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllAccomodation()
        {
            try
            {
                List<AccomodationModel> accomodation = db.Accomodations.ToList();
                if (accomodation != null)
                {
                    return Ok(accomodation);
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
        public IActionResult GetAccomodationByLocation(string selectedLocation)
        {
            try
            {
                List<AccomodationModel> accomodation = db.Accomodations.Where(a => a.Location.Equals(selectedLocation)).ToList();
                if (accomodation != null)
                {
                    return Ok(accomodation);
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
        public IActionResult SetNewAccomodationNoRoomDefaultPrice(string name, string location)
        {
            try
            {
                AccomodationModel accomodation = new AccomodationModel()
                {
                    Name = name,
                    Location = location,
                    Rooms = { },
                    PriceList = new PriceModel()
                };

                db.Accomodations.Add(accomodation);
                db.SaveChanges();
                return Ok("Accomodation set");
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }

        [HttpPost("[action]")]
        public IActionResult SetNewAccomodation([FromBody] AccomodationModel newAccomodation)
        {
            try
            {
                db.Accomodations.Add(newAccomodation);
                db.SaveChanges();
                return Ok("Accomodation set");
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }

        [HttpPost("[action]")]

        public IActionResult UpdateAccommodation(int id, [FromBody] AccomodationModel UpdatedAccomodation)
        {
            try
            {
                AccomodationModel accomodation =  db.Accomodations.SingleOrDefault(a => a.Id.Equals(id));
                accomodation = UpdatedAccomodation;
                db.SaveChanges();
                return Ok("Accomodation set");
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
        [HttpGet("[action]")]
        public IActionResult UpdateAccommodationPriceList(int accomodationId, int priceListId )
        {
            try
            {
                AccomodationModel accomodation = db.Accomodations.SingleOrDefault(a => a.Id.Equals(accomodationId));
                accomodation.PriceList = db.Prices.SingleOrDefault(p => p.Id.Equals(priceListId));
                db.SaveChanges();
                return Ok("Accomodation set");
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
        [HttpGet("[action]")]
        public IActionResult DeleteAccomodation (int id)
        {
            try 
            {
                AccomodationModel oldAccomodation = db.Accomodations.SingleOrDefault(a => a.Id== id);
                db.Accomodations.Remove(oldAccomodation);
                return Ok();
            }    
            catch(Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
    }
}
