using HelpDesk.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVerification
{
    class ManageTicketTests
    {
        [Test]
        public void CrerteAndMarkTicketSolved()
        {
            var inputDesc = "Hello, I have problems with...";

            var ticket = new Ticket(inputDesc, null);
            ticket.markSolved();
            Assert.That(ticket.isSolved(), Is.True);
        }
    }
}
