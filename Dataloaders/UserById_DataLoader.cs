

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;

namespace BCPTest
{

    public class UserByIdDataLoader : BatchDataLoader<string, GQL_User>
    {

        public UserByIdDataLoader(
            IBatchScheduler scheduler) : base(scheduler)
        {

        }

        protected override async Task<IReadOnlyDictionary<string, GQL_User>> LoadBatchAsync(
            IReadOnlyList<string> keys,
            CancellationToken cancellationToken)
        {

            // Dummy return empty data
            return new List<GQL_User>().ToDictionary(e => e.Guid, null);

        }
    }
}
