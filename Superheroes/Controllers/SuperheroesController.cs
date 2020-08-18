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
            List<Superhero> superheroList = new List<Superhero>();
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
            Superhero superhero = new Superhero();
            return View(superhero);
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Superhero superhero = _dbContext.Superheroes.Where(s => s.Id == id).Single();
                superhero.Name = collection.Where(i => i.Value == superhero.Name).ToString();
                superhero.AlterEgo = collection.Where(i => i.Value == superhero.AlterEgo).ToString();
                superhero.PrimaryAbility = collection.Where(i => i.Value == superhero.PrimaryAbility).ToString();
                superhero.SecondaryAbility = collection.Where(i => i.Value == superhero.SecondaryAbility).ToString();
                superhero.Catchphrase = collection.Where(i => i.Value == superhero.Catchphrase).ToString();
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
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
