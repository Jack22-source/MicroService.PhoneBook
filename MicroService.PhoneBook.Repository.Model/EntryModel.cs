using System;

namespace MicroService.PhoneBook.Repository.Model
{
    public class EntryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

    }
}
