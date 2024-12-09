using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dealership.Core.Constants.RoleConstants;
namespace Dealership.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
