using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperheroesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SuperheroesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SuperheroController
        public ActionResult Index()
        {
            // query to return a table and pass in
            var superheroList = _dbContext.Superheroes;
            return View(superheroList);
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = _dbContext.Superheroes.Find(id);
            return View(superhero);
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _dbContext.Superheroes.Add(superhero);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = _dbContext.Superheroes.Where(s => s.Id == id).Single();
            return View(superhero);
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superheroUpdate)
        {
            try
            {
                Superhero superhero = _dbContext.Superheroes.Where(s => s.Id == id).Single();
                superhero.Name = superheroUpdate.Name;
                superhero.AlterEgo = superheroUpdate.AlterEgo;
                superhero.PrimaryAbility = superheroUpdate.PrimaryAbility;
                superhero.SecondaryAbility = superheroUpdate.SecondaryAbility;
                superhero.Catchphrase = superheroUpdate.Catchphrase;
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = _dbContext.Superheroes.Where(s => s.Id == id).Single();
            return View(superhero);
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Superhero superhero)
        {
            try
            {
                _dbContext.Superheroes.Remove(superhero);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
