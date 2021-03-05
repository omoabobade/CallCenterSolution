using System;
using Xunit;
using CallCenter;

namespace XUnitTestCallCenter
{
    public class UnitTest1
    {
        [Fact]
        public void TestSuppliedDateIsSunday()
        {
            var dte = "Mar 7, 2021 1pm";
            var check = CallCenterTimeMgt.CheckIfDateIsSunday(DateTime.Parse(dte));
            Assert.True(check);
        }

        [Fact]
        public void TestSuppliedDateAndTimeIsWithinOperatingHour()
        {
            var dte = "Mar 6, 2021 10am";
            var check = CallCenterTimeMgt.TimeisWithinOperatingHour(DateTime.Parse(dte), "9am", "12pm");
            Assert.True(check);
        }

        [Fact]
        public void TestSuppliedDateAndTimeIsEqualToOrMoreThan2Hours()
        {
            var dte = DateTime.Now.AddHours(3);
            var check = CallCenterTimeMgt.CheckTimeisMoreThan2Hours(dte);
            Assert.True(check);
        }

        [Fact]
        public void TestSuppliedDateAndTimeIsNotMoreThan6Days()
        {
            var dte = DateTime.Now.AddDays(7);
            var check = CallCenterTimeMgt.CheckTimeIsLessThan6Days(dte);
            Assert.False(check);
        }
    }
}
