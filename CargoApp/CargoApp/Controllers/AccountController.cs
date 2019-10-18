using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CargoApp.Models;
using CargoApp.ViewModels;

namespace CargoApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly CargoContext _context = new CargoContext();

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewmodel model)
        {
            var user = _context.User.FirstOrDefault(x => x.EmailAddress == model.email && x.Password == model.password);

            if (user != null)
            {
                Session["user"] = user.FirstName;
                return Redirect("/Home/Index");
            }

            return View();

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewmodel model)
        {
            if (!ModelState.IsValid) //modelde yazdığımız data annotaionslar doğru çalışmıyorsa yani şunlar [Requied]
            {

                return View(model);  //bunun anlamı hata varsa tekrar o sayfaya gidecek ve model tekrar gelecek.
            }



            Users user = new Users
            {
                FirstName = model.firstname,
                LastName = model.lastname,
                EmailAddress = model.email,
                Password = model.password,
                Phone = model.phone,
                EmailGuid = Guid.NewGuid()  //for unique idenditifer  
            };
            _context.User.Add(user);
            _context.SaveChanges();

            ViewBag.Information = "Kayıt gerçekleşti";

            return View();
        }

        public ActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Forgot(ForgotViewmodel model)
        {
            var user = _context.User.FirstOrDefault((x => x.EmailAddress == model.mail));  // this is for getting an user by email address

            string deger = ConfigurationManager.AppSettings["emailAccount"]; //web configden burası boş geliyor

            if (user != null)
            {
                MailMessage msg = new MailMessage
                {
                    From = new MailAddress("ffcabbar@gmail.com")
                };

                msg.To.Add(new MailAddress(model.mail));
                msg.Subject = "Şifre Sıfırlama";
                msg.Body = "Lütfen parolayı yenilemek için tıklayın http://localhost:58816/Account/ResetPassword/" + user.EmailGuid;  


                SmtpClient smtpClient = new SmtpClient();  
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;

                NetworkCredential networkCredential = new NetworkCredential("ffcabbar@gmail.com", "lostangel31");
                smtpClient.Credentials = networkCredential;

                smtpClient.Send(msg);

                ViewBag.Information = "Lütfen mail kutunuzu kontrol ediniz ";

            }
            return View(model);
        }

        public ActionResult ResetPassword(Guid? id) 
        {
            if (id !=null)
            {
                TempData["getKey"] = id;
            }           
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewmodel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid id = (Guid)TempData["getKey"];
            if (id != null)
            {
                var user = _context.User.FirstOrDefault(x => x.EmailGuid == id);

                user.Password = model.newpassword;
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges(); 

                ViewBag.Information = "Parolanız başarılı bir şekilde güncellenmiştir"; 
                return View(); 
            }
            else
            {
                ViewBag.Information = "Hata var !";
                return View(model);
            }

           

            return View(model);
        }

    }
}