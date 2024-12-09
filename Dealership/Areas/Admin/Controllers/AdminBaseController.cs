using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dealership.Core.Constants.RoleConstants;
namespace Dealership.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
