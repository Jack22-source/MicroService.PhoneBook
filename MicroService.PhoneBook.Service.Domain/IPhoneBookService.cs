using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.PhoneBook.Service.Domain
{
    public interface IPhoneBookService
    {
        List<Entry> GetPhoneBookEntries(string byName, string byPhoneNumber);
        List<Entry> SaveEntries(List<EditEntry> entries);
        void Update(Guid id, EditEntry entry);
        void Delete(Guid id);
    }
}
