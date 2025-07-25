using ManagementSystem.Models;
using ManagementSystem.Models.ViewModel;
using ManagementSystem.Models.DTOs;
using ManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class FootwearController : Controller
    {
        private readonly IService<Footwear, FootwearGetAllDTO> _footwearService;

        public FootwearController(IService<Footwear, FootwearGetAllDTO> footwearService)
        {
            _footwearService = footwearService;
        }

        public IActionResult Index()
        {
            var footwearItems = _footwearService.GetAllItems();
            return View(footwearItems);
        }

        public IActionResult Details(int id)
        {
            var footwear = _footwearService.GetById(id);

            if (footwear == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsModalPartial", footwear);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FootwearCreateViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //model.Image = "";
                    var footwear = new Footwear(
                        model.SKU,
                        model.Brand,
                        model.Modalities,
                        model.Name,
                        model.Image,
                        model.Description,
                        model.Price,
                        model.ManufacturedIn,
                        model.Size,
                        model.TypeOfFootwear
                    );

                    _footwearService.EntryOfProducts(footwear);

                    TempData["SuccessMessage"] = "Calçado adicionado com sucesso!";

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao criar calçado: {ex.Message}");
                }
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var footwear = _footwearService.GetById(id);

            if (footwear == null)
            {
                return NotFound();
            }

            var viewModel = new FootwearEditViewModel
            {
                Id = footwear.Id,
                SKU = footwear.SKU,
                Brand = footwear.Brand,
                Modalities = footwear.Modalities,
                Name = footwear.Name,
                Image = footwear.Image,
                Description = footwear.Description,
                Price = footwear.Price,
                ManufacturedIn = footwear.ManufacturedIn,
                Size = footwear.Size,
                TypeOfFootwear = footwear.TypeOfFootwear
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FootwearEditViewModel model, string? returnUrl)
        {
            try
            {
                var footwear = _footwearService.GetById(id);

                if (footwear == null)
                {
                    return NotFound();
                }

                footwear.SKU = model.SKU;
                footwear.Brand = model.Brand;
                footwear.Modalities = model.Modalities;
                footwear.Name = model.Name;
                footwear.Image = model.Image;
                footwear.Description = model.Description;
                footwear.Price = model.Price;
                footwear.ManufacturedIn = model.ManufacturedIn;
                footwear.Size = model.Size;
                footwear.TypeOfFootwear = model.TypeOfFootwear;

                _footwearService.UpdateItemInfo(id, footwear);

                TempData["SuccessMessage"] = "Calçado atualizado com sucesso!";

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao carregar calçado para edição: {ex.Message}");
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var footwear = _footwearService.GetById(id);

                if (footwear == null)
                {
                    return NotFound();
                }

                _footwearService.OutOfProducts(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao excluir calçado.");
            }
        }

        [HttpPost]
        public JsonResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        {
            try
            {
                var footwear = _footwearService.GetById(request.Id);
                if (footwear == null)
                {
                    return Json(new { success = false, message = "Calçado não encontrado" });
                }

                if (request.Action == "increase")
                {
                    _footwearService.CountSumQuantity(request.Id);
                }
                else if (request.Action == "decrease")
                {
                    _footwearService.CountDecreaseQuantity(request.Id); 
                }

                var allItems = _footwearService.GetAllItems();
                var updated = allItems.FirstOrDefault(f => f.Footwear.Id == request.Id);
                int updatedQty = updated?.Quantity ?? 0;

                return Json(new { success = true, newQuantity = updatedQty });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}