using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ModelsAndUtility.Utility
{
    public class CAssessmentUtility
    {
        public void SendMail(string Subject, string Body, string emailToAddress)
        {
            int portNumber = 587;
            string smtpAddress = "smtp.gmail.com";
            string emailFromAddress = "baralrashmi99@gmail.com"; //Sender Email Address  
            string password = "jwzbkkiggxitgtnn"; //Sender Password  

            using (MailMessage mail = new MailMessage())
            {


                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }

}

