using System;
using time.engine.contracts;

namespace time.engine.api.V1.Services
{
    public class TimeService : ITimeService
    {
        public DateTime CurrentDate() => DateTime.UtcNow.Date;

        public DateTime CurrentDateTime() => DateTime.UtcNow;
    }
}
