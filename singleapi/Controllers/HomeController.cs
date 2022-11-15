using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using singleapi.Models;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace singleapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public readonly IConfiguration _Config;
        public HomeController(IConfiguration Config)
        {
            _Config = Config;
        }

        [HttpGet]
        //public async Task<ActionResult<List<name>>> GetallName()
        public async Task<ActionResult<List<name>>> GetallName()
        {

            var Connection = new SqlConnection(_Config.GetConnectionString("UserDBConnection"));
            var Connections = new SqlConnection(_Config.GetConnectionString("DefaultConnection"));
            var heroes = await Connection.QueryAsync<name>("select * FROM name;");
            var home = await Connections.QueryAsync<book>("select * from book");

            var tamil = (from a in heroes
                        join b in home on a.Id equals b.id

                        select new
                        {
                            a.Id
                        }).AsEnumerable().Select(x => new name()
                        {
                            Id = x.Id,
                           
                        }
                       ).ToList();


            return tamil;

        }
        //[HttpGet]
        //public async Task<ActionResult<List<book>>>Getallbook()
        //{
        //    using var Connection = new SqlConnection(_Config.GetConnectionString("DefaultConnection"));
        //    var books = await Connection.QueryAsync<book>("select * from book");
        //    return Ok(books);
        //}



    }
}
