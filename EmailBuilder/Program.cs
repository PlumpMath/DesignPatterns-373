using System;
using System.Collections.Generic;

namespace MailBuilder
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(new EmailBuilder()
                .AddReceiver("Alan@yandex.ru")
                .SetBody("Hello dear!")
                .AddReceiver("Amber@yandex.ru")
                .SetBody("I know what you did last summer..")
                .AddCopyReceivers("police@mail.ru")
                .AddCopyReceivers("fbi@gmail.ru")
                .AddCopyReceivers("alans_mother@gmail.ru")
                .SetTitle("Greetings from the past")
                .GetEmail()
            );
            Console.ReadLine();
        }
    }

    public class EmailBuilder
    {
        public MandatoryFieldsEmailBuilder AddReceiver(string receiver)
        {
            return new MandatoryFieldsEmailBuilder().AddReceiver(receiver);
        }

        public class MandatoryFieldsEmailBuilder
        {
            private readonly HashSet<string> _receivers = new HashSet<string>();
            private string _body = "";

            public MandatoryFieldsEmailBuilder AddReceiver(string receiver)
            {
                _receivers.Add(receiver);
                return this;
            }

            public FullEmailBuilder SetBody(string body)
            {
                _body = body;
                return new FullEmailBuilder(_receivers, _body);
            }
        }

        public class FullEmailBuilder
        {
            private readonly HashSet<string> _receivers;
            private string _body;
            private readonly HashSet<string> _copyReceivers = new HashSet<string>();
            private string _title = "";

            public FullEmailBuilder(HashSet<string> receivers, string body)
            {
                _receivers = receivers;
                _body = body;
            }

            public FullEmailBuilder AddReceiver(string receiver)
            {
                _receivers.Add(receiver);
                return this;
            }

            public FullEmailBuilder SetBody(string body)
            {
                _body = body;
                return this;
            }

            public FullEmailBuilder AddCopyReceivers(string otherReceiver)
            {
                _copyReceivers.Add(otherReceiver);
                return this;
            }

            public FullEmailBuilder SetTitle(string title)
            {
                _title = title;
                return this;
            }

            public string GetEmail()
            {
                return string.Format(
                    "Receivers: {0}\nBody: {1}\nTitle: {2}\nSend copy to: {3}",
                    string.Join("; ", _receivers),
                    _body,
                    _title,
                    string.Join("; ", _copyReceivers));
            }
        }
    }
}
