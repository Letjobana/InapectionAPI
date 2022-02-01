using InspectionAPI.Models;
using InspectionAPI.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionRepository inspectionRepository;

        public InspectionsController(IInspectionRepository inspectionRepository)
        {
            this.inspectionRepository = inspectionRepository;
        }
        [HttpGet]
        public IActionResult GetAllInspections()
        {
            try
            {
                return Ok(inspectionRepository.GetAllInspections().ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetAllInspectionsById(int id)
        {
            try
            {
                var inspectionId = inspectionRepository.GetInspectionById(id);
                if (inspectionId == null)
                    return NotFound();
                return Ok(inspectionId);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Invalid Inspection,please enter a valid inspection");
            }
        }
        [HttpPost]
        public IActionResult AddInspection(Inspection inspection)
        {
            try
            {
                if (inspection == null)
                    return BadRequest();
                var addInspection = inspectionRepository.AddInspection(inspection);
                return CreatedAtAction(nameof(GetAllInspectionsById),
                    new { id = inspection.Id }, inspection);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error when adding a new status");
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateStatus(int id, Inspection inspection)
        {
            try
            {
                if (id != inspection.Id)
                    return BadRequest("ProductId Mismatched");

                var inspectionId = inspectionRepository.GetInspectionById(id);
                if (inspectionId == null)
                    return NotFound($"Product with Id = {id} not found");

                return Ok(inspectionRepository.UpdateInspection(inspection));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating the inspection");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteInspection(int id)
        {
            try
            {
                var statusId = inspectionRepository.GetInspectionById(id);
                if (statusId == null)
                    return NotFound();
                return Ok(inspectionRepository.DeleteInspection(id));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error when deleting a the inspection type,please try again");
            }

        }

    }
}
