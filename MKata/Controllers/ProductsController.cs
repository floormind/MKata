using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MKata.Models;
using MKata.Repository.Interface;

namespace MKata.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IDataRepository _fakeDataRepository;
        public ProductsController(IDataRepository fakeDataRepository)
        {
            _fakeDataRepository = fakeDataRepository;
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            try
            {
                return Ok(_fakeDataRepository.UpdateCart(product).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet]
        public IActionResult Checkout()
        {
            try
            {
                return Ok(_fakeDataRepository.GetTotal().ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}