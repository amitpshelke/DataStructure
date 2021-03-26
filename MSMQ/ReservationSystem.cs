using System;
using System.Collections.Generic;
using System.Messaging;

namespace MSMQ
{
    public class ReservationSystem
    {
        private MessageQueue messageQueue = null;
        private string path = @".\Private$\IDG";

        public ReservationSystem()
        {
        }

        public void Create()
        {
            string description = "This is a test queue.";
            string message = "This is a test message.";

            try
            {
                if (MessageQueue.Exists(path))
                {
                    messageQueue = new MessageQueue(path);
                    messageQueue.Label = description;
                }
                else
                {
                    MessageQueue.Create(path);
                    messageQueue = new MessageQueue(path);
                    messageQueue.Label = description;
                }
                messageQueue.Send(message);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
            }
        }

        public List<string> ReadQueue(string path)
        {
            List<string> lstMessages = new List<string>();
            using (MessageQueue messageQueue = new MessageQueue(path))
            {
                Message[] messages = messageQueue.GetAllMessages();
                foreach (System.Messaging.Message message in messages)
                {
                    message.Formatter = new XmlMessageFormatter(new String[] { "System.String, mscorlib" });
                    string msg = message.Body.ToString();
                    lstMessages.Add(msg);
                }
            }
            return lstMessages;
        }

        public void SendMessage(string queueName, LogMessage msg)
        {
            MessageQueue _messageQueue = null;

            if (!MessageQueue.Exists(queueName))
                _messageQueue = MessageQueue.Create(queueName);
            else
                _messageQueue = new MessageQueue(queueName);

            try
            {
                _messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(LogMessage) });
                _messageQueue.Send(msg);
            }
            catch(Exception ex)
            {
                //Write code here to do the necessary error handling.
            }
            finally
            {
                _messageQueue.Close();
            }
        }

        public LogMessage ReceiveMessage(string queueName)
        {
            if (!MessageQueue.Exists(queueName))
                return null;

            MessageQueue _messageQueue = new MessageQueue(queueName);
            LogMessage logMessage = null;

            try
            {
                _messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(LogMessage) });
                logMessage = (LogMessage)_messageQueue.Receive().Body;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                _messageQueue.Close();
            }
            return logMessage;
        }
    }

    public class LogMessage
    {
        public string MessageText { get; set; }

        public DateTime MessageTime { get; set; }
    }
}
