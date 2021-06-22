using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba.Models
{
    public class Encryption
    {
        public ushort PublicKey = 1101;

        private ushort PrivateKey = 10011;

        private string EncryptedMessage { get; set; }

        private string DecryptedMessage { get; set; }

        private Dictionary<string, string> Messages = new Dictionary<string, string>();


        public void SendMessage(string message, Sender sender, Recipient recipient)
        {
            Console.WriteLine($"{sender.FirstName} отправил сообщение пользователю - {recipient.FirstName} {recipient.LastName}");

            EncryptedMessage = EncodeDecrypt(message, PublicKey); // Шифрование

            DecryptedMessage = EncodeDecrypt(EncryptedMessage, PublicKey); // Рассшифрование

            Messages.Add(EncryptedMessage, DecryptedMessage);
        }

        /// <summary>
        /// Получение сообщения в зашифрованном виде
        /// </summary>
        public void GetEncryptedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(EncryptedMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public void GetAllStolenInformation(List<string> stolenInformation)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var information in stolenInformation)
            {
                Console.WriteLine(information);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Получение сообщения в расшифрованном виде
        /// </summary>
        public void GetDecryptedMessage(ushort key, ref List<string> stolenInformation)
        {
            try
            {
                if (key == PublicKey)
                {
                    stolenInformation.Add(DecryptedMessage);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DecryptedMessage);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ключ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception)
            {

            }
        }

        public void GetDecryptedMessage(ushort key, ushort privateKey, ref List<string> stolenInformation)
        {
            try
            {
                if (key == PublicKey && privateKey == PrivateKey)
                {
                    stolenInformation.Add(DecryptedMessage);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DecryptedMessage);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ключ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception)
            {

            }
        }


        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var symbols = str.ToArray();
            string result = "";
            foreach (var c in symbols)  //выбираем каждый элемент из массива символов нашей строки
            {
                result += TopSecret(c, secretKey); //производим шифрование каждого отдельного элемента и сохраняем его в строку
            }
            return result;
        }

        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey); //Производим XOR операцию
            return character;
        }
    }
}
