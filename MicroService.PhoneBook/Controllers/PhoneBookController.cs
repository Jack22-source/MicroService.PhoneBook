using MicroService.PhoneBook.Service.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MicroService.PhoneBook.Controllers
{
    [Produces("application/json")]
    [Route("/phone-book")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        /// <summary>
        /// Get a list of phone book entries
        /// </summary>
        /// <remarks>
        ///     Get a list of phone book entries. Filter list by optional paramater passed in.
        /// </remarks>
        /// <param name="byName">This paramater can be used to search by name.</param>
        /// <param name="byPhoneNumber">This paramater can be used to search by phoneNumber.</param>
        /// <returns>Success and the Entry model is returned with the saved Ids added</returns>
        /// <response code="200">Successful operation</response>
        [HttpGet("entries/")]
        public ActionResult<IEnumerable<Entry>> Get([FromQuery] string byName, [FromQuery] string byPhoneNumber)
        {
            return Ok(_phoneBookService.GetPhoneBookEntries(byName, byPhoneNumber));
        }

        /// <summary>
        /// Create a new phone book Entry.
        /// </summary>
        /// <remarks>
        ///     Creates a single or a list of new phone book entries.
        /// </remarks>
        /// <returns>Success and the Entry model is returned with the saved Ids added</returns>
        /// <response code="200">Successful operation</response>

        [HttpPost("entries/")]
        public ActionResult<List<Entry>> SaveEnties(List<EditEntry> entries)
        {
            List<Entry> savedEntries = _phoneBookService.SaveEntries(entries);
            return Ok(savedEntries);
        }

        /// <summary>
        /// Update a phone book entry.
        /// </summary>
        /// <remarks>
        ///     Update a single phone book entry.
        /// </remarks>
        /// <param name="id">The entry id to update.</param>
        /// <param name="entry">The model containing the name and number that will be updated</param>
        /// <returns>Success</returns>
        /// <response code="200">Successful operation</response>
        [HttpPost("entries/{id}")]
        public ActionResult<EntryResult> UpdateEntry(Guid id, [FromBody] EditEntry entry)
        {
            _phoneBookService.Update(id, entry);
            return Ok(new EntryResult() {  Success = true});
        }

        /// <summary>
        /// Delete a phone book entry.
        /// </summary>
        /// <remarks>
        ///     Delete a single phone book entry.
        /// </remarks>
        /// <param name="id">The entry id to delete.</param>
        /// <returns>Success</returns>
        /// <response code="200">Successful operation</response>
        [HttpDelete("entries/{id}")]
        public ActionResult<EntryResult> DeleteEntry(Guid id)
        {
            _phoneBookService.Delete(id);
            return Ok(new EntryResult() { Success = true });
        }
    }
}