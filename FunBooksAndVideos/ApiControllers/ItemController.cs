using FunBooksAndVideos.Managers.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.ApiControllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemManager _manager;

        public ItemController(IItemManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_manager.GetItems());
        }
    }
}
