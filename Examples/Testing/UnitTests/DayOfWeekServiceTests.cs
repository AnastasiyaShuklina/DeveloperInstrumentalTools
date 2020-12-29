using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayOfWeekServiceTests
    {
        private DayOfWeekService service = new DayOfWeekService();

        [Test]
        public void weekendTrue2020()
        {
            var first = new DateTime(2020, 11, 21);
            var second = new DateTime(2020, 11, 22);
            service.IsWeekend(first).Should().Be(true);
            service.IsWeekend(second).Should().Be(true);
        }

        [Test]
        public void weekendTrue()
        {
            var first = new DateTime(1989, 7, 1);
            var second = new DateTime(1989, 7, 2);
            service.IsWeekend(first).Should().Be(true);
            service.IsWeekend(second).Should().Be(true);
        }

        [Test]
        public void weekendFalse()
        {
            var first = new DateTime(1989, 7, 4);
            var second = new DateTime(1989, 7, 3);

            service.IsWeekend(first).Should().Be(false);
            service.IsWeekend(second).Should().Be(false);
        }
    }
}