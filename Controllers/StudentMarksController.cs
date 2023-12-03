using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarksController : Controller
    {
        private readonly IStudentSubjectMarksDL studentSubjectMarksDL;
        public StudentMarksController(IStudentSubjectMarksDL _studentSubjectMarksDL)
        {
            studentSubjectMarksDL = _studentSubjectMarksDL;
        }
        [HttpPost("")]
        public IActionResult SaveMarks(StudentSubjectMarksRequestDto studentSubjectMarksRequestDto)
        {
            try
            {
                var result = studentSubjectMarksDL.SaveMarks(studentSubjectMarksRequestDto);
                return Ok(result);
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
                var result = studentSubjectMarksDL.Delete(Id);
                return Ok("Deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, int Marks)
        {
            try
            {
                var result = studentSubjectMarksDL.UpdateMarks(Id, Marks);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
    }
}
