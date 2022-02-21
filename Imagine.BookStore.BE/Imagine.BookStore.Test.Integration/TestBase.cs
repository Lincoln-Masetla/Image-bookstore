using NUnit.Framework;
using System.Threading.Tasks;

namespace Imagine.BookStore.Test.Integration
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
