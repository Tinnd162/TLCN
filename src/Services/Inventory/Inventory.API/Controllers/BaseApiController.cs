using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("api/v1/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}