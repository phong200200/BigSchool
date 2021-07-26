using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace BigSchool.Controllers.Api
{
    public class FollowingsController : ApiController
    {

        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists");
            var following = new Following {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        } 

        [HttpDelete]
        public IHttpActionResult Unfollow(string followeeId)
        {
            var userId = User.Identity.GetUserId();
            if(userId == followeeId)
            {
                return BadRequest("U can't unfollow yourself?");
            }
            var following = _dbContext.Followings.FirstOrDefault(a => a.FolloweeId == followeeId && a.FollowerId == userId);

            if(following != null)
            {
                _dbContext.Followings.Remove(following);
                _dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}