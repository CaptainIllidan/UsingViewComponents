﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", repository.Cities);
            }
            return View(new CityViewModel
            {
                Cities = repository.Cities.Count(),
                Population = repository.Cities.Sum(c => c.Population)
            });
        }
    }
}
