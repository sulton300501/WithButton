using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp49.TelegramBotNomi
{
    public class TelegramHandler
    {
        public string Token {  get; set; }
        public TelegramHandler(string token) { 
           this.Token = token;
        }
   
        public async Task BotHandler()
        {
            var botClient = new TelegramBotClient($"{this.Token}");

            using CancellationTokenSource cts = new();


            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();





        }


        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;


            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}. Bio => {message} {message.Chat.Username}");

            if(messageText == "/amerika")
            {
                
                Message sendMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: $"{"1$  12405 so'm"}",
        parseMode: ParseMode.MarkdownV2,
        disableNotification: true,
        replyToMessageId: update.Message.MessageId,
        replyMarkup: new InlineKeyboardMarkup(
            InlineKeyboardButton.WithUrl(
                text: "Saytga marhamat",
                url: "https://kurs.uz/uz")),
        cancellationToken: cancellationToken);
            }
            else if (messageText == "/rossiya")
            {

                Message sendMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: $" 1 rubl  141 som",
        parseMode: ParseMode.MarkdownV2,
        disableNotification: true,
        replyToMessageId: update.Message.MessageId,
        cancellationToken: cancellationToken);
            }

           else if (messageText == "/kazakstan")
            {

                Message sendMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "1 tenge 27,47 sum",
        parseMode: ParseMode.MarkdownV2,
        disableNotification: true,
        replyToMessageId: update.Message.MessageId,
        replyMarkup: new InlineKeyboardMarkup(
            InlineKeyboardButton.WithUrl(
                text: "saytga marhamat",
                url: "https://kurs.uz/uz")),
        cancellationToken: cancellationToken);
            }
            else if (messageText == "/kirgizstan")
            {

                Message sendMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "1 som 138,85 sum",
        parseMode: ParseMode.MarkdownV2,
        disableNotification: true,
        replyToMessageId: update.Message.MessageId,
        replyMarkup: new InlineKeyboardMarkup(
            InlineKeyboardButton.WithUrl(
                text: "saytga marhamat",
                url: "https://kurs.uz/uz")),
        cancellationToken: cancellationToken);
            }




            // Echo received message text
            /*  Message sentMessage = await botClient.SendVideoAsync(
                  chatId: chatId,
                  video: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg"),
                  cancellationToken: cancellationToken);
  */
            /*  Message sentMessage2 = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Bio ketyapti:\n + {messageText} => {message.Chat.Bio}",
                cancellationToken: cancellationToken);*/
        }


        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }




    }
}
