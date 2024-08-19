using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _detailService;

        public CargoDetailsController(ICargoDetailService detailService)
        {
            _detailService = detailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _detailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
        {
            CargoDetail Detail = new CargoDetail()
            {
                Barcode = dto.Barcode,
                CargoCompanyId= dto.CargoCompanyId,
                RecieverCustomer = dto.RecieverCustomer,
                SenderCustomer = dto.SenderCustomer
                
            };
            _detailService.TInsert(Detail);
            return Ok("Kargo detay başarılı bir şekilde oluşturuldu.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _detailService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetailById(int id)
        {
            _detailService.TDelete(id);
            return Ok("KArgo detay bşarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = dto.CargoDetailId,
                Barcode = dto.Barcode,
                CargoCompanyId = dto.CargoCompanyId,
                RecieverCustomer = dto.RecieverCustomer,
                SenderCustomer = dto.SenderCustomer
            };
            _detailService.TUpdate(cargoDetail);
            return Ok("Kargo detay başarılı bir şekilde güncellendi.");
        }
    }
}
