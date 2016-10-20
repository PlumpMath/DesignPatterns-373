using System;
using System.Collections.Generic;

namespace MailBuilder
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(
                new EmailBuilder()
                    .AddReceiver("Send to me")
                    .SetBody("This is Boooody")
                    .AddCopyReceivers("Other_1")
                    .AddCopyReceivers("Other_2")
                    .AddCopyReceivers("Other_3")
                    .SetTitle("Super TITLE")
                    .Build
            );
        }
    } 
    public class EmailBuilder : Receiver, Body, FullEmail
    {
        private HashSet<string> _receiver = new HashSet<string>();
        private string _body = "";
        private HashSet<string> _copyReceivers = new HashSet<string>();
        private string _title = "";

        public EmailBuilder() {}

        public Body AddReceiver(string receiver)
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
                    "Receiver: {0}\nBody: {1}\nTitle: {2}\nCopy: {3}", 
                    _receiver,
                    _body,
                    _title,
                    String.Join("; ", _copyReceivers));
            }
        }
    }

    #region Interfaces

    public interface Receiver
    {
        Body AddReceiver(string receiver);
    }

    public interface Body
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