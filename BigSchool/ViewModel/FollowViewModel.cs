using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModel
{
    public class FollowViewModel
    {
        public IEnumerable<Following> Followings { get; set; }
        //public bool showFollow { get;set; }
        public bool showAction { get; set; }
    }
}