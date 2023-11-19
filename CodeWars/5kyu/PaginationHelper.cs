namespace CodeWars._5kyu
{
    using System.Collections.Generic;

    public class PaginationHelper<T>
    {
        // TODO: Complete this class
        private readonly IList<T> _items;
        private readonly int _pageSize;
        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PaginationHelper(IList<T> collection, int itemsPerPage)
        {
            _items = collection;
            _pageSize = itemsPerPage;
        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount
        {
            get
            {
                return _items.Count;
            }
        }

        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount
        {
            get
            {
                if (_items.Count == 0)
                {
                    return 0;
                }
                if (_items.Count % _pageSize == 0)
                {
                    return _items.Count / _pageSize;
                }
                return _items.Count / _pageSize + 1;
            }
        }

        /// <summary>
        /// Returns the number of items in the page at the given page index 
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex)
        {
            if (pageIndex * _pageSize >= _items.Count || pageIndex < 0)
            {
                return -1;
            }

            var count = _items.Count - (pageIndex * _pageSize);
            return count > _pageSize ? _pageSize : count;
        }

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex)
        {
            if (itemIndex >= _items.Count || itemIndex < 0)
            {
                return -1;
            }
            return itemIndex / _pageSize;

        }
    }
}
