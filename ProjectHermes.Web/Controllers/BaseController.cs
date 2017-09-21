using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;
using Microsoft.Owin.Security;
using ProjectHermes.Db.Contracts;
using ProjectHermes.Web.IdentityConfig;
using ProjectHermes.Db.Entities;

namespace ProjectHermes.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IDataRepo _repo;
        protected IMapper _mapper;
        protected TelemetryClient _telemetryClient;

        private UserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private Func<string> GetUserId;


        public BaseController(IDataRepo repo, IMapper mapper, TelemetryClient telemetryClient)
        {
            _repo = repo;
            _mapper = mapper;
            _telemetryClient = telemetryClient;
            GetUserId = () => User.Identity.GetUserId();
        }

        public User CurrentUser
        {
            get
            {
                ViewBag.CurrentUser = ViewBag.CurrentUser ?? _repo.GetUser(GetUserId());
                return ViewBag.CurrentUser;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}