using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.models;
using MagicVilla_VillaAPI.models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    
    public class VillaAPIController : ControllerBase
    {
        private readonly ApplicationDbContest _db;
        public VillaAPIController(ApplicationDbContest db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> Getvillas()
        {
            return Ok(_db.Villas.ToList());
        }



        [HttpGet("Id",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> Getvilla(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
                

            var villa = _db.Villas.FirstOrDefault(mohi => mohi.Id == Id);
            if (villa == null)
                return NotFound();

            return Ok(villa);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<VillaDTO> Create([FromBody]VillaDTO villaDTO)
        {
            
            if (villaDTO == null)
                return BadRequest();

            if (villaDTO.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            Villa model = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details= villaDTO.Details,
                Amenty= villaDTO.Amenty,
                Rate= villaDTO.Rate,
                Occuppency= villaDTO.Occuppency,
                sqft= villaDTO.sqft,
                ImageUrl=villaDTO.ImageUrl
            };
            _db.Villas.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { Id = villaDTO.Id }, villaDTO);
        }



        [HttpDelete("{Id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteVilla(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var villa = _db.Villas.FirstOrDefault(le => le.Id == Id);
            if (villa == null)
                return NotFound();

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }



        [HttpPut("{Id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateVilla(int Id, [FromBody]VillaDTO villaDTO)
        {
            if (villaDTO == null || Id != villaDTO.Id)
                return BadRequest();

            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == Id);
            //villa.Name = villaDTO.Name;
            //villa.Occuppency = villaDTO.Occuppency;

            Villa model = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Amenty = villaDTO.Amenty,
                Rate = villaDTO.Rate,
                Occuppency = villaDTO.Occuppency,
                sqft = villaDTO.sqft,
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();
        }



        [HttpPatch("{Id:int}", Name = "UpdateVillaPartial")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateVillaPartial(int Id, JsonPatchDocument<VillaDTO> patchDoc)
        {
            if (patchDoc == null || Id == 0)
                return BadRequest();

            var villa = _db.Villas.FirstOrDefault(amchich => amchich.Id == Id);
            if(villa == null)
                return NotFound();

            VillaDTO DTO = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Amenty = villa.Amenty,
                Rate = villa.Rate,
                Occuppency = villa.Occuppency,
                sqft = villa.sqft,
            };

            patchDoc.ApplyTo(DTO, ModelState);

            Villa model = new()
            {
                Id = DTO.Id,
                Name = DTO.Name,
                Details = DTO.Details,
                Amenty = DTO.Amenty,
                Rate = DTO.Rate,
                Occuppency = DTO.Occuppency,
                sqft = DTO.sqft,
            };
            _db.Villas.Update(model);
            _db.SaveChanges();

            return !ModelState.IsValid ? BadRequest(ModelState) : NoContent();
        }
    }
}