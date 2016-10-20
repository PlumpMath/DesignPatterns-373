using System;
using System.Collections.Generic;

namespace MailBuilder
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Email
                .GetBuilder()
                .AddReceiver("Alan@yandex.ru")
                .SetBody("Hello dear! I know what you did last summer..")
                .AddCopyReceivers("police@mail.ru")
                .AddCopyReceivers("fbi@gmail.ru")
                .AddCopyReceivers("alans_mother@gmail.ru")
                .SetTitle("Greetings from the past")
                .Build
            );
        }
    } 

    public static class Email 
    {
        public static ReceiverPartEmail GetBuilder()
        {
            return new EmailBuilder();
        }

        private class EmailBuilder : ReceiverPartEmail, BodyPartEmail, FullEmail
        {
            private HashSet<string> _receiver = new HashSet<string>();
            private string _body = "";
            private HashSet<string> _copyReceivers = new HashSet<string>();
            private string _title = "";

            public BodyPartEmail AddReceiver(string receiver)
            {
                _receiver.Add(receiver);
                return this;
            }

            public FullEmail SetBody(string body)
            {
                _body = body;
                return this;
            }

            public FullEmail AddCopyReceivers(string otherReceiver)
            {
                _copyReceivers.Add(otherReceiver);
                return this;
            }

            public FullEmail SetTitle(string title)
            {
                _title = title;
                return this;
            }

            public string Build 
            {
                get
                { 
                    return String.Format(
                        "Receivers: {0}\nBody: {1}\nTitle: {2}\nSend copy to: {3}", 
                        String.Join("; ", _receiver),
                        _body,
                        _title,
                        String.Join("; ", _copyReceivers));
                }
            }
        }
    }

    #region Interfaces

    public interface ReceiverPartEmail
    {
        BodyPartEmail AddReceiver(string receiver);
    }

    public interface BodyPartEmail
    {
        FullEmail SetBody(string body);
    }

    public interface FullEmail
    {
        FullEmail AddCopyReceivers(string otherReceiver);
        FullEmail SetTitle(string title);
        string Build { get; }
    }

    #endregion
}