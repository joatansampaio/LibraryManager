using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserService service): ControllerBase {
    private readonly IUserService _service = service;

    /// <summary>
    /// Retrieves all users in the database
    /// </summary>
    [SwaggerResponse(200, type: typeof(IEnumerable<User>))]
    [HttpGet]
    public async Task<IActionResult> GetUsers() {
        var users = await _service.GetAll();
        return Ok(users);
    }

    /// <summary>
    /// Gets a user given the id
    /// </summary>
    /// <param name="id"></param>
    [SwaggerResponse(200, type: typeof(User))]
    [SwaggerResponse(404)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id) {
        var user = await _service.GetById(id);
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }

    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    [SwaggerResponse(204)]
    [SwaggerResponse(400)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user) {
        await _service.Update(id, user);
        return NoContent();
    }

    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user"></param>
    [SwaggerResponse(201)]
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user) {
        await _service.Add(user);
        return CreatedAtAction(nameof(AddUser), new { id = user.Id }, user);
    }

    /// <summary>
    /// Removes a user from the database
    /// </summary>
    /// <param name="id"></param>
    [SwaggerResponse(204)]
    [SwaggerResponse(404)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id) {
        await _service.Delete(id);
        return NoContent();
    }
}
