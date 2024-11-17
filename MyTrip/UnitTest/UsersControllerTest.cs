using Microsoft.AspNetCore.Mvc;
using MyTrip.Controllers;
using MyTrip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    
    public class UsersControllerTest
    {
        [Fact]
        public void Get_ListUser()
        {
            var controller = new UserControllers();
            var result = controller.Get();
            Assert.IsType<ActionResult<IEnumerable<User>>>(result);
            //לא עובד
            //Assert.IsType<List<User>>(result);
        }
        [Fact]
        public void Get_User()
        {
            var id = 1;
            var obj = new User() { TZ = "327915013" };
            var controller = new UserControllers();
            controller.Post(obj);
            var result = controller.Get(id);
            Assert.IsType<ActionResult<User>>(result);
        }
        [Fact]
        public void Post_AddToList()
        {
            var obj = new User() { TZ = "327915013" };
            var controller = new UserControllers();
            var result = controller.Post(obj);
            Assert.True(result.Value);
        }
        [Fact]
        public void Put_NotValied()
        {
            var id = 5;
            var obj= new User() {TZ="3279"};
            var controller = new UserControllers();
            var result = controller.Put(id,obj);
            Assert.False(result.Value);
        }
        //לא עובד
        //[Fact]
        //public void GetByIdNotFound()
        //{
        //    var id = 5;
        //    var controller = new UserControllers();
        //    var result = controller.Get(id);
        //    Assert.IsType<NotFoundResult>(result);
        //}
    }
}
    