using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreVisitTrackingSystem.Service.Contracts;

namespace StoreVisitTrackingSystem.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IStoreService storeService) : ControllerBase
    {
    }
}
