using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptialPlatform_Shanttiya.Models;
using CaptialPlatform_Shanttiya.DataAccess;

namespace CaptialPlatform_Shanttiya.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Account objAct = new Account();
            DataAccessLayer objDB = new DataAccessLayer(); 
            objAct.ShowallAccount = objDB.Selectalldata();
            return View(objAct);
        }
        [HttpGet]
        public ActionResult InsertAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertAccount(Account ObjAcct)
        {
            ObjAcct.AccountNumber = Convert.ToString(ObjAcct.AccountNumber);
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(ObjAcct);
                ViewData["result"] = result;
                if (result == "ACCT_NO_EXIST")
                {
                    ViewBag.Message = String.Format("This account number has already been used. Kindly use different account number.");
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.Message = String.Format("Record has been inserted");
                }
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]

        public ActionResult Edit(string AccountNumber)
        {
            Account objAct = new Account();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            return View(objDB.SelectDatabyAccNumber(AccountNumber));

        }
        [HttpPost]

        public ActionResult Edit(Account objAct)
        {
            objAct.AccountNumber = Convert.ToString(objAct.AccountNumber);
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer(); 
                string result = objDB.UpdateData(objAct);
                ViewData["result"] = result;
                ViewBag.Message = String.Format("Record has been updated");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();

            }

        }
        [HttpGet]

        public ActionResult Delete(string AccountNumber)
        {
            Account objCustomer = new Account();
            DataAccessLayer objDB = new DataAccessLayer(); 
            return View(objDB.SelectDatabyAccNumber(AccountNumber));

        }

        [HttpPost]
        public ActionResult Delete(Account objAct)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            string result = objDB.DeleteData(objAct);
            ViewData["result"] = result;
            ModelState.Clear();
            ViewBag.Message = String.Format("Record has been deleted");
            return View();

        }
    }
}