using StandardSharedCode;
using System;

namespace _010_LocalFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class Spammer
    {
        private string Message { get; set; }

        public Spammer()
        {

        }

        public void Start()
        {
            for (int i = 1; i < 10000; i++)
            {
                Message = $"SPAM_{i.ToString()}";
                SendMessages();
            }

            Utils.BloccaConsole();
        }

        private void SendMessages()
        {
            if (IsValid(Message))
            {
                Print();
            }
            else
            {
                Console.WriteLine("TOO MUCH SPAM!" + " " + Message);
            }

            // LOCAL FUNCTION
            void Print()
            {
                Console.WriteLine(Message);
            }

            // LOCAL FUNCTION + BODY EXPRESSION
            bool IsValid(string msg) => !string.IsNullOrEmpty(msg) && msg.Length <= 8;
        }
    }
}