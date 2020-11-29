using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QueueBackground.Models
{
    public class MailSenderRepository
    {

        public void SendMail(string subject, string body, string from, string[] toaddress, string[] ccaddress, string[] bccaddress)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.From = new MailAddress(from);

            foreach (string toadd in toaddress)
            {
                if (toadd.Length > 0)
                {
                    mailMessage.To.Add(new MailAddress(toadd));
                }
            }

            if (ccaddress != null)
            {
                foreach (string ccadd in ccaddress)
                {
                    if (ccadd.Length > 0)
                    {
                        mailMessage.CC.Add(ccadd);
                    }
                }
            }

            if (bccaddress != null)
            {
                foreach (string bccadd in bccaddress)
                {
                    if (bccadd.Length > 0)
                    {
                        mailMessage.Bcc.Add(bccadd);
                    }
                }
            }

            //Set additional options
            mailMessage.Priority = MailPriority.High;
            //Text/HTML
            mailMessage.IsBodyHtml = true;

            mailMessage.Subject = subject;
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient();

            //************ Adding Authintacation************//
            String smtpuser = "smtpuser";
            String smtpPassword = "smtpPassword";

            smtpClient.Host = "25";

            smtpClient.Port =  System.Convert.ToInt32(25);


            NetworkCredential NetworkCred = new NetworkCredential(smtpuser, smtpPassword);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = NetworkCred;
            smtpClient.EnableSsl = true;

            //***********************//

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                var exception = ex.Message.ToString();                
            }
        }

        public void sendMail(string bodydetails, string subject , string from, string to)
        {

            string[] toaddress = new string[1];
            toaddress[0] = to;
            SendMail(subject, bodydetails, from, toaddress, null, null);
        }
        public void SendMailusingGmail()
        {
            //dP76qmISAxg43sLC
            var fromAddress = new MailAddress("bappyist@gmail.com", "Email");
            var toAddress = new MailAddress("XXXXXX", "bayzid");
            const string fromPassword = "XXXXXX";
            const string subject = "subjetc";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,

            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                var exception= ex.Message.ToString();
            }
        }

    }
}
