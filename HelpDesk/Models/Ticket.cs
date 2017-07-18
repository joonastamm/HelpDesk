using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk.Models
{
    public class Ticket
    {
        private string Id;
        private string Description;
        private DateTime EntryDate;
        private DateTime DueDate;
        private bool Solved;

        public Ticket(string description, DateTime? duedate)
        {
            Description = description;
            DueDate = duedate.HasValue ? (DateTime)duedate : DateTime.MaxValue;
            EntryDate = DateTime.Now;
            Solved = false;
            Id = Guid.NewGuid().ToString();
        }

        public void markSolved()
        {
            this.Solved = true;
        }

        public bool isSolved()
        {
            return this.Solved;
        }

        public string getId()
        {
            return this.Id;
        }

        public string getDescription()
        {
            return this.Description;
        }

        public DateTime getDueDate()
        {
            return this.DueDate;
        }

        public DateTime getEntryDate()
        {
            return this.EntryDate;
        }

    }

}