using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Security;
using Sp16_p3_g__1_.Models;
using Sp16_p3_g__1_;

namespace WebAdmin.Controllers
{
    public class UsersController : Controller
    {
        private WebContext db = new WebContext();

        //login - get
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //login - post
        [HttpPost]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            //if(email == null)
            //{
            //    ModelState.AddModelError("Email", "Must have a valid email to log in.");
            //    return View(new User());
            //}

            if (password == null)
            {
                ModelState.AddModelError("Password", "Must have a valid password to log in.");
                return View(new User());
            }

            var loginUser = db.Users.FirstOrDefault(u => u.Email == email);
            if (loginUser == null)
            {
                ModelState.AddModelError("Email", "Must have a valid email to log in.");
                return View(new User());
            }
            if (!Crypto.VerifyHashedPassword(loginUser.Password, password))
            {
                loginUser.Password = "";
                return View(loginUser);
            }

            FormsAuthentication.SetAuthCookie(email, true);

            if (Request.QueryString["ReturnURL"] != null)
            {
                return Redirect(Request.QueryString["ReturnURL"]);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        [Authorize]
        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Authorize]
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Email,Password,FName,LName")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.HashPassword(user.Password);
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [Authorize]
        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.Password = "";
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Email,Password, FName, LName")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == null)
                {
                    ModelState.AddModelError("Password", "Enter your password to update.");
                }
                user.Password = Crypto.HashPassword(user.Password);
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }



            return View(user);
        }

        [Authorize]
        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
