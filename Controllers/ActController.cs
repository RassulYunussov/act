using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using act.Models;
using act.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ViewModels;

namespace act.Controllers
{
    public class ActController:Controller
    {
        ApplicationDbContext _ctx;
        List<Service> services = new List<Service>();
        public ActController (ApplicationDbContext ctx)
        {
          _ctx = ctx;
          services.Add(new Service(){Id = 1, Name = "Service 1", Price = 10.0M, Measure = "ед."});
          services.Add(new Service(){Id = 2, Name = "Service 2", Price = 20.0M, Measure = "шт."});
          services.Add(new Service(){Id = 3, Name = "Service 3", Price = 30.0M, Measure = "ед."});
          services.Add(new Service(){Id = 4, Name = "Service 4", Price = 40.0M, Measure = "ед."});
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ctx.Acts.ToListAsync());
        }
        public async Task<IActionResult> View(int? id)
        {
            if(id==null)
                return NotFound();
            var act = await _ctx.Acts.Include(a=>a.Services).SingleOrDefaultAsync(x=>x.Id==id);
            if(act==null)
                return NotFound();
            return View(act);
        }
        public IActionResult Create()
        {
            ViewBag.services = services;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ClientName,SupplierName,DocumentNumber,Date,ClientBin,SupplierBin")]Act act, IEnumerable<ServiceViewModel> service)
        {               
            if(ModelState.IsValid)
            {
                if(act.DocumentNumber==null)
                {
                    act.DocumentNumber = await _ctx.Acts.MaxAsync(x=>x.DocumentNumber)??0;
                    act.DocumentNumber++;   
                }
                else
                {
                    bool alreadyExist = await _ctx.Acts.AnyAsync(x=>x.DocumentNumber==act.DocumentNumber);
                    if(alreadyExist)
                    {
                        ModelState.AddModelError("DocumentNumber","Документ с таким номером уже существует");
                        return View(act);
                    }   
                }
                foreach(var s in service)
                {
                    if(s.Checked)
                    {
                        ActService actService = new ActService(){Name=this.services[s.Id].Name,Price=this.services[s.Id].Price,Amount=s.Amount};
                        act.Services.Add(actService);
                    }
                }
                _ctx.Add(act);
                await _ctx.SaveChangesAsync();
                return RedirectToAction("index");
            }
            else
                return View(act);
            
        }
        public async Task<IActionResult> Edit(int id)
        {
            var act = await _ctx.Acts.Include(a=>a.Services).SingleOrDefaultAsync(x=>x.Id==id);
            if(act==null)
                return NotFound();
            return View(act);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Act act)
        {

            if(ModelState.IsValid)
            {
                try
                {
                    _ctx.Update(act);
                    await _ctx.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    if (_ctx.Acts.SingleAsync(x=>x.Id == act.Id)==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
              
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (_ctx.Acts.SingleAsync(x=>x.Id == id)==null)
            {
                return NotFound();
            }
            else
            {
                Act act = await _ctx.Acts.SingleAsync(x=>x.Id == id);
                _ctx.Acts.Remove(act);
                await _ctx.SaveChangesAsync();
                return RedirectToAction("index");
            }
           
        }
        public async Task<IActionResult> ServiceDelete(int id,int serviceId)
        {
            ActService actService = await _ctx.ActServices.SingleAsync(s=>s.Id==serviceId);
            _ctx.ActServices.Remove(actService);
            await _ctx.SaveChangesAsync();
            return RedirectToAction("edit",new {id=id});
        }
    }
}