using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Assignement3.model;

namespace Assignment3Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly traineedb16Context _db;
        public UserApiController(traineedb16Context db)
        {

            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Registration r)
        {
            Registration rs = new Registration();
            rs.FirstName = EnryptString(r.FirstName);
            rs.LastName = EnryptString(r.LastName);
            rs.Email = EnryptString(r.Email);
            rs.DateAdded = DateTime.Now;
            rs.ContactNo = EnryptString(r.ContactNo);
            rs.Password = EnryptString(r.Password);
            _db.Registrations.Add(rs);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            if (email != null)
            {
                string emails = EnryptString(email);

                var x = _db.Registrations.Where(x => x.Email == emails).FirstOrDefault();

                if (x != null)
                {
                    Registration rs = new Registration();
                    rs.FirstName = DecryptString(x.FirstName);
                    rs.LastName = DecryptString(x.LastName);
                    rs.Email = DecryptString(x.Email);
                    rs.DateAdded = x.DateAdded;
                    rs.LastUpadated = x.LastUpadated;
                    rs.ContactNo = DecryptString(x.ContactNo);
                    rs.Password = DecryptString(x.Password);
                    rs.RecId = x.RecId;
                    return Ok(rs);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NoContent();
            }


        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(loginViewModel l)
        {
            if (l.Email != null && l.Password != null)
            {
                string emails = EnryptString(l.Email);
                string passwords = EnryptString(l.Password);
                var x = _db.Registrations.Where(x => x.Email == emails && x.Password == passwords).FirstOrDefault();

                if (x != null)
                {
                    Registration rs = new Registration();
                    rs.Email = DecryptString(x.Email);
                    return Ok(rs);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NoContent();
            }

        }
        [HttpPut]
        public async Task<IActionResult> update(Registration x)
        {
            Registration rs = new Registration();
            rs.FirstName = EnryptString(x.FirstName);
            rs.LastName = EnryptString(x.LastName);
            rs.Email = EnryptString(x.Email);
            rs.DateAdded = x.DateAdded;
            rs.LastUpadated = DateTime.Now;
            rs.ContactNo = EnryptString(x.ContactNo);
            rs.Password = EnryptString(x.Password);

            rs.RecId = x.RecId;
            _db.Update(rs);
            _db.SaveChanges();
            return Ok();
        }


        private string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "" + fe;
            }
            return decrypted;
        }



        private string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

    }

}