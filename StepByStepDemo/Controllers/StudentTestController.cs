using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.IServices.IServices;
using DBEntityModule.Test;

namespace StepByStepDemo.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StudentTestController : ControllerBase
    {
        private readonly IStudentTestService _studentTestService;
        private readonly IUnitOfWork  _unitOfWork;

        public StudentTestController(IStudentTestService studentTestService, IUnitOfWork unitOfWork)
        {
            _studentTestService = studentTestService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            try
            {
                StudentTest studentTest = new StudentTest() { Id = Guid.NewGuid().ToString(), Age = 10, Gender = "boy", Name = "张三" };
                _studentTestService.Add(studentTest);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}