using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Managment.Models;
using Microsoft.CodeAnalysis.Scripting;

namespace Employee_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly EmployeeManagmentContext _context=new EmployeeManagmentContext();

        //public UserAccountsController(EmployeeManagmentContext context)
        //{
        //    _context = context;
        //}

        // GET: api/UserAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccount>>> GetUserAccounts()
        {
          if (_context.UserAccounts == null)
          {
              return NotFound();
          }
            return await _context.UserAccounts.ToListAsync();
        }

        // GET: api/UserAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccount>> GetUserAccount(int id)
        {
          if (_context.UserAccounts == null)
          {
              return NotFound();
          }
            var userAccount = await _context.UserAccounts.FindAsync(id);

            if (userAccount == null)
            {
                return NotFound();
            }

            return userAccount;
        }

        // PUT: api/UserAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccount(int id, UserAccount userAccount)
        {
            if (id != userAccount.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccount(UserAccount userAccount)
        {
          if (_context.UserAccounts == null)
          {
              return Problem("Entity set 'EmployeeManagmentContext.UserAccounts'  is null.");
          }
            _context.UserAccounts.Add(userAccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserAccountExists(userAccount.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAccount", new { id = userAccount.UserId }, userAccount);
        }






        // POST: api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login([FromBody] UserAccount loginRequest)
        {
            if (loginRequest == null  || string.IsNullOrWhiteSpace(loginRequest.PasswordHash))
            {
                return BadRequest("Invalid login request.");
            }

           if (_context == null )
            {
                return NotFound("User not found.");
            }

            // Find the user by UserName
            //var user = await _context.Users.FindAsync(loginRequest.UserName);
            var user = await _context.UserAccounts.FirstOrDefaultAsync(u => u.UserId == loginRequest.UserId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Check if the password matches
            bool isPasswordValid = loginRequest.PasswordHash == user.PasswordHash;



            if (!isPasswordValid)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(true); // Login successful
        }







        // DELETE: api/UserAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount(int id)
        {
            if (_context.UserAccounts == null)
            {
                return NotFound();
            }
            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _context.UserAccounts.Remove(userAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAccountExists(int id)
        {
            return (_context.UserAccounts?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
