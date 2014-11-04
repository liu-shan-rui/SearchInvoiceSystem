using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Business.Utilities
{
    public class MailNotifier
    {
        private string _from = String.Empty;
        private string _to = String.Empty;
        private string _subject = String.Empty;
        private string _attachmentsPath = String.Empty;
        private string _body = String.Empty;

        private string _smtpServer = String.Empty;
        private string _smtpUserName = String.Empty;
        private string _smtpPassword = String.Empty;

        public MailNotifier(string smtpServer, string smtpUserName, string smtpPassword)
        {
            _smtpServer = smtpServer;
            _smtpUserName = smtpUserName;
            _smtpPassword = smtpPassword;
           
        }
        

        public void Notice()
        {
            SendMail();
        }

        private void SendMail()
        {
            MailMessage myMail = new MailMessage();
            myMail.From = new MailAddress(_from);
            myMail.Attachments.Add(new Attachment(_attachmentsPath));

            myMail.Subject = _subject;

            String[] MailPerson = _to.Split(';');
            for (Int32 i = 0; i < MailPerson.Length; i++)
                myMail.To.Add(new MailAddress(MailPerson[i]));


            myMail.IsBodyHtml = false;
            myMail.Body = _body;

            try
            {
                SendEmail(myMail);
            }
            catch (Exception Ex)
            {
               //todo
            }
        }

        private void SendEmail(MailMessage mail)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = _smtpServer;
                client.Credentials = new NetworkCredential(_smtpUserName, _smtpPassword);
                client.Send(mail);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public String From
        {
            get
            {
               
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        public String To
        {
            get
            {             
                return _to;
            }
            set
            {
                _to = value;
            }
        }

        public String Subject
        {
            get
            {              
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }

        public String AttachmentsPath
        {
            get
            {               
                return _attachmentsPath;
            }
            set
            {
                _attachmentsPath = value;
            }
        }


        public String Body
        {
            get
            {               
               return _body;
            }
            set
            {
                _body = value;
            }
        }
    }
}
