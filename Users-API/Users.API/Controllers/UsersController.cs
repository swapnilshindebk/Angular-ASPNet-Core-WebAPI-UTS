using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Users.Application.User;
using Users.Domain.User;

namespace Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersBLL _usersBLL;
        public UsersController(UsersBLL usersBLL)
        {
            _usersBLL = usersBLL;
        }

        [HttpGet]
        public ActionResult<User> GetUsers()
        {
            try
            {
                List<User> usersList = _usersBLL.GetUsers();
                return Ok(usersList);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _usersBLL.AddUser(newUser);
                return Ok(JsonConvert.SerializeObject("User Added Successfully!"));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateUser(int id, [FromBody] User newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (id != newUser.UserID)
                return BadRequest();

            try
            {
                bool isUpdated = _usersBLL.UpdateUser(id, newUser);

                if (isUpdated == true)
                    return Ok(JsonConvert.SerializeObject("User Updated successfully!"));
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            if (id == 0)
                return BadRequest("Invalid User ID");

            try
            {
                bool isDeleted = _usersBLL.DeleteUser(id);

                if (isDeleted == true)
                    return Ok(JsonConvert.SerializeObject("User Deleted Successfully!"));
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}
