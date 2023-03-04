using System.Collections.Generic;

namespace Core.Domain.Model
{
    public class PaginatedListModel<T>
    {
        public List<T> Items { get; private set; }
        public int Count { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }


        public PaginatedListModel(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            Count = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}