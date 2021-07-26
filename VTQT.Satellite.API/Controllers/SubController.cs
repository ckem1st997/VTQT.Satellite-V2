using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VTQT.Satellite.Entity.Entity;

using VTQT.Satellite.Service.SatelliteService.Repository;
using VTQT.Satellite.ShareMVC.Models;

namespace VTQT.Satellite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubscriberServer _subscriber;

        public SubController(ISubscriberServer unitOfWork, IMapper mapper)
        {
            _subscriber = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// lấy ra số lượng bản ghi
        /// </summary>
        /// <param name="start">số trang</param>
        /// <param name="length"> số hàng</param>
        /// <param name="q">từ khoá tìm kiếm</param>
        /// <returns>danh sách bản ghi và tổng số bản ghi</returns>
        [HttpGet("GetPaginatedList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPaginatedList(int start, int length, [FromQuery(Name = "search[value]")] string q)
        {
            var list = _subscriber.GetTable(q, start, length);
            if (list.Data == null || list.Count < 1)
                return BadRequest();
            return Ok(new { data = list.Data, recordsTotal = list.Count, recordsFiltered = list.Count });
        }


        /// <summary>
        /// lấy bản ghi theo id
        /// </summary>
        /// <param name="id">khoá chính</param>
        /// <returns>bản ghi theo id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(SubModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var item = await _subscriber.GetByIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<SubModel>(item));
            }
            return NotFound();
        }

        /// <summary>
        /// thêm mới bản ghi
        /// </summary>
        /// <param name="subModel">model binding theo kiểu formdata</param>
        /// <returns>kết quả=> 1: thành công, 0: thất bại</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromForm] SubModel subModel)
        {
            var model = _mapper.Map<Subscriber>(subModel);
            return Ok(await _subscriber.InsertAsync(model));

        }
        /// <summary>
        /// xoá bản ghi theo id
        /// </summary>
        /// <param name="id">khoá chính</param>
        /// <returns>kết quả=> 1: thành công, 0: thất bại</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _subscriber.GetByIdAsync(id);
            if (item == null || id < 1)
                return NotFound(new { Message = $"Item with id {id} not found." });
            return Ok(await _subscriber.DeletesAsync(id));
        }


        /// <summary>
        /// cập nhật bản ghi theo id
        /// </summary>
        /// <param name="subModel">model binding theo kiểu formdata</param>
        /// <param name="id">khoá chính</param>
        /// <returns>kết quả=> 1: thành công, 0: thất bại</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromForm] SubModel subModel, int id)
        {
            var model = await _subscriber.GetByIdAsync(id);
            if (!id.Equals(subModel.Id) || model == null)
                return NotFound(new { Message = $"Item with id {subModel.Id} not found." });
            subModel.ReferenceId = model.ReferenceId;
            subModel.LastSync = model.LastSync;
            model = _mapper.Map<Subscriber>(subModel);
            return Ok(await _subscriber.UpdateAsync(model));

        }
    }
}
