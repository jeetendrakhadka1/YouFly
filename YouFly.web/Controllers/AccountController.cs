using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YouFly.core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace YouFly.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AirlineContext _context;

        public AccountController(AirlineContext context)
        {
            _context = context;    
        }

        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Flights");
            // return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Register(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var duplicateUsernameFound = _context.Users.Where(u => u.Username == user.Username).FirstOrDefault();
        //        if (duplicateUsernameFound != null)
        //        {
        //            ViewBag.Message = "This username already exists. You must enter a different username to register.";
        //        }
        //        else
        //        {
        //            user.Password = Crypto.HashPassword(user.Password);
        //            _context.Add(user);
        //            _context.SaveChanges();

        //            ModelState.Clear();
        //            ViewBag.Message = user.FirstName + " " + user.LastName + " has successfully registered.";
        //        }
        //    }
        //    return RedirectToAction("Login");
        //}

        [AllowAnonymous]
        public ActionResult Login()
        {
            //if (HttpContext.Session.GetString("UserID") != null)
            //{
            //    return RedirectToAction("Index");
            //}
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Login(User user)
        //{
        //    var account = _context.Users.Where(u => u.Username == user.Username).SingleOrDefault();
        //    if (account != null && Crypto.VerifyHashedPassword(account.Password, user.Password))
        //    {
        //        HttpContext.Session.SetString("UserID", account.ID.ToString());
        //        HttpContext.Session.SetString("Username", account.Username);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid username and/or password.");
        //    }
        //    return View();
        //}


        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }





        // GET: Account/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// GET: Account/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Account/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,UserName,Password,Email,Role")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        //// GET: Account/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Account/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password,Email,Role")] User user)
        //{
        //    if (id != user.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        //// GET: Account/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Account/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var user = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.ID == id);
        //}
    }
}
