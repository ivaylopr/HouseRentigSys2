using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentigSys2.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
