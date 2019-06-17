using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationForA4.DatabaseContext;
using WebApplicationForA4.Models;

namespace WebApplicationForA4.Controllers
{
    public class AgentController : Controller
    {
        AgentDbContext db = new AgentDbContext();
        //
        // GET: /Agent/
        public ActionResult Add()
        {
            var datalist = GetAll();
            if (datalist != null)
            {
                return View(datalist);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Add(Agent agent)
        {
            db.Agents.Add(agent);
            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                ViewBag.isSuccess = "Saved";
            }
            else
            {
                ViewBag.fail = "Not Saved";
            }
            var datalist = GetAll();
            if (datalist != null)
            {
                return View(datalist);
            }

            return View();
        }

        public Agent GetAgentById(int id)
        {
            Agent nCatagory = db.Agents.Where(c => c.Id == id).FirstOrDefault();
            return nCatagory;
        }
        public bool Deletes(Agent agent)
        {
            bool isDelete = false;

            db.Agents.Remove(agent);
            int roAffacted = db.SaveChanges();
            if (roAffacted > 0)
            {
                isDelete = true;
            }
            return isDelete;
        }
        public ActionResult Delete(int Id)
        {
            bool isDelete = false;

            Agent agent = GetAgentById(Id);

            isDelete = Deletes(agent);

            if (isDelete)
            {
                return RedirectToAction("Add");
            }
            return RedirectToAction("Delete");
        }
        public ActionResult Update(int id)
        {

            var agent = GetAgentById(id);
            return View(agent);
        }
        [HttpPost]
        public ActionResult Update(Agent agent)
        {
           
            bool isUpdate = Updates(agent);
            if (isUpdate)
            {
                return RedirectToAction("Add");
            }
            ViewBag.fail = "Sorry! Successfully Failed";
            return View(agent);
        }

        public bool Updates(Agent agent)
        {
            db.Entry(agent).State = EntityState.Modified;
            int isUpdate = db.SaveChanges();
            if (isUpdate > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Agent> GetAll()
        {
            return db.Agents.ToList();
        }
        public Agent IsCodeExist(string code)
        {
            return db.Agents.Where(c => c.Code == code).FirstOrDefault();
        }
        public JsonResult IsCodeNoExist(string code)
        {
            var data = IsCodeExist(code);

            if (data != null)
            {
                return Json("Sorry! This Code Is Alrady Exist !", JsonRequestBehavior.AllowGet);
            }
            return Json(false);
        }
	}
}