using KidEng.Application.Models;
using KidEng.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidEng.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VocabularyController : ControllerBase
    {
        private readonly IVocabularyService _vobService;

        public VocabularyController(IVocabularyService vobService)
        {
            _vobService = vobService ?? throw new ArgumentNullException(nameof(vobService));
        }

        [HttpGet(Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VocabularyModel>))]
        public async Task<ActionResult<IEnumerable<VocabularyModel>>> GetAll()
        {
            var lstVob = await _vobService.GetAll();
            return Ok(lstVob);
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VocabularyModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VocabularyModel>> GetById(int id)
        {
            var vob = await _vobService.GetById(id);
            if (vob == null)
                return NotFound();
            return Ok(vob);
        }

        [HttpPost(Name = "Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VocabularyModel))]
        public async Task<ActionResult<int>> Add([FromBody] VocabularyModel model)
        {
            var id = await _vobService.Add(model);
            return CreatedAtRoute("GetById", new { Id = id }, model);
        }

        [HttpPut(Name = "Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] VocabularyModel model)
        {
            await _vobService.Update(model);
            return Ok();
        }

        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _vobService.Delete(id);
            return Ok();
        }
    }
}
