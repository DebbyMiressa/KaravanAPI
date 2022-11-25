using Karavan.Data;
using Karavan.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaravanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranch _Branch;
        public BranchController(IBranch Branch)
        {
            _Branch = Branch;
        }

        [HttpGet]
        public IActionResult GetBranches()
        {
            IQueryable<Branch> model = _Branch.GetBranches;
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranch(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Branch model = await _Branch.GetBranch(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Branch _branch)
        {
            if (_branch == null)
            {
                return BadRequest();
            }
            POJO model = await _Branch.SaveBranch(_branch);
            if (model == null)
            {
               return NotFound();
            }
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            POJO model = await _Branch.DeleteBranch(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
