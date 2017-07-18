using HelpDesk.Controllers;
using HelpDesk.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVerification
{

    class CreateTicketTests
    {
        [Test]
        public void DescriptionAndNoDueDate()
        {
            var inputDesc = "I have problems with something.";
            //Console.WriteLine("Scenario: " + inputDesc);

            var ticket = new Ticket(inputDesc, null);

            /*
            var descriptionShouldBe = inputDesc;
            DateTime dueDateShouldBe = DateTime.MaxValue;
            var success = descriptionShouldBe == ticket.Description
                && dueDateShouldBe == ticket.DueDate;
            var failureMessage = "Description: '" + ticket.Description
               + "', should be: '" + descriptionShouldBe + "'" + Environment.NewLine
               + "due date: '" + ticket.DueDate + "', should be: '" + dueDateShouldBe + "'";
            Assert.That(success, failureMessage);
          */

            Assert.That(ticket.getDescription(), Is.EqualTo(inputDesc));
            Assert.That(ticket.getDueDate(), Is.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void DescriptionAndDueDate()
        {
            var inputDesc = "I have problems with something.";
            var inputDate = new DateTime(2018, 2, 3);

            var ticket = new Ticket(inputDesc, inputDate);

            Assert.That(ticket.getDescription(), Is.EqualTo(inputDesc));
            Assert.That(ticket.getDueDate(), Is.EqualTo(inputDate));
        }
    }

}
