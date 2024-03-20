using System.Collections.Generic;

namespace ProductsAPI.Domain.Entities
{
    public class Pagination<T> where T : class
    {
        public int Total { get; set; }
        public List<T> Items { get; set; }

        public Pagination(int total, List<T> items)
        {
            Total = total;
            Items = items;
        }
    }
}
