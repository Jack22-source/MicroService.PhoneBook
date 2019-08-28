using MicroService.PhoneBook.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.PhoneBook.Repository.Model
{
    public interface IPhoneBookRepository
    {
        List<EntryModel> GetList(DataContext context, string byName, string byPhoneNumber);
        void Insert(DataContext context, List<EntryModel> models);
        void Update(DataContext context, EntryModel model);
        void Delete(DataContext context, Guid id);
    }
}
