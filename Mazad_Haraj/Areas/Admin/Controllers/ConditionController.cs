using Mazad_Haraj.Data;
using Microsoft.AspNetCore.Mvc;
using Mazad_Haraj.Models;
using Microsoft.EntityFrameworkCore;
using Humanizer;

namespace Mazad_Haraj.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ConditionController : Controller
    {
        //    HarajDbContext _dbContext;
        //    public ConditionController(HarajDbContext dbContext)
        //    {
        //        _dbContext = dbContext;
        //    }

        //    public IActionResult Index()
        //    {
        //        var condition = _dbContext.Conditions.ToList();
        //        return View(condition);
        //    }

        //    public IActionResult Create()
        //    {
        //        return View();
        //    }
        //    public async Task<IActionResult> Edit(string? Key)
        //    {
        //        var condition = await _dbContext.Conditions.FindAsync(Key);

        //        if (condition == null)
        //        {
        //            return NotFound(); 
        //        }

        //        var conditionDto = new UpdateConditionDto
        //        {
        //            KKey = condition.KKey,
        //            Title = condition.Title,
        //            KVal = condition.KVal

        //        };

        //        return View(conditionDto);
        //    }
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(UpdateConditionDto dto)
        //    {
        //        if (!ModelState.IsValid)
        //            return View("Edit", dto);

        //        Condition? existingCondition = await _dbContext.Conditions.FindAsync(dto.KKey);

        //        if (existingCondition != null)
        //        {
        //            existingCondition.KVal = dto.KVal;
        //            existingCondition.Title = dto.Title;


        //            _dbContext.Entry(existingCondition).State = EntityState.Modified;
        //            await _dbContext.SaveChangesAsync();


        //        }
        //        return RedirectToAction("Index");

        //    }
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create(CreateConditionDto dto)
        //    {
        //        if (!ModelState.IsValid)
        //            return View("Create", dto);


        //            Condition? condition = new Condition()
        //            {
        //                KKey = dto.Title,
        //                KVal = dto.KVal,
        //                Title = dto.Title,
        //                Group = "",
        //                DefaultValue = ""

        //            };
        //            await _dbContext.Conditions.AddAsync(condition);
        //            await _dbContext.SaveChangesAsync();
        //            return RedirectToAction("Index");


        //    }
        //    public async Task<IActionResult> Delete(string? Key)
        //    {
        //        if (Key == null)
        //        {
        //            return NotFound(); 
        //        }

        //        var condition = await _dbContext.Conditions.FindAsync(Key);

        //        if (condition == null)
        //        {
        //            return NotFound(); 
        //        }

        //        _dbContext.Remove(condition);
        //        await _dbContext.SaveChangesAsync(); 

        //        return RedirectToAction("Index");

        //    }
        //}
    }
}
