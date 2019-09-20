using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQModule;
using System.Text;

namespace StepByStepDemo.Controllers
{
    /// <summary>
    /// 授权控制器
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RabbtiMQController : Controller
    {
        private readonly RabbitMQConnect _rabbitMQConnect;
        public RabbtiMQController(RabbitMQConnect rabbitMQConnect)
        {
            _rabbitMQConnect = rabbitMQConnect;
        }
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PublishMessage()
        {
            //创建通道
            //var model= _rabbitMQConnect.connection.CreateModel();
            // model.ExchangeDeclare("ExchangeA", "direct", true, false, null);

            // model.QueueDeclare("QueueA", true, false, false, null);

            // model.QueueBind("QueueA", "ExchangeA", "A", null);

            Parallel.For(0,50,num=> {

                Task.Delay(10000).Wait();
                _rabbitMQConnect.BasicPublish("ExchangeA", "",num.ToString());
                Task.Delay(2000).Wait();
            });


          var task1=  Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Delay(200).Wait();
                    _rabbitMQConnect.BasicPublish("ExchangeA", "A", $"Task{i}");
                }
            });

            task1.Wait();

            return Ok("完成");
        }
        /// <summary>
        /// 清空消息队列
        /// </summary>
        /// <param name="QueueName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PureQueue(string QueueName)
        {
            var num = _rabbitMQConnect.PureQueue(QueueName);
            return Ok(num);
        }
        [HttpGet]
        public IActionResult BasicGet(string QueueName)
        {
            var num = _rabbitMQConnect.BasicGet(QueueName);
            return Ok(num);
        }
     //   [HttpGet]
     //   public IActionResult GetIpAddress()
     //   {
     //_rabbitMQConnect.GetIp();
     //       return Ok();
     //   }
    }
}