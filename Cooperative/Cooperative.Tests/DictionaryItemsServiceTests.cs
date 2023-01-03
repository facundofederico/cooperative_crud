using Cooperative.Services.Items;

namespace Cooperative.Tests;

public class DictionaryItemsServiceTests : ItemsServiceTests
{
    protected override IItemService GetService()
    {
        return new DictionaryItemService();
    }
}