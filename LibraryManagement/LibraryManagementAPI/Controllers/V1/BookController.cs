using AutoMapper;
using LibraryManagementAPI.Contracts;
using LibraryManagementAPI.Contracts.V1.Requests;
using LibraryManagementAPI.Contracts.V1.Responses;
using LibraryManagementAPI.Domains;
using LibraryManagementAPI.Extensions;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion(ApiRoutes.V1)]
    public class BookController:Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRoutes.Books.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(_mapper.Map<List<BookResponse>>(books));  
        }

        [HttpGet]
        [Route(ApiRoutes.Books.GetById)]
        public async Task<IActionResult> GetById([FromRoute] Guid bookId)
        {
            var book = await _bookService.GetByIdAsync(bookId);
            if (book == null)
                return NotFound();

            return Ok(_mapper.Map<BookResponse>(book));
        }

        [HttpPost]
        [Route(ApiRoutes.Books.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest bookRequest)
        {
            var currentDateTime = DateTime.UtcNow;
            
            var book = _mapper.Map<Book>(bookRequest);
            book.Created = currentDateTime;
            book.Modified = currentDateTime;

            if (book.Id == Guid.Empty)
            {
                book.Id = Guid.NewGuid();
                book.UserId = HttpContext.GetUserId();
            }

            var result = await _bookService.CreateAsync(book);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "The system encounters errors regarding database" });

            var filteredRouteData = RouteData.Values.Where(e => string.Compare(e.Key, "version", true) == 0 || string.Compare(e.Key, "controller", true) == 0).ToList();
            var url = Url.RouteUrl(filteredRouteData);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}" + url;
            var locationUrl = baseUrl + "/" + ApiRoutes.Books.GetById.Replace("{version:apiVersion}", ApiRoutes.V1).Replace("{bookId}", book.Id.ToString());

            return Created(locationUrl, _mapper.Map<BookResponse>(book));
        }

        [HttpPut]
        [Route(ApiRoutes.Books.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid bookId, [FromBody] UpdateBookRequest bookRequest)
        {
            var book = await _bookService.GetByIdAsync(bookId);
            if (book == null)
                return NotFound();

            book.Name = bookRequest.Name;
            book.Credits = bookRequest.Credits;
            book.Quantities = bookRequest.Quantities;
            book.AvailableQuantities = Math.Max(0, book.AvailableQuantities + (bookRequest.Quantities - book.Quantities));
            var updated = await _bookService.UpdateAsync(book);

            if (updated)
                return Ok(book);

            return NotFound();
        }

        [HttpDelete]
        [Route(ApiRoutes.Books.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid bookId)
        {
            var deleted = await _bookService.DeleteAsync(bookId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
