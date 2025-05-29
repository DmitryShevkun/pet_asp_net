using System;

namespace NotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
		public string Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}