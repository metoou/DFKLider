using DFKLider.Domains;
using DFKLider.Domains.Entities;
using DFKLider.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFKLider.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoachesEditController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public CoachesEditController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Edit(Guid id)
        {  
            var entity = id == default ? new Coach() : dataManager.Coaches.GetCoachById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Coach model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                //TODO add image to Model

                //if (titleImageFile != null)
                //{
                //    model.TitleImagePath = titleImageFile.FileName;
                //    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                //    {
                //        titleImageFile.CopyTo(stream);
                //    }
                //}
                dataManager.Coaches.SaveCoach(model);
                return RedirectToAction(nameof(CoachesHomeController.Index), nameof(CoachesHomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Coaches.DeleteCoach(id);
            return RedirectToAction(nameof(CoachesHomeController.Index), nameof(CoachesHomeController).CutController());
        }
    }
}
