using System;
using System.Text;
using mail_client.Services;

namespace mail_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var client = new MailClientService("login@caspel.by", "password");
            Console.ReadKey();
        }
    }
}