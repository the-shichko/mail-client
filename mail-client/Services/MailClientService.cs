using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using mail_client.Settings;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;

namespace mail_client.Services
{
    public class MailClientService
    {
        private ImapClient _client;
        private MailSettings _mailSettings = new();

        public MailClientService(string login, string password)
        {
            _client = new ImapClient();
            var credentials = new NetworkCredential(login, password);

            var settings = _mailSettings.First(x => x.Host == "imap.yandex.ru");
            using (var cancel = new CancellationTokenSource())
            {
                _client.Connect(settings.Host, settings.Port, settings.IsSsl, cancel.Token);
                _client.Authenticate(credentials, cancel.Token);

                var personal = _client.GetFolder(_client.PersonalNamespaces[0]);
                foreach (var folder in personal.GetSubfolders(false, cancel.Token))
                    Console.WriteLine($"[folder] {folder.Name}");

                _client.Inbox.Open(FolderAccess.ReadOnly);
                var messageIds = _client.Inbox.Search(SearchQuery.All);
                var messages = new List<MimeMessage>();
                for (var i = 0; i < messageIds.TakeLast(50).Count(); i++)
                {
                    var message = _client.Inbox.GetMessage(messageIds.Count - i - 1);
                    messages.Add(message);
                }

                foreach (var message in messages.OrderBy(x => x.Date))
                {
                    Console.WriteLine($"[Message] {message.From} {message.Subject}");
                }
                
                _client.Disconnect(true, cancel.Token);
            }
        }
    }
}