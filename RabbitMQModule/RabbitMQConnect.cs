using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQModule
{
    public class RabbitMQConnect:IDisposable
    {
        private IConnection connection { get; set; }
        private IModel channel { get; set; }
        public RabbitMQConnect()
        {
            var u = "admin";
            var pw = "admin";
            var v = "/";
            var h = "127.0.0.1";
           // var p = 5674;

            var cf = new ConnectionFactory();
            cf.UserName = u;
            cf.Password = pw;
            cf.VirtualHost = v;
            cf.HostName = h;
           // cf.Port = p;

           //建立连接
            connection= cf.CreateConnection();
            //建立通道
            channel = connection.CreateModel();
        }
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="routingKey"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool BasicPublish(string exchange, string routingKey, string context)
        {
            try
            {
                //消息属性
                //  var propertity=  channel.CreateBasicProperties();
                //消息推送
               channel.BasicPublish(exchange, routingKey, null, Encoding.UTF8.GetBytes(context));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 清空消息队列
        /// </summary>
        /// <param name="QueueName"></param>
        /// <returns></returns>
        public uint PureQueue(string QueueName)
        {
           return  this.channel.QueuePurge(QueueName);
        }
        public string  BasicGet(string QueueName)
        {
            var result= this.channel.BasicGet(QueueName, true) ;
            return Encoding.UTF8.GetString(result.Body);
        }

        public void Dispose()
        {
            channel.Close();
            connection.Close();
        }
    }
}
