using ManagementSystem.Models;
using ManagementSystem.Repositories;
using ManagementSystem.Services.Interfaces;

namespace ManagementSystem.Services
{
    public class StockService : IStockService
    {
        StockRepository stockRepository = new StockRepository(); //TEMPORÁRIO
        public Item UpdateItemInfo(int id, Item updatedItem)
        {
            //Finding the item to be edited by ID
            Item toBeEdited = stockRepository.GetById(id);

            if (toBeEdited == null) //In case the item with the given ID does not exist
            {
                throw new ArgumentException("Item not found");
            }

            //Editing general properties
            toBeEdited.SKU = updatedItem.SKU;
            toBeEdited.brand = updatedItem.brand;
            toBeEdited.Modalities = updatedItem.Modalities;
            toBeEdited.Name = updatedItem.Name;
            toBeEdited.Image = updatedItem.Image;
            toBeEdited.Description = updatedItem.Description;
            toBeEdited.Price = updatedItem.Price;
            toBeEdited.ManufacturedIn = updatedItem.ManufacturedIn;

            //Editing specific properties based on the type of item
            if (updatedItem is Equipment eqpUpd && toBeEdited is Equipment eqpEdit)
            {
                eqpEdit.Specifications = eqpUpd.Specifications;
            }
            else if (updatedItem is Footwear fwUpd && toBeEdited is Footwear fwEdit)
            {
                fwEdit.Size = fwUpd.Size;
                fwEdit.Type = fwUpd.Type;
            }
            else //In case of an unsupported item type
            {
                throw new ArgumentException("Invalid item type for update");
            }

            return toBeEdited; 
        }
    }
}