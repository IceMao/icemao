using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using icemaoCN.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace icemaoCN.Controllers
{
    public class BaseController : BaseController<IceContext,User,string>
    {
        public override void Prepare()
        {
            base.Prepare();
            ViewBag.CurrentUser = User.Current;
        }
    }
}
