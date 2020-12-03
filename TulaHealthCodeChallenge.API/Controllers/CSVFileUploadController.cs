using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TulaHealthCodeChallenge.Data;
using TulaHealthCodeChallenge.Domain;
using TulaHealthCodeChallenge.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TulaHealthCodeChallenge.API.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class CSVFileUploadController : ControllerBase
    {
        private readonly TablesContext _context;

        public CSVFileUploadController(TablesContext context)
        {
            _context = context;
        }

        // POST api/<CSVFileUploadController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] FileModel file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }

                Tuple<List<Order>, List<Ticket>> resultsTuple;

                using (StreamReader reader = new StreamReader(path))
                {
                    var csv = reader.ReadToEnd();
                    var csvParser = new CSVParser();
                    resultsTuple = csvParser.ParseWithRegularExpressions(csv);
                }

                var orders = resultsTuple.Item1;

                foreach (var order in orders)
                {
                    _context.Orders.Add(order);
                }

                var tickets = resultsTuple.Item2;

                foreach (var ticket in tickets)
                {
                    _context.Tickets.Add(ticket);
                }
                _context.Database.OpenConnection();

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders ON");

                await _context.SaveChangesAsync();

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Orders OFF");

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
