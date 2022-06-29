using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APItest.Controllers
{
    [Route("api/[controller]")] // this means the url will be api/issue, so the controller name without the "controller" suffix
    [ApiController] // this attribute is used to apply common conventions to your controller: like automatic validation of the model, binding
    // request data to the model etc

    // the ControllerBase class provides usefull properties and methodes to help you manage HTTP requests
    public class IssueController : ControllerBase
    {
    }
}
