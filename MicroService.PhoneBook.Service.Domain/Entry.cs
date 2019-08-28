using System;

namespace MicroService.PhoneBook.Service.Domain
{
    public class Entry
    {
        /// <example>17779209-ba3a-4d4b-a589-d573e047f0d8</example>
        public Guid Id { get; set; }
        /// <example>ABSA</example>
        public string Name { get; set; }
        /// <example>0219175100</example>
        public string PhoneNumber { get; set; }

    }
}
