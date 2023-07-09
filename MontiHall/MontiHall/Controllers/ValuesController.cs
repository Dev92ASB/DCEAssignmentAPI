using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MontiHall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        classes.Monti MT = new classes.Monti();
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("GetDor")]
        public IActionResult GetDor()
        {
            return Ok(MT.GetDandomSelect());
        }

        /*
        [HttpPost("NextDor")]

        public IActionResult NextDor([FromBody] string dname)
        {
            return Ok(MT.Opendor(dname));
        }*/

        [HttpPost("NextDor")]
        public IActionResult NextDor()
        {
            var form = HttpContext.Request.Form;
            if (form.TryGetValue("dname", out var dnameValue))
            {
                string dname = dnameValue.ToString();
                // Use the retrieved 'dname' value as needed
                return Ok(MT.Opendor(dname));
            }
            else
            {
                return BadRequest("Invalid request body.");
            }
        }
        [HttpPost("resetdata")]
        public ActionResult resetdata()
        {
            MT.ResetData();

            return Ok(0);

        }
        /*[HttpPost("Action")]

        public IActionResult Action([FromBody] string atype, string dorname)
        {
            return Ok(MT.Action(atype, dorname));
        }
        */
        [HttpPost("Reaptaction")]
        public IActionResult Reaptaction()
        {
            var form = HttpContext.Request.Form;
            if (form.TryGetValue("atype", out var atypeValue) && form.TryGetValue("count", out var countValue))
            {
                string atype = atypeValue.ToString();
                int count = Convert.ToInt32(countValue);
                // Use the retrieved 'atype' and 'dorname' values as needed
                 MT.RepaetAction(atype, count);
                return Ok(1);
            }
            else
            {
                return BadRequest("Invalid request body.");
            }
        }


        [HttpPost("Action")]
        public IActionResult Action()
        {
            var form = HttpContext.Request.Form;
            if (form.TryGetValue("atype", out var atypeValue) && form.TryGetValue("dorname", out var dornameValue))
            {
                string atype = atypeValue.ToString();
                string dorname = dornameValue.ToString();
                // Use the retrieved 'atype' and 'dorname' values as needed
                return Ok(MT.Action(atype, dorname));
            }
            else
            {
                return BadRequest("Invalid request body.");
            }
        }
        [HttpPost("GetAllData")]
        public IActionResult GetAllData()
        {
            return Ok(MT.returnGameData());
        }

        // POST api/values
        [HttpPost("{id}")]
        public void Post([FromBody] string value)
        {


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
