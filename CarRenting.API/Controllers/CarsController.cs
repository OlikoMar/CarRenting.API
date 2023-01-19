using Microsoft.AspNetCore.Mvc;
using System.Net;
using CarRenting.Application.Queries.CarQueries;
using CarRenting.Application.Queries.CarQueries.AvailableCars;
using CarRenting.Application.Queries.CarQueries.CarAfterRent;

namespace CarRenting.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarFilterQuery _carFilterQuery;

    public CarsController(ICarFilterQuery carFilterQuery)
    {
        _carFilterQuery = carFilterQuery;
    }

    /// <summary>
    /// Get Available Cars
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(AvailableCarFilterResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAvailableCarsAsync([FromQuery] AvailableCarFilterRequest request, CancellationToken token)
    {
        var response = await _carFilterQuery.GetAvailableCars(request, token);

        if (response == null)
            return NotFound();
        return Ok(response);
    }

    /// <summary>
    /// Return Car After Rent
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AvailableCarFilterResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCarAfterRent(Guid id, CancellationToken token)
    {
        var response = await _carFilterQuery.GetCarAfterRent(new CarAfterRentFilterRequest { CarId = id }, token);

        if (response == null)
            return NotFound($"Car with Id = {id} not found");
        return Ok(response);
    }
}