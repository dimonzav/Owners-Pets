namespace DataAccess.Helpers
{
    using System.Collections.Generic;
    using DataAccess.Entities;

    public class ResponseResult<T>
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
