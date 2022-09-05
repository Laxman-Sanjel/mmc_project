using AspNetCoreHero.ToastNotification.Abstractions;
using Bca_New.Data;
using Bca_New.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Bca_New.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        private ApplicationDbContext? Context { get; set; }
        public HomeController(ApplicationDbContext context, INotyfService notyf)
        {
            _notyf = notyf;
            this.Context = context;  
        }

        //For Insert Form
        [HttpPost]
        public IActionResult Form1(Players p)
        {
            Context.Player.Add(p);
            Context.SaveChanges();
            _notyf.Success("Data Successully Inserted ");
            return RedirectToAction("Index");
            //return View(p);
        }

        //For Edit
        public IActionResult Edit(int id){
           return View(Context.Player.Find(id));
        }

        //For Table Update
        [HttpPost]
        public IActionResult Updated(Players p)
        {
           Context.Player.Update(p);

            Context.SaveChanges();
            _notyf.Success("Data Successully Updated");
            return RedirectToAction("Index");
           
        }
        public IActionResult Delete(int id)
        {
            var ToDelete = Context.Player.Find(id);
            Context.Player.Remove(ToDelete);
            Context.SaveChanges();
            _notyf.Success("Data Successully Deleted");
            return RedirectToAction("Index");
            return View();
        }

        //At first Open
        public IActionResult IndexFirst()
        {
            return View(Context.Player.ToList());
        }
     
        public IActionResult Index()
        {
            return View(Context.Player.ToList());
        }

       

        //for registration
        public IActionResult RegUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegUser(Registers r)
        {

            if (ModelState.IsValid)
            {
                r.password = BCrypt.Net.BCrypt.HashPassword(r.password);
                //Context.Register(BCrypt.Net.BCrypt.HashPassword(r.password));
                Context.Register.Add(r);
                Context.SaveChanges();
                _notyf.Information("Register is successful");
                return RedirectToAction("Login");

            }
            else 
            {
                return View();
                }
        }
      

        //LogIn
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Homepage()
        {
            return View();
        }

        //Login Check
        [HttpPost]
        public ActionResult LogIncheck(Registers userr)
        {
            var obj = Context.Register.SingleOrDefault(a => a.email.Equals(userr.email));
            if (obj != null && BCrypt.Net.BCrypt.Verify(userr.password, obj.password))
            {
                _notyf.Success("login successful");
                return RedirectToAction("Homepage");
            }
            else
            {
                _notyf.Success("incorrect username or password");
                return RedirectToAction("Login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}