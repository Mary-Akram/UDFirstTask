using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UDFirstTask.Data;
using UDFirstTask.DTOs;
using UDFirstTask.Repositories.Interfaces;

namespace UDFirstTask.Controllers
{
    public class InformationController : Controller
    {


        private readonly IInformationRepository _informationRepository;
        private readonly ILogger<InformationController> _logger;

        public InformationController(IInformationRepository informationRepository, ILogger<InformationController> logger)
        {
            _informationRepository = informationRepository;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var informationList = await _informationRepository.GetAllAsync();
            return View(informationList);
        }

        // GET: InformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveInfo(NewInformationDTO newInformation)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _informationRepository.AddAsync(newInformation);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the SaveInfo action");
                    return View("~/Views/Shared/_Error.cshtml");
                }

            }
            return View(newInformation);

        }

        public async Task<ActionResult> ViewDetails(int id)
        {
            var informationEntity = await _informationRepository.GetByIdAsync(id);
            var information = new InformationDetailsDto
            {
                EnglishTitle = informationEntity.EnglishTitle,
                ArabicTitle = informationEntity.ArabicTitle,
                EnglishDescription = informationEntity.EnglishDescription,
                ArabicDescription = informationEntity.ArabicDescription,
                ImagePath = informationEntity.ImagePath
            };

            if (information == null)
            {

                return View("~/Views/Shared/_PageNotFound.cshtml");
            }

            return View(information);
        }


    }
}
