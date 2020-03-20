using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class PageDto<TContent>
    {
        public PageDto(int size, int number)
        {
            Size = Math.Min(Math.Max(size, 0), 50);
            Number = Math.Max(number, 0);
        }

        public void SetData(int total, IEnumerable<TContent> list)
        {
            List = list ?? new List<TContent>();
            TotalItems = Math.Max(total, 0);
            TotalPages = (TotalItems / Size) + 1;
        }

        public int Size { get; }
        public int Number { get; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<TContent> List { get; private set; }
    }
}