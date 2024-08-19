using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _operationService;

        public CargoOperationsController(ICargoOperationService operationService)
        {
            _operationService = operationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _operationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            CargoOperation Operation = new CargoOperation()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            };
            _operationService.TInsert(Operation);
            return Ok("Kargo operasyonu başarılı bir şekilde oluşturuldu.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _operationService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteCargoOperationById(int id)
        {
            _operationService.TDelete(id);
            return Ok("KArgo operasyonu bşarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId=dto.CargoOperationId,
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            };
            _operationService.TUpdate(cargoOperation);
            return Ok("Kargo operasyonu başarılı bir şekilde güncellendi.");
        }
    }
}
