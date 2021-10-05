using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroDeSeries.MVC.Data;
using CadastroDeSeries.MVC.Models;
using CadastroDeSeries.MVC.Services;

namespace CadastroDeSeries.MVC.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;

        public SeriesController(SeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        public IActionResult Index()
        {
            var list = _seriesService.ListarTudo();

            return View(list);
        }

        public IActionResult Create()
        {
            var list = _seriesService.ListarGenero();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Serie serie)
        {
            _seriesService.Inserir(serie);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _seriesService.SelecionarPorId(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _seriesService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _seriesService.SelecionarPorId(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _seriesService.SelecionarPorId(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
    }
}
