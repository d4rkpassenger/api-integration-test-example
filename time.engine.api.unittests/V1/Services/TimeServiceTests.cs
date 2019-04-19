using System;
using System.Collections.Generic;
using System.Text;
using time.engine.api.V1.Services;
using Xunit;

namespace time.engine.api.unittests.V1.Services
{
    public class TimeServiceTests
    {

        [Fact]
        public void CurrentDate_Returns_ValidDate()
        {
            var target = new TimeService();

            var result = target.CurrentDate();

            Assert.NotEqual(default(DateTime), result);
        }
    }
}
