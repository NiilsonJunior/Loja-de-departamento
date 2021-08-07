using Microsoft.AspNetCore.Mvc;
using NiilsonProjetoDeBDD.Services;
using NiilsonProjetoDeBDD.Models;
using System;
using NiilsonProjetoDeBDD.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NiilsonProjetoDeBDD.Services.NewFolder;
using NiilsonProjetoDeBDD.Services.Exceptions;
using System.Diagnostics;

namespace NiilsonProjetoDeBDD.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;
        private readonly SellerService _sellerService;

        public SalesRecordsController(SellerService sellerService, SalesRecordService salesRecordService, DepartmentService departmentService)
        {
            _salesRecordService = salesRecordService;
            _sellerService = sellerService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            SalesRecord salesRecord = new SalesRecord();
            ViewBag.ListSellers = await _sellerService.FindAllAsync();
            return View(salesRecord);

        }
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Create(SalesRecord salesRecord)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var departments = await _departmentService.FindAllAsync();
        //        var ViewModel = new  { Se , Departments = departments };
        //        return View(ViewModel);
        //    }
        //    await _salesRecordService.InsertAsync(seller);
        //    return RedirectToAction(nameof(Index));
        //}
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
