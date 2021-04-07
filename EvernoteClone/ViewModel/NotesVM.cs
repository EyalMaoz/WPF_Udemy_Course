using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public class NotesVM
    {
        private Notebook m_selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return m_selectedNotebook; }
            set { m_selectedNotebook = value; }
        }
        public ObservableCollection<Notebook> Notebooks { get; set; }

        public ObservableCollection<Note> Notes { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NotesVM()
        {
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);
        }
    }
}
