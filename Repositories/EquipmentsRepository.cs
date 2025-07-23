// using ManagementSystem.Models;
// using ManagementSystem.Repositories.Interfaces;

// namespace ManagementSystem.Repositories
// {
//     public class EquipmentRepository : IRepository<Equipment> 
//     {
//         private List<Equipment> _listEquipments;
//         private Dictionary<string, int> _equipmentsDict;

//         public EquipmentRepository()
//         {
//             _listEquipments = new List<Equipment>();
//             _equipmentsDict = new Dictionary<string, int>();
//         }

//         public void Add(Equipment item)
//         {
//             if (item == null)
//             {
//                 return;
//             }

//             if (_equipmentsDict.ContainsKey(item.SKU)) // TODO: Revisar possible null reference exception
//             {
//                 var value = _equipmentsDict.GetValueOrDefault(item.SKU);
//                 _equipmentsDict[item.SKU] = ++value;
//             }
//             else
//             {
//                 _equipmentsDict.Add(item.SKU, 1);
//             }
//             _listEquipments.Add(item);
//         }
        
//         public void Delete(int id)
//         {
//             var item = _listEquipments.FirstOrDefault(i => i.Id == id);
//             if (item != null)
//             {
//                 _listEquipments.Remove(item);
//                 if (_equipmentsDict.ContainsKey(item.SKU)) // TODO: Revisar possible null reference exception
//                 {
//                     var value = _equipmentsDict.GetValueOrDefault(item.SKU);
//                     if (value > 1)
//                     {
//                         _equipmentsDict[item.SKU] = --value;
//                     }
//                     else
//                     {
//                         _equipmentsDict[item.SKU] = 0;
//                     }
//                 }
//             }
//         }

//         public IEnumerable<Equipment> GetAll() => _listEquipments;

//         public void Update(int id, Equipment updatedItem)
//         {
//             var item = _listEquipments.FirstOrDefault(i => i.Id == id);
//             if (item != null)
//             {
//                 _listEquipments.Remove(item);
//                 _listEquipments.Add(updatedItem);
//             }
//             else
//             {
//                 return;
//             }
//         }

//         public Equipment GetById(int id) => _listEquipments.FirstOrDefault(i => i.Id == id);
//     }
// }