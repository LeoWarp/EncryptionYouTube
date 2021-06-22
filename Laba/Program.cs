using Laba.Models;
using System;

namespace laba_6
{
    class Program
    {
        #region
        static void Main(string[] args)
        {
            #region Инициализация объектов

            Sender sender = new Sender { FirstName = "АйтишныйДомосед", LastName = "" };
            Recipient recipient = new Recipient { FirstName = "Билл", LastName = "Гейтс" };
            Burglar burglar = new Burglar { FirstName = "John", LastName = "Hacker" };

            Encryption encryption = new Encryption();

            #endregion

            Console.WriteLine("1. Написать сообщение\n" +
                "2. Получить сообщение в зашифрованном виде\n" +
                "3. Получить сообщение в расшифрованном виде\n" +
                "4. Получить всю украденную инофрмацию");

            #region Симметричное шифрование

            //while (true)
            //{
            //    //Console.WriteLine("Выберите команду:");
            //    //int command = int.Parse(Console.ReadLine());

            //    //if (command == 1)
            //    //{
            //    //    Console.WriteLine("Введите сообщение:");
            //    //    sender.Message = Console.ReadLine();

            //    //    if (!string.IsNullOrWhiteSpace(sender.Message))
            //    //    {
            //    //        encryption.SendMessage(sender.Message, sender, recipient);
            //    //    }
            //    //    else
            //    //    {
            //    //        Console.ForegroundColor = ConsoleColor.Red;
            //    //        Console.WriteLine("Вы не ввели сообщение :(");
            //    //        Console.ForegroundColor = ConsoleColor.White;
            //    //    }
            //    //}
            //    //else if (command == 2)
            //    //{
            //    //    encryption.GetEncryptedMessage();
            //    //}
            //    //else if (command == 3)
            //    //{
            //    //    if (!string.IsNullOrWhiteSpace(sender.Message))
            //    //    {
            //    //        Console.WriteLine("Предоставьте ключ для получения информации:");
            //    //        var key = ushort.Parse(Console.ReadLine());

            //    //        encryption.GetDecryptedMessage(key, ref burglar.StolenInformation);
            //    //    }
            //    //    else
            //    //    {
            //    //        Console.ForegroundColor = ConsoleColor.Red;
            //    //        Console.WriteLine("Сообщения нет :(");
            //    //        Console.ForegroundColor = ConsoleColor.White;
            //    //    }
            //    //}
            //    //else if (command == 4)
            //    //{
            //    //    encryption.GetAllStolenInformation(burglar.StolenInformation);
            //    //}
            //    //else
            //    //{
            //    //    break;
            //    //}
            //}

            #endregion

            #region Ассиметричное шифрование

            while (true)
            {
                Console.WriteLine("Выберите команду:");
                int command = int.Parse(Console.ReadLine());

                if (command == 1)
                {
                    Console.WriteLine("Введите сообщение:");
                    sender.Message = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(sender.Message))
                    {
                        encryption.SendMessage(sender.Message, sender, recipient);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы не ввели сообщение :(");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (command == 2)
                {
                    encryption.GetEncryptedMessage();
                }
                else if (command == 3)
                {
                    if (!string.IsNullOrWhiteSpace(sender.Message))
                    {
                        Console.WriteLine("Предоставьте публичный ключ для получения информации:");
                        var publicKey = ushort.Parse(Console.ReadLine());

                        Console.WriteLine("Предоставьте приватный ключ для получения информации:");
                        var privateKey = ushort.Parse(Console.ReadLine());

                        encryption.GetDecryptedMessage(publicKey, privateKey, ref burglar.StolenInformation);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Сообщения нет :(");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (command == 4)
                {
                    encryption.GetAllStolenInformation(burglar.StolenInformation);
                }
                else
                {
                    break;
                }
            }

            #endregion

        }

        #endregion
    }
}
