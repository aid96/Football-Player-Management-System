using Football_Player_Management_System.Data;
using Football_Player_Management_System.Models;
using Football_Player_Management_System.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Football_Player_Management_System.Controllers
{
    [Route("api/PlayerAPI")]
    [ApiController]
    public class PlayerAPIController : ControllerBase
    {
       

        public PlayerAPIController()
        {
          
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PlayerDTO>> GetPlayers()
        {
            
            return Ok(PlayerInfo.playerList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlayerDTO> GetPlayers(int id)
        {
            if (id == 0)
            {
                
                return BadRequest();
            }
            var player = PlayerInfo.playerList.FirstOrDefault(u => u.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlayerDTO> CreatePlayer([FromBody] PlayerDTO playerDTO)
        {
            if (playerDTO == null)
            {
                return BadRequest(playerDTO);
            }
            if (playerDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            playerDTO.Id = PlayerInfo.playerList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            PlayerInfo.playerList.Add(playerDTO);

            return Ok(playerDTO);

        }

        [HttpPatch("{id:int}", Name = "UpdatePlayer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePlayer(int id, JsonPatchDocument<PlayerDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();

            }
            var player = PlayerInfo.playerList.FirstOrDefault(u => u.Id == id);
            if (player == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(player, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
            
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeletePlayer")]
        public IActionResult DeletePlayer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var player= PlayerInfo.playerList.FirstOrDefault(u=>u.Id== id);
            if(player == null)
            {
                return NotFound(); 
            }
            PlayerInfo.playerList.Remove(player);
            return NoContent();
        }
    }
}


