using Microsoft.AspNetCore.Mvc;
using Bca_New.Data;
using Bca_New.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Bca_New.Controllers
{
    public class ResultController : Controller
    {
        private readonly INotyfService _notyf;
        private ApplicationDbContext? Context { get; set; }
        public ResultController(ApplicationDbContext context, INotyfService notyf)
        {
            _notyf = notyf;
            this.Context = context;
        }
        public IActionResult Index()
        {
            return View(Context.result.ToList());
        }

        //Insert
        public IActionResult Insert(Result r)
        {
            Context.result.Add(r);
            Context.SaveChanges();
            _notyf.Success("Data Successully Inserted ");
            return RedirectToAction("Index");
            return View();
        }
        //For Edit
        public IActionResult Edit(int id)
        {
            return View(Context.result.Find(id));
        }
        [HttpPost]
        public IActionResult Updated(Result rr)
        {
            Context.result.Update(rr);
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
        public IActionResult Test()
        {
            return View();
        }

    }
}
