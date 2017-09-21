using AutoMapper;
using Microsoft.ApplicationInsights;
using ProjectHermes.Db.Contracts;
using System.Web.Mvc;

namespace ProjectHermes.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IDataRepo repo, IMapper mapper, TelemetryClient telemetryClient)
           : base(repo, mapper, telemetryClient)
        {
            _repo = repo;
            _mapper = mapper;
            _telemetryClient = telemetryClient;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}