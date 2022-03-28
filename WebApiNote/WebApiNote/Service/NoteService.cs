using System.Text.RegularExpressions;
using WebApiNote.Models;

namespace WebApiNote.Service
{
    public class NoteService : IServiceNote
    {
        private List<Note> _notes { get; }
        private List<string> _note = new();
        public NoteService () => _notes = new();
        public List<Note> GetAll ()
        {
            return _notes;
        }

        public void UpLoad ( string path )
        {
            using StreamReader reader = new StreamReader(path);
            string? line;
            while((line = reader.ReadLine()) != null)
                _note.Add(line);
        }

        public void Convert ()
        {
            for (int i = 0; i < _note.Count; i++)
            {
                _note[i] = Regex.Replace(_note[i],@"[^0-9a-zA-Z:,.#]+","");
            }

            _note.RemoveAll(x => string.IsNullOrEmpty(x));

            for (int i = 0; i < _note.Count; i+=4)
            {
                _notes.Add(new Note { Name = _note[i],Text = _note[i+1],CreatedNote = DateTime.Parse(_note[i+2]),Tag = _note[i+3] });
            }
        }

        public void WriteToFile ( string path )
        {
            using StreamWriter writer = new(path, false);
            foreach (var item in _note)
            {
                writer.WriteLine(item);
            }
        }
    }
}
