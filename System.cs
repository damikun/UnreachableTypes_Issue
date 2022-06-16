
using System;
using HotChocolate.Types;

namespace BCPTest
{

    /// <summary>
    ///  System Queries
    /// </summary>
    [ExtendObjectType(OperationTypeNames.Query)]
    public class SystemQueries
    {
        public SystemQueries(){

        }

        /// <summary>
        /// Return server current date-time
        /// </summary>
        /// <returns>DateTime as current date time</returns>
        public DateTime GetServerDateTime() => DateTime.Now;

    }
}
