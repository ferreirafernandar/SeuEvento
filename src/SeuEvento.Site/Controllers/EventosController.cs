using Microsoft.AspNetCore.Mvc;
using SeuEvento.Application.Interfaces;
using SeuEvento.Application.ViewModels;
using System;

namespace SeuEvento.Site.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoAppService _eventoAppService;

        public EventosController(IEventoAppService eventoAppService)
        {
            _eventoAppService = eventoAppService;
        }

        // GET: Eventos
        public IActionResult Index() => View(_eventoAppService.ObterTodos());

        // GET: Eventos/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null) return NotFound();

            var eventoViewModel = _eventoAppService.ObterPorId(id.GetValueOrDefault());

            if (eventoViewModel == null)
                return NotFound();

            return View(eventoViewModel);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return View(eventoViewModel);

            _eventoAppService.Registrar(eventoViewModel);

            return RedirectToAction("Index");
        }

        // GET: Eventos/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var eventoViewModel = _eventoAppService.ObterPorId(id.GetValueOrDefault());

            if (eventoViewModel == null)
                return NotFound();

            return View(eventoViewModel);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return View(eventoViewModel);

            _eventoAppService.Atualizar(eventoViewModel);

            return View(eventoViewModel);
        }

        // GET: Eventos/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var eventoViewModel = _eventoAppService.ObterPorId(id.GetValueOrDefault());

            if (eventoViewModel == null)
                return NotFound();

            return View(eventoViewModel);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _eventoAppService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
