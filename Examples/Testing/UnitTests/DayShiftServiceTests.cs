using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayShiftServiceTests
    {
        private DayShiftService service = new DayShiftService(new DayOfWeekService());

        [Test]
        public void GetShiftBusinessDayMinus()
        {
            var init = new DateTime(2020, 12, 29);
            var result = new DateTime(2019, 12, 30);

            service.GetShiftBusinessDay(init, -365).Should().Be(result);
        }

        [Test]
        public void GetShiftBusinessDayPlus()
        {
            var init = new DateTime(2019, 12, 30);

            var result = new DateTime(2020, 12, 29);

            service.GetShiftBusinessDay(init, 365).Should().Be(result);
        }

        [Test]
        public void GetShiftBusinessDay0()
        {
            var init = new DateTime(2020, 12, 29);
            var result = new DateTime(2020, 12, 29);

            service.GetShiftBusinessDay(init, 0).Should().Be(result);
        }


        [Test]
        public void GetShiftBusinessDayOneMinusOne()
        {
            var init = new DateTime(2020, 12, 29);
            var result = new DateTime(2020, 12, 28);

            service.GetShiftBusinessDay(init, -1).Should().Be(result);
        }
    }
}