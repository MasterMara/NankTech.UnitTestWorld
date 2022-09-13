using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NankTech.SimpleLibrary.API.Data.Models;
using NankTech.SimpleLibrary.API.Services;

namespace NankTech.SimpleLibrary.API.Controllers;

[Route("api/v1.0/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
    {
        _service = service;
    }

    // GET api/books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
        var items = _service.GetAll();
        return Ok(items);
    }

    // GET api/books/5
    [HttpGet("{id}")]
    public ActionResult<Book> GetById(Guid id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    // POST api/books
    [HttpPost]
    public ActionResult Post([FromBody] Book value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var item = _service.Add(value);
        return CreatedAtAction("Get", new { id = item.Id }, item);
    }

    // DELETE api/books/5
    [HttpDelete("{id}")]
    public ActionResult Remove(Guid id)
    {
        var existingItem = _service.GetById(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        _service.Remove(id);
        return Ok();
    }
}