using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.IServices.IServices;
using DBEntityModule.Test;
using Microsoft.Extensions.Logging;

namespace StepByStepDemo.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StudentTestController : ControllerBase
    {
        private readonly IStudentTestService _studentTestService;
        private readonly IUnitOfWork  _unitOfWork;
        private readonly ILogger<StudentTestController> _logger;

        public StudentTestController(IStudentTestService studentTestService, IUnitOfWork unitOfWork, ILogger<StudentTestController> logger)
        {
            _studentTestService = studentTestService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            try
            {
                StudentTest studentTest = new StudentTest() { Id = Guid.NewGuid().ToString(), Age = 10, Gender = "boy", Name = "张三" };
                _studentTestService.Add(studentTest);
               int num= _unitOfWork.Commit();
                _logger.LogInformation($"添加{num}条数据");
               
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult CreateLog()
        {
            _logger.LogError("123");
            return Ok();
        }
    }
}