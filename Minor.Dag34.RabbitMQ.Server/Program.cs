using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag34.RabbitMQ.Server
{
    public class Program
    {
        private static string _name;
        private static string _connection;
        public static void Main(string[] args)
        {
            ConnectionFactory factory;
            Console.WriteLine("enter: chatroulete for a non local chatroom");
            _connection = Console.ReadLine();
            if (_connection == "chatroulete")
            {
                factory = new ConnectionFactory() { HostName = "192.168.120.64", UserName = "yael", Password = "admin" };
            }
            else
            {
                factory = new ConnectionFactory() { HostName = "localhost" };
            }

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                Create(channel);
                receive(channel);
                while (true)
                {
                    publish(channel);
                }                
            }                        
        }
        public static void Create(IModel channel)
        {
            Console.WriteLine("Enter your name, but not the same name as another user because otherwise there is a probability your messages won't arrive! So just don't do it OK? If you do decide to do this you will be responsible for violating someones privacy and that is not OK, mkay?");
            _name = "";
            channel.QueueDeclare(queue: _name,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            if (_connection == "chatroulete")
            {
                channel.QueueBind(queue: _name,
                                exchange: "ChatQueues",
                                routingKey: "chat.messages");
            }
            else
            {
                
                channel.ExchangeDeclare("MessageBus", ExchangeType.Fanout);
                channel.QueueBind(queue: _name,
                                exchange: "MessageBus",
                                routingKey: "");
            }              
        }
        public static void publish(IModel channel)
        {
            string message = Console.ReadLine();
            var secondThread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    //infinite beep
                    Console.Beep();
                }
            }));
            secondThread.Start();

            byte[] body = Encoding.UTF8.GetBytes(message);
            if (_connection == "chatroulete")
            {
                channel.BasicPublish(exchange: "ChatQueues",
                                     routingKey: "chat.messages",
                                     basicProperties: null,
                                     body: body);
            }
            else
            {
                
                channel.BasicPublish(exchange: "MessageBus",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }
        public static void receive(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var receivedBbody = ea.Body;
                var receivedMessage = Encoding.UTF8.GetString(receivedBbody);
                Console.WriteLine(receivedMessage);
            };
            channel.BasicConsume(queue: _name,
                                        noAck: true,
                                        consumer: consumer);         
        }
    }
    
}
