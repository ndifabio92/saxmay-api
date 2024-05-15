using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saxmay.Business.Interfaces;
using Saxmay.Entities;
using Saxmay.Entities.Base;
using Saxmay.Entities.Dtos;
using System.Net;

namespace Saxmay.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBusiness _activityBusiness;

        public ActivityController(IActivityBusiness activityBusiness)
        {
            _activityBusiness = activityBusiness;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Activity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Created(ActivityDto activity)
        {
            var result = await _activityBusiness.Created(activity);
            return Ok(result);
        }

        [HttpGet("/{id:int}")]
        [ProducesResponseType(typeof(Activity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _activityBusiness.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ActivityDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activityBusiness.GetAll();
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Activity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Updated(ActivityDto activity)
        {
            var result = await _activityBusiness.Updated(activity);
            return Ok(result);
        }

        [HttpDelete("/{id:int}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _activityBusiness.Delete(id);
            return Ok(result);
        }
    }
}
