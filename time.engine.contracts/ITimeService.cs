using System;

namespace time.engine.contracts
{
    public interface ITimeService
    {
        DateTime CurrentDateTime();
        DateTime CurrentDate();
    }
}
