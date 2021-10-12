using DN.WebApi.Application.Abstractions.Services.Catalog;
using DN.WebApi.Domain.Constants;
using DN.WebApi.Infrastructure.Identity.Permissions;
using DN.WebApi.Shared.DTOs.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DN.WebApi.Bootstrapper.Controllers.v1
{
    public class BrandsController : BaseController
    {
        private readonly IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        [MustHavePermission(PermissionConstants.Brands.ListAll)]
        public async Task<IActionResult> GetListAsync(BrandListFilter filter)
        {
            var brands = await _service.GetBrandsAsync(filter);
            return Ok(brands);
        }

        [HttpPost]
        [MustHavePermission(PermissionConstants.Brands.Register)]
        public async Task<IActionResult> CreateAsync(CreateBrandRequest request)
        {
            return Ok(await _service.CreateBrandAsync(request));
        }

        [HttpPut]
        [MustHavePermission(PermissionConstants.Brands.Update)]
        public async Task<IActionResult> UpdateAsync(UpdateBrandRequest request, Guid id)
        {
            return Ok(await _service.UpdateBrandAsync(request, id));
        }

        [HttpDelete]
        [MustHavePermission(PermissionConstants.Brands.Remove)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var brandId = await _service.DeleteBrandAsync(id);
            return Ok(brandId);
        }
    }
}