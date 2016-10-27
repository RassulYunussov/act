using System.Collections.Generic;
using System.Threading.Tasks;
using act.Data;
using act.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace act.ViewComponents
{
    public class ServicesViewComponent:ViewComponent
    {
        readonly ApplicationDbContext _ctx;
        public ServicesViewComponent (ApplicationDbContext ctx)
        {
          _ctx = ctx;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _ctx.Services.ToListAsync();
            return View(services);
        }
    }
}