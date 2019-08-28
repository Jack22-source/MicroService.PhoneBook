using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.PhoneBook.Service.Domain
{
    public class EditEntry
    {
        /// <example>ABSA</example>
        public string Name { get; set; }
        /// <example>0219175100</example>
        public string PhoneNumber { get; set; }

    }
}
