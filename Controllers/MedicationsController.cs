using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartMedDB.Models;
using SmartMedDB.Data;
using AutoMapper;
using SmartMedDB.DTOs;

namespace SmartMedDB.Controllers
{
    [Route("api/medications")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly ISmartMedDBRepo _repository;
        // used to map between the DTOs and their matching objects
        private readonly IMapper _mapper;

        public MedicationsController(ISmartMedDBRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/medications
        [HttpGet]
        public ActionResult<IEnumerable<MedicationReadDto>> GetAllMedications()
        {
            var medications = _repository.GetAllMedications();

            if (medications != null)
            {
                return Ok(_mapper.Map<IEnumerable<MedicationReadDto>>(medications));
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/medications/{id}
        [HttpGet("{id}", Name="GetMedicationById")]
        public ActionResult<MedicationReadDto> GetMedicationById(int id)
        {
            var medication = _repository.GetMedicationById(id);

            if (medication != null)
            {
                return Ok(_mapper.Map<MedicationReadDto>(medication));
            }
            else
            {
                return NotFound();
            }            
        }

        // POST api/medications/
        [HttpPost]
        public ActionResult<MedicationReadDto> AddMedication(MedicationWriteDto medicationWrite)
        {
            var medicationModel = _mapper.Map<Medication>(medicationWrite);
            _repository.CreateMedication(medicationModel);

            var medicationReadDto = _mapper.Map<MedicationReadDto>(medicationModel);

            return CreatedAtRoute(nameof(GetMedicationById),
                                    new {Id = medicationReadDto.Id},
                                    medicationReadDto);
        }

        // DELETE api/medications/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMedication(int id)
        {
           var medication = _repository.GetMedicationById(id);

            if (medication != null)
            {
                _repository.DeleteMedicationById(id);
                _repository.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }   
        }
    }
}