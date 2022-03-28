using WebApiNote.Models;
namespace WebApiNote.Service
{
    public interface IServiceNote
    {
        List<Note> GetAll();
        void UpLoad (string path);
        void Convert ();
        void WriteToFile(string path);

    }
}
