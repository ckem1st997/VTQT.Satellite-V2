using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.API.Models;
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
        public IActionResult GetPaginatedList(int start, int length, [FromQuery(Name = "search[value]")] string q)
        {
            var list = _subscriber.GetTable(q, start, length);
            return Ok(new { data = list.Data, recordsTotal = list.Count, recordsFiltered = list.Count });
        }


        /// <summary>
        /// lấy bản ghi theo id
        /// </summary>
        /// <param name="id">khoá chinh</param>
        /// <returns>bản ghi theo id</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _subscriber.GetByIdAsync(id));
        }

        /// <summary>
        /// thêm mới bản ghi
        /// </summary>
        /// <param name="subModel">model binding theo kiểu formdata</param>
        /// <returns>kết quả=> 1: thành công, 0: thất bại</returns>
        [HttpPut]
        public async Task<IActionResult> Add([FromForm] SubModel subModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Subscriber>(subModel);
                return Ok(await _subscriber.InsertAsync(model));
            }
            else
                return Ok(0);

        }
        /// <summary>
        /// xoá bản ghi theo id
        /// </summary>
        /// <param name="id">khoá chính</param>
        /// <returns>kết quả=> 1: thành công, 0: thất bại</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _subscriber.DeletesAsync(id));
        }


        /// <summary>
        /// cập nhật bản ghi theo id
        /// </summary>
        /// <param name="subModel">model binding theo kiểu formdata</param>
        /// <param name="id">khoá chính</param>
        /// <returns>kết quả=> 1: thành công, 0: thất bại</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromForm] SubModel subModel, int id)
        {
            var model = await _subscriber.GetByIdAsync(id);
            if (!id.Equals(subModel.Id) || model == null)
                return Ok(0);
            subModel.ReferenceId = model.ReferenceId;
            subModel.LastSync = model.LastSync;
            // mapper
            model = _mapper.Map<Subscriber>(subModel);
            return Ok(await _subscriber.UpdateAsync(model));
        }
    }
}
