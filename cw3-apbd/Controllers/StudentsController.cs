using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw3_apbd.DAL;
using cw3_apbd.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw3_apbd.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy) // action method
        {
            //s  var s = HttpContext.Request;
            // return $"Jan, Anna, Katarzyna sortowanie={orderBy}";
            return Ok(_dbService.GetStudents());
        }
        // Первый способ передачи данных
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id) {
            // HttpContext.Request
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Nie znaleziono studenta");
        }

        /*
        [HttpGet("something/else")]
        public string GetStudent() {
            return "A";
        }
        */
        // 3 способ Передача данных в теле запроса
        [HttpPost]
        public IActionResult CreateStudent(Student student) {
            // добавили в БД
            // ... generating index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult LoadData(int  id) {
            return Ok("Ąktualizacja dokończona. ID " + id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id) {
            return Ok("Usuwanie ukończone. ID " + id);
        }

    }
}