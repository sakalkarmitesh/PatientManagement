using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Data;
using PatientManagement.Models;
using System.Reflection;

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalDBContect _dbContext;

        public PatientController(HospitalDBContect dbContext)
        {
            _dbContext = dbContext; 
        }


        // GET: api/patients
        [HttpGet]
        public ActionResult<IEnumerable<PatientDTO>> GetPatients()
        {
            var patients = _dbContext.patients.Select(p => new PatientDTO()
            {
                Id = p.Id,
                PatientName = p.PatientName,
                Email = p.Email,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender
            });
            
            return Ok(patients);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetPatientById")]
        public ActionResult<IEnumerable<PatientDTO>> GetPatientById(int id)
        {
            //Badrequest - 400 - client error
            if (id <= 0)
            {
                return BadRequest();
            }
            var patient = _dbContext.patients.Where(n => n.Id == id).FirstOrDefault();
            if (patient == null)
                return NotFound($"The Student withe id {id} not found");
            var patientDTO = new PatientDTO()
            {
                Id = patient.Id,
                PatientName = patient.PatientName,
                Email = patient.Email,
                Address = patient.Address,
                PhoneNumber = patient.PhoneNumber,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender
            };

            return Ok(patientDTO);

        }
        [HttpGet("byname/{name}")]
        public ActionResult<IEnumerable<PatientDTO>> GetPatientByName(string name)
        {
            var patient = _dbContext.patients.Where(p => p.PatientName.ToLower().Contains(name.ToLower())).ToList();
            if (!patient.Any())
            {
                return NotFound();
            }
            var patientDTO = patient.Select(p => new PatientDTO
            {
                Id = p.Id,
                PatientName = p.PatientName,
                Email = p.Email,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender
            }).ToList();
            return Ok(patientDTO);
        }
        [HttpPost]
        [Route("Create")]
        public ActionResult<PatientDTO> CreatePatient([FromBody] PatientDTO model)
        {
            if(model== null)
            {
                return BadRequest();

            }
            Patient patient = new Patient
            {
                PatientName = model.PatientName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender

            };
            _dbContext.patients.Add(patient);
            _dbContext.SaveChanges();
            return CreatedAtRoute("GetPatientById", new {id = model.Id }, model);
        }
        [HttpPut]
        public ActionResult<PatientDTO> UpdatePatient([FromBody] PatientDTO model)
        {
            if (model == null || model.Id <=0)
            {
                BadRequest();
            }
            var existingPatient = _dbContext.patients.Where(p => p.Id == model.Id).FirstOrDefault();
            if (existingPatient == null)
                return NotFound();

            existingPatient.Id = model.Id;
            existingPatient.Email = model.Email;
            existingPatient.PatientName = model.PatientName;
            existingPatient.Address = model.Address;
            existingPatient.PhoneNumber = model.PhoneNumber;
            existingPatient.DateOfBirth = model.DateOfBirth;
            existingPatient.Gender = model.Gender;

            return NoContent();

        }


        [HttpPatch]
        [Route("{id:int}/updatePartial")]
        public ActionResult UpdatePatientPartial(int id, [FromBody] JsonPatchDocument<PatientDTO> patchDocument)        {
            if (patchDocument == null || id <= 0)
            {
                BadRequest();
            }
            var existingPatient = _dbContext.patients.Where(p => p.Id == id).FirstOrDefault();
            if (existingPatient == null)
                return NotFound();

            var patientDTO = new PatientDTO
            {
                Id = existingPatient.Id,
                Email = existingPatient.Email,
                PatientName = existingPatient.PatientName,
                Address = existingPatient.Address,
                PhoneNumber = existingPatient.PhoneNumber,
                DateOfBirth = existingPatient.DateOfBirth,
                Gender = existingPatient.Gender
            };
            
            patchDocument.ApplyTo(patientDTO, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            existingPatient.PatientName = patientDTO.PatientName;   
            existingPatient.Email = patientDTO.Email;
            existingPatient.Address = patientDTO.Address;
            existingPatient.PhoneNumber = patientDTO.PhoneNumber;
            existingPatient.DateOfBirth = patientDTO.DateOfBirth;
            existingPatient.Gender = patientDTO.Gender;

            _dbContext.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            var patient = _dbContext.patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            _dbContext.patients.Remove(patient);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
