using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;
using WebApplication12.Repository;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRegApiController : Controller
    {
        DAL dal = new DAL();
        // GET: UserRegApiController
        public IActionResult Index()
        {
            ModelState.Clear();
            return Ok(dal.GetDataList());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            return Ok(dal.GetDataList().Find(ur => ur.id == id));
        }
        //GET:User/Create
        public IActionResult Create()
        {
            return Ok(dal.GetDataList());
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
                return Ok();
            }
        }
        //GET : User/Edit/5
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return Ok(dal.GetDataList().Find(ur => ur.id == id));
            // return Ok("success");
        }

        // POST : User/Edit/5
        [HttpPut("{id}")]
        public IActionResult Edit(int id, UserRegModel ur)
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
                return Ok();
            }
        }

        //GET : User/Delete/5
        [HttpGet("{id}")]
        public IActionResult Delete(int id , UserRegModel ur)
        {
            //UserRegModel req = new UserRegModel();
           // req.id = request.id;
            return Ok(dal.GetDataList().Find(ur => ur.id == id));
        }
        // POST : User/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(UserRegModel ur)
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
                return Ok();
            }
        }
    }
}