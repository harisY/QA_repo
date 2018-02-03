using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Approval.Models;
using Approval.Repository;
namespace Approval.Controllers
{
    public class ApprovalController : Controller
    {
        // GET: Approval
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllApproval()
        {
            ApprovalRepos AppRepo = new ApprovalRepos();
            ModelState.Clear();
            var approval = AppRepo.GetAllApproval();
            //return View(AppRepo.GetAllApproval());
            return Json(new { data = approval }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApprovalRepos detailsAppRepo = new ApprovalRepos();
            var approval = detailsAppRepo.GetDetailsApproval(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval.ToList());
            //return View(AppRepo.GetAllApproval());
            //return Json(new { data = approval }, JsonRequestBehavior.AllowGet);
        }
    }
}