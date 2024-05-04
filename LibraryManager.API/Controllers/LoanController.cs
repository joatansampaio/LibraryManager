using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LoanController(ILoanService service) : ControllerBase {
    private readonly ILoanService _service = service;

    /// <summary>
    /// Check out a book
    /// </summary>
    /// <param name="loan"></param>
    [SwaggerResponse(200)]
    [SwaggerResponse(400)]
    [HttpPost("check-out")]
    public async Task<IActionResult> CheckOut(CreateLoanInputModel loan) {
        var result = await _service.CheckOut(loan);
        return result ? Ok() : BadRequest();
    }

    /// <summary>
    /// Check in a book
    /// </summary>
    /// <param name="id"></param>
    [SwaggerResponse(200)]
    [SwaggerResponse(400)]
    [HttpPost("{id}/check-in")]
    public async Task<IActionResult> CheckIn(int id) {
        var result = await _service.CheckIn(id);
        return result ? Ok() : BadRequest();
    }

    /// <summary>
    /// Get all loans
    /// </summary>
    [SwaggerResponse(200, type: typeof(IEnumerable<Loan>))]
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var loans = await _service.GetAll();
        return Ok(loans);
    }

    /// <summary>
    /// Retrieve a loan by id
    /// </summary>
    /// <param name="id"></param>
    [SwaggerResponse(200, type: typeof(Loan))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
        var loan = await _service.GetById(id);
        return loan is not null ? Ok(loan) : NotFound();
    }
}
