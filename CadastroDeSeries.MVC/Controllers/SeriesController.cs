using CadastroDeSeries.MVC.Models;
using CadastroDeSeries.MVC.Services;
using CadastroDeSeries.MVC.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CadastroDeSeries.MVC.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;

        public SeriesController(SeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _seriesService.ListarTudoAsync();
            
            return View(list);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Serie serie)
        {
            if (!ModelState.IsValid)
                return View(serie);

            await _seriesService.InserirAsync(serie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

            var obj = await _seriesService.SelecionarPorIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _seriesService.RemoverAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
             
            var obj = await _seriesService.SelecionarPorIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

            var obj = await _seriesService.SelecionarPorIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id, Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return View(serie);
            }

            if (id != serie.Id)
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });

            try
            {
                await _seriesService.UpdateAsync(serie);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
