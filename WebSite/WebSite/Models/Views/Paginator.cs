using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models.Views
{
    public abstract class Paginator
    {
        public Int32 Limit { get; set; }
        public Int32 Offset { get; set; }
        public Int32 Count { get; set; }

        public Paginator(Int32 Count, Int32 Limit = 10, Int32 Offset = 0)
        {
            this.Limit = Limit;
            this.Offset = Offset;
            this.Count = Count;
        }
        
        public Int32 GetTotalPages()
        {
            return GetPreviousPages() + GetNextsPages() + 1;
        }

        public Int32 GetPreviousPages()
        {
            return (Int32) Math.Ceiling((Double)Offset / Limit);
        }

        public Int32 GetNextsPages()
        {
            return (Int32) Math.Ceiling((Double)(Count - Offset) / Limit) - 1;
        }

        public Int32 GetCurrentPage()
        {
            return GetPreviousPages() + 1;
        }

        public Boolean HasNextPage()
        {
            return GetNextsPages() > 0;
        }

        public Boolean HasPreviousPage()
        {
            return GetPreviousPages() > 0;
        }

        protected Int32 GetNextOffset()
        {
            return (Count - Offset) > Limit ? Offset + Limit : Offset;
        }

        protected Int32 GetPreviousOffset()
        {
            return Offset > Limit ? Offset - Limit : 0;
        }

        public abstract IndexerFilter GetPrevious();
        public abstract IndexerFilter GetNext();

        public abstract IndexerFilter GetFirst();
        public abstract IndexerFilter GetLast();

        public abstract IndexerFilter GetPage(int index);

    }

    public class IndexerFilter
    {
        public Int32 limit { get; set; }
        public Int32 offset { get; set; }
    }
}