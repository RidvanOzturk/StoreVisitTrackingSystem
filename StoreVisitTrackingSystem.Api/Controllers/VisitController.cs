using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController(IVisitService visitService) : ControllerBase
    {
    }
}
