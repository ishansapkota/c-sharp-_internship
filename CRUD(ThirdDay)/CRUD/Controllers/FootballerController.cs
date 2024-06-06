using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class FootballerController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public FootballerController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var footballer = await mvcDemoDbContext.FootballerDetails.ToListAsync();
            return View(footballer);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //These methods are declared asy
        [HttpPost]
        public async Task<IActionResult> Add(AddFootballerViewModel addFootballerDetails)
        {
            var footballer = new FootballerDetails()
            {
                Name = addFootballerDetails.Name,
                Club = addFootballerDetails.Club,
                DoB = addFootballerDetails.DoB
            };


            await mvcDemoDbContext.FootballerDetails.AddAsync(footballer);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var footballer = await mvcDemoDbContext.FootballerDetails.FirstOrDefaultAsync(x => x.id == Id);
            if (footballer != null)
            {
                var viewModel = new UpdateFootballerViewModel()
                {
                    id = footballer.id,
                    Name = footballer.Name,
                    Club = footballer.Club,
                    DoB = footballer.DoB
                };

                return await Task.Run(() => View("View",viewModel));

            }

            return RedirectToAction("Index");

        }

        [HttpPost]

        public async Task<IActionResult> View(UpdateFootballerViewModel updatefootballer)
        {
            var footballer = await mvcDemoDbContext.FootballerDetails.FindAsync(updatefootballer.id);

            if (footballer != null)
            {
                footballer.Name = updatefootballer.Name;
                footballer.Club = updatefootballer.Club;
                footballer.DoB = updatefootballer.DoB;

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(UpdateFootballerViewModel updatefootballer)
        {
            var footballer = await mvcDemoDbContext.FootballerDetails.FindAsync(updatefootballer.id);
            if (footballer != null)
            {
                mvcDemoDbContext.FootballerDetails.Remove(footballer);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
