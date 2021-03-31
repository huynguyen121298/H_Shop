using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using UI.Service;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string userName;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login_user()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        private string checkLoginCookie()
        {
            if (Request.Cookies.Get("username") != null)
            {
                return Request.Cookies["username"].Value;
            }
            return string.Empty;
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult ResetPassword()
        {
            log.Info("[START] UserController - ResetPassword");
            string email = Request["email"];
            if (email != null && email.Trim() != string.Empty)
            {
                ServiceRepository service = new ServiceRepository();
                log.Info("-- Call GET API CheckinEmail");
                HttpResponseMessage response = service.GetResponse("/api/User/CheckinEmail/" + email.Trim() + "/");
                string strResult = response.Content.ReadAsAsync<string>().Result;
                if (strResult != "")
                {
                    string temp = strResult;
                    try
                    {
                        string newPassword = CreatePassword(8);
                        string resetToken = GetToken(strResult);
                        if (resetToken != null)
                        {

                            using (MailMessage mail = new MailMessage())
                            {
                                mail.From = new MailAddress("chitoan2571999@gmail.com");
                                mail.To.Add(email);
                                mail.Subject = "New Password";

                                string time = DateTime.Now.ToString();
                                var linkHref = "<a href='" + Url.Action("ResetPasswordEmail2", "Account", new { UserName = strResult, Email = email, Code = resetToken }, "https") + "'> Reset Password </a>";
                                mail.Body = "<b>Truy cập vào đường dẫn sau để đổi mật khẩu</b></br>" + linkHref;
                                mail.IsBodyHtml = true;


                                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                                {
                                    smtpClient.Credentials = new System.Net.NetworkCredential("chitoan2571999@gmail.com", "01656727190");
                                    smtpClient.EnableSsl = true;
                                    smtpClient.Send(mail);
                                }
                            }
                            TempData["SendEmailMessage"] = "Yêu cầu tạo mới mật khẩu đã được thực hiện, vui lòng kiểm tra hộp thư email";
                            TempData["SendEmailMessageColor"] = "success";
                            log.Info("[END] UserController - ResetPassword [Result: Success][Detail: Success]");
                            return View("~/Views/Login/ResetPassword.cshtml");
                        }

                    }
                    catch (Exception)
                    {
                        TempData["SendEmailMessage"] = "Không thể kết nối với máy chủ, vui lòng thử lại sau";
                        TempData["SendEmailMessageColor"] = "danger";
                        log.Info("[END] UserController - ResetPassword [Result: Failed][Detail: Không thể kết nối với máy chủ, vui lòng thử lại sau]");
                        return View("~/Views/Login/ResetPassword.cshtml");
                    }
                }
                else
                {
                    TempData["SendEmailMessage"] = "Email không chính xác, vui lòng thử lại";
                    TempData["SendEmailMessageColor"] = "danger";
                    log.Info("[END] UserController - ResetPassword [Result: Failed][Detail: Email không chính xác, vui lòng thử lại]");
                    return View("~/Views/Login/ResetPassword.cshtml");
                }
            }
            TempData["SendEmailMessage"] = "Email không phù hợp, vui lòng thử lại";
            TempData["SendEmailMessageColor"] = "danger";
            log.Info("[END] UserController - ResetPassword [Result: Failed][Detail: Email không phù hợp, vui lòng thử lại]");
            return View("~/Views/Login/ResetPassword.cshtml");
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public string GetToken(string username)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseCheckAccount = service.GetResponse("/api/JWT/GetToken/" + username);
            responseCheckAccount.EnsureSuccessStatusCode();

            return responseCheckAccount.Content.ReadAsAsync<string>().Result;
        }




    }
}