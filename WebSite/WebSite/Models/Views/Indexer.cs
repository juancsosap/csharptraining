using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Models.Views
{
    public class Indexer<T> : Paginator
    {
        public List<T> Data { get; set; }

        public Indexer(List<T> Data, Int32 Count, Int32 Limit = 10, Int32 Offset = 0) : base(Count, Limit, Offset)
        {
            this.Data = Data;
        }

        public override IndexerFilter GetPrevious()
        {
            return new IndexerFilter() { limit = Limit, offset = GetPreviousOffset() };
        }

        public override IndexerFilter GetNext()
        {
            return new IndexerFilter() { limit = Limit, offset = GetNextOffset() };
        }

        public override IndexerFilter GetFirst()
        {
            return new IndexerFilter() { limit = Limit, offset = 0 };
        }

        public override IndexerFilter GetLast()
        {
            return new IndexerFilter() { limit = Limit, offset = (GetTotalPages() - 1) * Limit };
        }

        public override IndexerFilter GetPage(int index)
        {
            return new IndexerFilter() { limit = Limit, offset = Limit * (index - 1) }; ;
        }
    }
}