using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisModule;

namespace StepByStepDemo.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RedisController : ControllerBase
    {
        private readonly RedisHelper _redisHelper;

        public RedisController(RedisHelper redisHelper)
        {
            _redisHelper = redisHelper;
        }

        [HttpGet]
        public IActionResult AddRedis(string key,string value)
        {
        bool  isb=  _redisHelper.SetValue(key, value);
            return Ok(isb);
        }
        [HttpGet]
        public IActionResult GetRedis(string key)
        {
          string str=  _redisHelper.GetValue(key);
            return Ok(str);
        }
        [HttpGet]
        public IActionResult DeleteRedis(string key)
        {
           bool isb= _redisHelper.DeleteKey(key);
            return Ok(isb);
        }

    }
}