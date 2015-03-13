using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace smtpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var fromAddress = new MailAddress("havizul@wanasl.com", "HavizulWanasl From");
            var toAddress = new MailAddress("havizul@gmail.com", "HavizulGmail To");
            const string fromPassword = "1q2w3e4razsxdcfv";
            const string subject = "C# Simple SMTP Client Test - 2";
            const string body = "Body Message";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

            {
                smtp.SendAsync(message, "Async Send");
                //smtp.Send(message);
            }

            //smtp.Send(message);

            Console.WriteLine("Main program finished.");
            Console.ReadLine();
		}        
    }
}

/*
 *using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
 
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mail To");
        MailAddress to = new MailAddress(Console.ReadLine());
 
        Console.WriteLine("Mail From");
        MailAddress from = new MailAddress(Console.ReadLine());
 
        MailMessage mail = new MailMessage(from, to);
 
        Console.WriteLine("Subject");
        mail.Subject = Console.ReadLine();
 
        Console.WriteLine("Your Message");
        mail.Body = Console.ReadLine();
 
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
 
        smtp.Credentials = new NetworkCredential(
            "username@domain.com", "password");
        smtp.EnableSsl = true;
        Console.WriteLine("Sending email...");
        smtp.Send(mail);
    }
}
 * 
 * 
 * ============================================================================================
 * ============================================================================================
 *     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
     
    /// <summary>
    /// Simple Emailer class for sending a simple email.
    /// </summary>
    public class Emailer
    {
        /// <summary>
        /// Takes a users email and item name and generates an email
        /// </summary>
        /// <param name="recipient">Recipients e-mail address</param>
        public static void SendMail(string recipient)
        {
            try
            {
                // Setup mail message
                MailMessage msg = new MailMessage();
                msg.Subject = "Email Subject";
                msg.Body = "Email Body";
                msg.From = new MailAddress("FROM Email Address");
                msg.To.Add(recipient);
                msg.IsBodyHtml = false; // Can be true or false
     
                // Setup SMTP client and send message
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587; // Gmail uses port 587
                    smtpClient.UseDefaultCredentials = false; // Must be set BEFORE Credentials below...
                    smtpClient.Credentials = new NetworkCredential("Gmail username", "Gmail Password");
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(msg);
                }
            }
            catch (SmtpFailedRecipientsException sfrEx)
            {
                // TODO: Handle exception
                // When email could not be delivered to all receipients.
                throw sfrEx;
            }
            catch (SmtpException sEx)
            {
                // TODO: Handle exception
                // When SMTP Client cannot complete Send operation.
                throw sEx;
            }
            catch (Exception ex)
            {
                // TODO: Handle exception
                // Any exception that may occur during the send process.
                throw ex;
            }
        }
    }

 */
