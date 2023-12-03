using Core.Interfaces;
using Core.Models.RequestModels;
using DL;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentDL studentDL;
        public StudentsController(IStudentDL _studentDL)
        {
            studentDL = _studentDL;
        }
        [HttpPost("")]
        public IActionResult Post(StudentRequestDto studentRequestDto)
        {
            try
            {
                var student = studentDL.SaveStudent(studentRequestDto);
                return Ok(student);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{Id}")]
        public IActionResult Edit(int Id,StudentRequestDto studentRequestDto)
        {
            try
            {
                var student = studentDL.UpdateStudent(Id, studentRequestDto);
                return Ok(student);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var student = studentDL.DeleteStudent(Id);
                return Ok("Deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{Id}/Subjects")]
        public IActionResult GetSubjects(int Id)
        {
            try
            {
                var subjects = studentDL.GetSubjects(Id);
                return Ok(subjects);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("")]
        public IActionResult Get()
        {
            var students = studentDL.GetStudentsAsync();
            return Ok(students);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var student = studentDL.GetStudent(Id);
                return Ok(student);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{Id}/Subjects/{SubjectId}/marks")]
        public IActionResult GetStudentSubjectMarks(int Id, int SubjectId)
        {
            try
            {
                var marks = studentDL.GetStudentSubjectMarks(Id, SubjectId);
                return Ok(marks);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{Id}/marks")]
        public IActionResult GetStudentMarks(int Id)
        {
            try
            {
                var marks = studentDL.GetStudentMarks(Id);
                return Ok(marks);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{Id}/GPA")]
        public IActionResult GetStudentGPA(int Id)
        {
            try
            {
                var GPA = studentDL.GetStudentGPA(Id);
                return Ok(GPA);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
