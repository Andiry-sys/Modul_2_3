using WebApiContact.Models;

namespace WebApiContact.Service
{
    public interface IServiceContact
    {
        List<Contact> GetAll();
        void Upload ( string path );
        void Convert ();
        void WriteToFile(string path);
    }
}
