using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Data;
using NotesApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotesApp.Pages
{
    public class NotesModel : PageModel
    {
        private readonly AppDbContext _db;

        public NotesModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string NoteText { get; set; }

        public List<Note> Notes { get; set; }

        public void OnGet()
        {
            Notes = _db.Notes.OrderByDescending(n => n.CreatedAt).ToList();
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(NoteText))
            {
                var note = new Note { Text = NoteText };
                _db.Notes.Add(note);
                _db.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
