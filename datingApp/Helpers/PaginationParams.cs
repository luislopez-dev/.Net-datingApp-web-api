
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
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}