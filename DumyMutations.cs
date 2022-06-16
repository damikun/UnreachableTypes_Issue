
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BCPTest
{

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class DumyMutations
    {
        /// <summary>
        /// Create new  webhook
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Dummy()
        {
            return true;
        }
    }
}