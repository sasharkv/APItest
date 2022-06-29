using APItest.Data;
using APItest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APItest.Controllers
{
    [Route("api/[controller]")] // this means the url will be api/issue, so the controller name without the "controller" suffix
    [ApiController] // this attribute is used to apply common conventions to your controller: like automatic validation of the model, binding
    // request data to the model etc

    // the ControllerBase class provides usefull properties and methodes to help you manage HTTP requests
    public class IssueController : ControllerBase
    {
        // we declate the DbContext in the constructor so that the controller can access the db, this way we
        // will get an instance of it at the runtime

        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context) => _context = context;  

        // an Action Method is a public method that is executed in response to an HTTP request
        // we create an Action Methid that will be mapped to the HTTP verb GET, in oreder to get a list of Issues
        [HttpGet]
        public async Task<IEnumerable<Issue>> Get() // Look this up!    
            => await _context.Issues.ToListAsync();    
        
        // this method will get a single Issue
        // the id in the URL will be bound to the id parameter of the method
       [HttpGet("{id}")]
       [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]   // this just enhances the documentation
       [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue); // in case it's null the NotFound() will generate 404 status code in the response; if not Ok() will generate a 200 status code; these methodes come from a ControllerBase class
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            // here we add the Issues submitted by the request to the Issues collection exposed by the context
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync(); // <- this will propagate the changes to the db

            // use CreatedAtAction for the response, will return the status code and the location in the editor;
            // it takes 3 params: the action that returns a single Issue, the id of the Issue as an anonymous object, and the issue itself
            return CreatedAtAction(nameof(GetById), new {id = issue.Id}, issue);
        }
    }
}
