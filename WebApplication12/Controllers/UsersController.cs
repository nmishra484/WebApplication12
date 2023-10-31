using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication12.Models;
using WebApplication12.Repository;

namespace WebApplication12.Controllers
{
    public class UsersController : Controller
    {
        DAL dal = new DAL();
        public IActionResult Index()
        {
            ModelState.Clear();
            return View(dal.GetDataList());
        }
        public IActionResult Details(int id)
        {

            return View(dal.GetDataList().Find(ur=>ur.id==id));
        }
        //GET:User/Create
        public IActionResult create()
        {
            return View();
        }
        //Post : User/create
        [HttpPost]

        public IActionResult Create(UserRegModel ur)
        {
            try
            {
                if (dal.InsertData(ur))
                {
                    ViewBag.Message = "Data saved";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //GET : User/Edit/5
        public IActionResult Edit(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.id == id));
        }

        // POST : User/Edit/5
        [HttpPost]
        public IActionResult Edit(int id , UserRegModel ur)
        {
            try
            {
                if (dal.UpdateData(ur))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("Index");
            }
            catch
            {
             return View() ;
            }
        }

        //GET : User/Delete/5
        public IActionResult Delete(int id)
        {
            return View(dal.GetDataList().Find(ur => ur.id == id));
        }
        // POST : User/Delete/5
        [HttpPost]
        public IActionResult Delete(int id , UserRegModel ur)
        {
            try
            {
                if (dal.DeleteData(ur))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}