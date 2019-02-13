using System.Linq;
using FunBooksAndVideos.Managers.Abstracts;
using FunBooksAndVideos.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.ApiControllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderManager _manager;

        public OrderController(IOrderManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public ActionResult Post([FromBody]OrderModel model)
        {
            if (!model.ItemIds.Any())
                return BadRequest("Please select item before creating the order");

            return Ok(_manager.Create(model.ItemIds));
        }
    }
}
