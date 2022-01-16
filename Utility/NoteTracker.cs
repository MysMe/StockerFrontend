using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Utility
{
    internal class NoteTracker
    {
        private Dictionary<uint, List<String>> notes = new Dictionary<uint, List<String>>();
        private List<String> globalNotes = new List<String>();

        public void AddNote(uint Index, String Notes)
        {
            notes[Index].Add(Notes);
        }

        public void AddGlobalNote(String Notes)
        {
            globalNotes.Add(Notes);
        }

        public List<String> GetNotes(uint Index)
        {
            return notes[Index];
        }

        public List<String> GetGlobalNotes()
        {
            return globalNotes;
        }

        public bool HasNotes(uint Index)
        {
            return notes.ContainsKey(Index);
        }

        public void RemoveGlobalNote(int Index)
        {
            globalNotes.RemoveAt(Index);
        }
        
        public void RemoveNote(uint Entry, int Note)
        {
            notes[Entry].RemoveAt(Note);
        }

    }
}
