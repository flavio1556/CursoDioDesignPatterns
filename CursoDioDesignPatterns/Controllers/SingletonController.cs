using CursoDioDesignPatterns.Infra.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDioDesignPatterns.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    
    public class SingletonController : ControllerBase
    {
        private readonly SingletonContainer _singletonContainer;
        public SingletonController(SingletonContainer singletonContainer)
        {
            _singletonContainer = singletonContainer;
        }
        [HttpGet]
        public IActionResult get()
        {
            //var singleton = _singletonContainer;
            return Ok(_singletonContainer);
        }
    }
}
