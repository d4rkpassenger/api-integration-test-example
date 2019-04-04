using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace time.engine.api.Attributes
{
    public class Version_1Attribute : ApiVersionAttribute
    {
        public Version_1Attribute() : base(new ApiVersion(1, 0))
        {
        }

        public override object TypeId => base.TypeId;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
