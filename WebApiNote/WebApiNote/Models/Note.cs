namespace WebApiNote.Models
{


    public class Note
    {
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; }= string.Empty;
        public DateTime CreatedNote { get; set; }
        public string Tag { get; set; } = string.Empty ;
    }
}
