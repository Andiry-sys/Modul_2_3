using System.Text.RegularExpressions;
using WebApiContact.Models;

namespace WebApiContact.Service
{
    public class ContactService : IServiceContact
    {
        private List<Contact> _contacts { get; }
        private List<string> _contact = new();
        public ContactService()=> _contacts = new();  
        public List<Contact> GetAll ()
        {
            return _contacts;
        }

        public void Upload ( string path )
        {
            using StreamReader reader = new(path);
            string? line;
            while ((line = reader.ReadLine()) != null)
                _contact.Add(line);
        }

        public void WriteToFile ( string path )
        {
            using StreamWriter writer = new(path,false);
            foreach (var item in _contact)
            {
                writer.WriteLine(item);
            }
        }

        public void Convert ()
        {
            for (int i = 0; i < _contact.Count; i++)
            {
                _contact[i] = Regex.Replace(_contact[i],@"[^0-9a-zA-Z:,.#]+","");
            }

            _contact.RemoveAll(x=> string.IsNullOrEmpty(x));

            for (int i = 0; i < _contact.Count; i+=5)
            {
                _contacts.Add(new Contact { Name = _contact[i] , PhoneMobile = _contact[i+1], ReservPhoneMobile = _contact[i+2], Email = _contact[i+3], ShortDescription = _contact[i+4]});
            }
        }
    }
}
