using System.Collections.Generic;
using MailKit.Security;

namespace mail_client.Settings
{
    public class MailSettings : List<MailSettingsItem>
    {
        public MailSettings()
        {
            Add(new MailSettingsItem
            {
                Host = "imap.gmail.com",
                Port = 993,
                Protocol = Protocol.Imap,
                IsSsl = SecureSocketOptions.SslOnConnect
            });
            
            Add(new MailSettingsItem
            {
                Host = "imap.mail.ru",
                Port = 993,
                Protocol = Protocol.Imap,
                IsSsl = SecureSocketOptions.SslOnConnect
            });
            
            Add(new MailSettingsItem
            {
                Host = "imap-mail.outlook.com",
                Port = 993,
                Protocol = Protocol.Imap,
                IsSsl = SecureSocketOptions.SslOnConnect
            });
            
            Add(new MailSettingsItem
            {
                Host = "imap.yandex.ru",
                Port = 993,
                Protocol = Protocol.Imap,
                IsSsl = SecureSocketOptions.SslOnConnect
            });
        }
    }

    public class MailSettingsItem
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public Protocol Protocol { get; set; }
        public SecureSocketOptions IsSsl { get; set; }
    }

    public enum Protocol
    {
        Imap,
        Smtp
    }
}