using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BootstrapMvcSample.Controllers;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Services;
using RealEstate.Web.Models;

namespace RealEstate.Web.Controllers
{
    public class PropertiesController : BootstrapBaseController
    {
        //
        // GET: /Properties/
         private readonly IRepository _repository;
        

        public PropertiesController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListProperties()
        {
            var listcontent = new List<ListPropertiesModel>();
            var properties = _repository.GetAll<Property>();
            foreach (var property in properties)
            {
                var model = Mapper.Map<Property, ListPropertiesModel>(property);
                model.Owner = _repository.First<Account>(x => x.Id == property.DueñoId).Username;
                model.ImageUrl = "Test.jpg";
                
                listcontent.Add(model);
            }
            return View(listcontent);
        }

        [HttpGet]
        public ActionResult SellProperty()
        {
            var model = new SellPropertyModel();
            model.StartingDate = DateTime.Now;
            return View(model);
        }
        
        [HttpPost]
        public ActionResult SellProperty(SellPropertyModel propertyModel)
        {
            var nuevaPropiedad = Mapper.Map<SellPropertyModel,Property>(propertyModel);
            var account = _repository.First<Account>(x => x.Email == User.Identity.Name);
            nuevaPropiedad.DueñoId = account.Id;
            _repository.Create(nuevaPropiedad);

            Success("Se ha creado la propiedad");
            return RedirectToAction("ListProperties", "Properties");
        }

        public ActionResult SellHouse(long id)
        {
            return PartialView(new SellHouseModel());
        }
        [HttpGet]
        public ActionResult ShowGallery(long id)
        {
            return PartialView();
        }

        public ActionResult Property(long id)
        {
            var propiedad = _repository.First<Property>(x => x.Id == id);
            var account = _repository.First<Account>(x => x.Id == propiedad.DueñoId);

            var model = Mapper.Map<Property, PropertyProfileModel>(propiedad);
            
            return View(model);
        }

        public ActionResult Profile(long id)
        {
            var propiedad = _repository.First<Property>(x => x.Id == id);
            var account = _repository.First<Account>(x => x.Id == propiedad.DueñoId);

            return View();
        }

        public ActionResult Report(long id)
        {
            return View();
        }
    }
}
