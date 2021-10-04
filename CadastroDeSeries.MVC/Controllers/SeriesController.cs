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
            return View();
        }
    }
}
