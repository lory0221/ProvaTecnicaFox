using Microsoft.AspNetCore.Mvc;
using ProvaTecnicaFox.Core.Context;
using ProvaTecnicaFox.Core.Models;

namespace ProvaTecnicaFox.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : Controller
    {
        protected readonly SqlContext db;

        public PriceListController(SqlContext db)
        {
            this.db = db;
        }


        [HttpGet("[action]")]
        public IActionResult GetAllPriceList()
        {
            try
            {
                List<PriceModel> priceLists = db.Prices.ToList();
                if (priceLists != null)
                {
                    return Ok(priceLists);
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
        public IActionResult GetPriceListFromAccomodationId(int accomodationId)
        {
            try
            {
                PriceModel priceList = db.Accomodations.SingleOrDefault(r => r.Id.Equals(accomodationId)).PriceList;
                if (priceList != null)
                {
                    return Ok(priceList);
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
        public IActionResult SetNewPriceList([FromBody] PriceModel priceList)
        {
            try
            {
                db.Add(priceList);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
        [HttpPost("[action]")]
        public IActionResult DeletePriceList(int listId)
        {
            try
            {
                PriceModel oldprice  = db.Prices.SingleOrDefault(a => a.Id == listId);
                db.Prices.Remove(oldprice);
                return Ok();
            }
            catch (Exception ex)
            {
                // si dovrebbe loggare 
                return StatusCode(500, "InternalServerError");
            }
        }
    }
}
