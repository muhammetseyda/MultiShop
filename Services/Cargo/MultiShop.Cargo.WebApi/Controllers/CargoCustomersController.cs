using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            CargoCustomer customer = new CargoCustomer()
            {
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
                Surname = dto.Surname,
            };
            _customerService.TInsert(customer);
            return Ok("Kargo müşterisi başarılı bir şekilde oluşturuldu.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteCargoCustomerById(int id)
        {
            _customerService.TDelete(id);
            return Ok("KArgo müşterisi bşarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = dto.CargoCustomerId,
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
                Surname = dto.Surname,
            };
            _customerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşterisi başarılı bir şekilde güncellendi.");
        }
    }
}
