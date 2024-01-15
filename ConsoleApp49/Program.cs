using ConsoleApp49.TelegramBotNomi;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp49
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string token = "6451383500:AAHwl24XudhGod-zVViZt1TSbfm2AmyXSVA";

            TelegramHandler handler = new TelegramHandler(token);

            try
            {
                await handler.BotHandler();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
