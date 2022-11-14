using Common.Enums;
using Common.System;

namespace TestWebAPI.Models.Requests
{
    public class BookQueryModel
    {
        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value < Constant.MIN_PAGE_SIZE)
                    value = Constant.MIN_PAGE_SIZE;
                else if (value > Constant.MAX_PAGE_SIZE)
                    value = Constant.MAX_PAGE_SIZE;

                _pageSize = value;
            }
        }
        public int PageNumber { get; set; }
        public string? Name { get; set; }
        public int? CategoryID { get; set; }
        public BookSortEnum? SortOption { get; set; }
    }
}
