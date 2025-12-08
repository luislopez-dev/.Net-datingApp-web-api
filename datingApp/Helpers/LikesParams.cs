
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingApp.Helpers
{
    /// <summary>
    /// </summary>
    /// <remarks>
    /// Author: Luis López  
    /// GitHub: https://github.com/luislopez-dev
    /// Description: Training Project
    /// </remarks>
    public class LikesParams : PaginationParams
    {
        public int UserId { get; set; }
        public string Predicate { get; set; }
    }
}