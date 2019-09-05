using AutoMapper;
using GP.API.Entities;
using GP.API.Models;
using GP.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class ItemsController : Controller
    {
        private IItemRepository _itemRepository;
        private ILogger<ItemsController> _logger;
        private readonly APIConfig _config;
        private readonly IHttpContextAccessor _accessor;
        private readonly HttpContext _context;
        private readonly GPSysContext _dbcontext;

        public ItemsController(IItemRepository itemRepository, ILogger<ItemsController> logger, IOptions<APIConfig> config, GPSysContext dbcontext, IHttpContextAccessor accessor)
        {
            _itemRepository = itemRepository;
            _logger = logger;
            _config = config.Value;
            _dbcontext = dbcontext;
            _accessor = accessor;
            _context = accessor.HttpContext;
        }

        [HttpGet(), MapToApiVersion("1.0")]
        public IActionResult GetItems()
        {
            var itemEntities = _itemRepository.GetItems();

            var itemResults = Mapper.Map<List<ItemDto>>(itemEntities);

            return Ok(itemResults);
        }

        [HttpGet("{itemnmbr}"), MapToApiVersion("1.0")]
        public IActionResult GetItem(string Itemnmbr)
        {
            var item = _itemRepository.GetItem(Itemnmbr);

            if (item == null)
            {
                return NotFound();
            }

            var itemResult = Mapper.Map<ItemDto>(item);

            return Ok(itemResult);
        }

    }
}
