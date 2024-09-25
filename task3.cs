using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            const string accountSid = "дані";
            const string authToken = "дані";

            TwilioClient.Init(accountSid, authToken);

            Console.Write("Введіть номер телефону та тему повідомлення через пробіл: ");
            string input = Console.ReadLine(); 

            string[] parts = input.Split(new[] { ' ' }, 2); 

            if (parts.Length < 2)
            {
                Console.WriteLine("Введіть номер телефону та тему повідомлення через пробіл.");
                return;
            }

            string phoneNumber = parts[0]; 
            string subject = parts[1];

            string name = "Вікторія";
            string surname = "Кваченок";

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            string messageBody = $"Тема: {subject}\nДата: {currentDate}\nЧас: {currentTime}\nІм'я: {name}\nПрізвище: {surname}";

            try
            {
                var message = MessageResource.Create(
                    to: new PhoneNumber(phoneNumber),
                    from: new PhoneNumber("твій віртуальний номер"),
                    body: messageBody
                );

                Console.WriteLine($"Відправлено: {message.Body}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
            }
        }
    }
}
