using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ehrmadesimple.Models;
using MySql.Data.MySqlClient;

namespace ehrmadesimple.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class tempController : ControllerBase
    {
        [HttpGet]
        public string getdata() {
            MySqlContext context = HttpContext.RequestServices.GetService(typeof(ehrmadesimple.Models.MySqlContext)) as MySqlContext;
            string output = "";
            using (MySqlConnection conn = context.getConnection()) {
                conn.Open();
                MySqlCommand query = new MySqlCommand("select * from EVENTS", conn);
                using(var reader = query.ExecuteReader()) {
                    while(reader.Read()) {
                        output = reader["table"].ToString();
                    }
                }
                return output;
            }
        }
        
    }
}
