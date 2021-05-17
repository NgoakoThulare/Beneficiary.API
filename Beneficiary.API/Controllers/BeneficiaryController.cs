using AutoMapper;
using Beneficiary.Contracts.DTOs;
using Beneficiary.Core.Repository;
using Beneficiary.DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beneficiary.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBeneficiaryRepository _beneficiaryRepo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="beneficiaryRepo"></param>
        public BeneficiaryController(IMapper mapper, IBeneficiaryRepository beneficiaryRepo)
        {
            this._mapper = mapper;
            this._beneficiaryRepo = beneficiaryRepo;
        }

        /// <summary>
        /// Returns a list of beneficiaries.
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiaryDto>))]
        public async Task<IActionResult> GetBeneficiaries()
        {
            var beneficiaries = await this._beneficiaryRepo.GetAll();

            var beneficiariesDTO = new List<BeneficiaryDto>();

            foreach (var beneficiary in beneficiaries)
                beneficiariesDTO.Add(this._mapper.Map<BeneficiaryDto>(beneficiary));

            return Ok(beneficiariesDTO);
        }

        /// <summary>
        /// Gets individual beneficiary.
        /// </summary>
        /// <param name="id"> The Id of beneficiary. </param>
        /// <returns></returns>
        [HttpGet("View/{id:int}", Name = "GetBeneficiary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BeneficiaryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetBeneficiary(int id)
        {
            var beneficiary = await this._beneficiaryRepo.Get(id);
            if (beneficiary == null)
                return NotFound();

            var beneficiaryDto = _mapper.Map<BeneficiaryDto>(beneficiary);

            return Ok(beneficiaryDto);
        }

        /// <summary>
        /// Creates a beneficiary
        /// </summary>
        /// <param name="beneficiary">Beneficiary input object</param>
        /// <returns></returns>

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BeneficiaryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBeneficiary([FromBody] BeneficiaryDto beneficiary)
        {
            if (beneficiary == null)
                return BadRequest(ModelState);

            var ben = _mapper.Map<BeneficiaryModel>(beneficiary);

            if (!await this._beneficiaryRepo.Create(ben))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record { ben.Name }");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return CreatedAtRoute("GetBeneficiary", new
            {
                id = ben.Id
            }, ben);
        }

        /// <summary>
        /// Updates Beneficiary.
        /// </summary>
        /// <param name="id">Beneficiary id.</param>
        /// <param name="beneficiary">Beneficiary object.</param>
        /// <returns></returns>
        [HttpPatch("Edit/{id:int}", Name = "UpdateBeneficiary")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBeneficiary(int id, [FromBody] BeneficiaryDto beneficiary)
        {
            if (beneficiary == null || id != beneficiary.Id)
                return BadRequest(ModelState);

            var ben = _mapper.Map<BeneficiaryModel>(beneficiary);

            if (!await this._beneficiaryRepo.Update(ben))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record { ben.Name }");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Removes beneficiary.
        /// </summary>
        /// <param name="id">Beneficiary id.</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteBeneficiary(int id)
        {
            if (!await this._beneficiaryRepo.Exists(id))
                return NotFound();

            var beneficiary = await this._beneficiaryRepo.Get(id);

            if (!await this._beneficiaryRepo.Delete(beneficiary))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record { beneficiary }");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }
    }
}
