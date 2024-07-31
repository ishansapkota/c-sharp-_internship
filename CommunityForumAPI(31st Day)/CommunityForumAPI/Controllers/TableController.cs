using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService iService;

        public TableController(ITableService _iService)
        {
            iService = _iService;
        }

        [HttpPost("add-teams"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddTeams(TeamDTO team)
        {
            try
            {
                await iService.AddTeamAsync(team);
                return Ok(new { message = "The team was added to the database" });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-points/{id}"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateTeams(int id,TeamDTO team)
        {
            try
            {
                await iService.UpdateTeamAsync(id, team);
                return Ok(new { message = "The points tally has been updated!" });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("all-teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            try
            {
                var teams = await iService.GetAllTeamsAsync();
                return Ok(teams);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("team/{id}")]
        public async Task<IActionResult> GetATeam(int id)
        {
            try
            {
                var team = await iService.GetSingleTeamAsync(id);
                return Ok(team);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
