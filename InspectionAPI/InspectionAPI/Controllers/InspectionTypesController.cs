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
    public class InspectionTypesController : ControllerBase
    {
        private readonly IInspectionTypeRepository inspectionTypeRepository;

        public InspectionTypesController(IInspectionTypeRepository inspectionTypeRepository)
        {
            this.inspectionTypeRepository = inspectionTypeRepository;
        }
        [HttpGet]
        public IActionResult GetAllInspectionTypes()
        {
            try
            {
                return Ok(inspectionTypeRepository.GetAllInspectionTypes().ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetAllInspectionTypessById(int id)
        {
            try
            {
                var inspectionTypeId = inspectionTypeRepository.GetInspectionTypeById(id);
                if (inspectionTypeId == null)
                    return NotFound();
                return Ok(inspectionTypeId);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Invalid Inspection Type,please enter a valid inspection");
            }
        }
        [HttpPost]
        public IActionResult AddInspectionType(InspectionType inspectionType)
        {
            try
            {
                if (inspectionType == null)
                    return BadRequest();
                var addInspectionType = inspectionTypeRepository.AddInspectionType(inspectionType);
                return CreatedAtAction(nameof(GetAllInspectionTypessById),
                   new { id = addInspectionType.Id }, addInspectionType);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error when adding a new status");
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateStatus(int id, InspectionType inspectionType)
        {
            try
            {
                if (id != inspectionType.Id)
                    return BadRequest("ProductId Mismatched");

                var inspectionId = inspectionTypeRepository.GetInspectionTypeById(id);
                if (inspectionId == null)
                    return NotFound($"Product with Id = {id} not found");

                return Ok(inspectionTypeRepository.UpdateInspectionType(inspectionType));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteInspectionType(int id)
        {
            try
            {
                var statusId = inspectionTypeRepository.GetInspectionTypeById(id);
                if (statusId == null)
                    return NotFound();
                return Ok(inspectionTypeRepository.DeleteInspectionType(id));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error when deleting a the inspection type,please try again");
            }

        }
    }
}
