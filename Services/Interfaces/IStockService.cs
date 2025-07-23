using ManagementSystem.Models;
using ManagementSystem.Models.Enum;

namespace ManagementSystem.Services.Interfaces
{
    public interface IStockService // De novo só fiz alguns exemplos, não precisamos fazer exatamente assim
    {
        // void EntryOfProducts(Item item);
        // void OutOfProducts(int id);
        // int GetQuantityByBrand(Brand brand);
        // int GetQuantityByType<T>() where T : Item;
        Item UpdateItemInfo(int id, Item updatedItem);
    }
}