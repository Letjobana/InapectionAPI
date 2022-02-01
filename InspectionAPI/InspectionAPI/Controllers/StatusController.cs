using InspectionAPI.Models;
using InspectionAPI.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }
        [HttpGet]
        public IActionResult GetAllStatus()
        {
            try
            {
                return Ok(statusRepository.GetAllStatuses().ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetAllStatusById(int id)
        {
            try
            {
                var statusId = statusRepository.GetStatusById(id);
                if (statusId == null)
                    return NotFound();
                return Ok(statusId);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Invalid status,please enter a valid status");
            }
        }
        [HttpPost]
        public IActionResult AddStatus(Status status)
        {
            try
            {
                if (status == null)
                    return BadRequest();
                var addStatus = statusRepository.AddStatus(status);
                return CreatedAtAction(nameof(GetAllStatusById),
                   new { id = addStatus.Id }, addStatus);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error when adding a new status");
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateStatus(int id, Status status)
        {
            try
            {
                if (id != status.Id)
                    return BadRequest("ProductId Mismatched");

                var statusId = statusRepository.GetStatusById(id);
                if (statusId == null)
                    return NotFound($"Product with Id = {id} not found");

                return Ok(statusRepository.UpdateStatus(status));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteStatus(int id)
        {
            try
            {
                var statusId = statusRepository.GetStatusById(id);
                if (statusId == null)
                    return NotFound();
                return Ok(statusRepository.DeleteStatus(id));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error when deleting a status,please try again");
            }

        }
    }
}
