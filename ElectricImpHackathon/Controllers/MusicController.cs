using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ElectricImpHackathon.Controllers
{
    public class MusicController : Controller
    {
        //
        // GET: /Music/

        public ViewResult Go()
        {
            var musicString = Request.Params["body"];

            var request = System.Net.WebRequest.Create("https://agent.electricimp.com/qcd3tqH2yirA?led=" + musicString);

            var result = request.BeginGetResponse(null, null);

            return View();
        }
    }
}
