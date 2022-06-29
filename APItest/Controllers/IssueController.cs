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
    }
}
