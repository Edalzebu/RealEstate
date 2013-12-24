using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
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

        public ActionResult SearchProperty()
        {
            return View();
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
        public ActionResult SellPropertyForm()
        {
            var model = new SellPropertyModel();
            model.StartingDate = DateTime.Now;
            return PartialView(model);
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

        public ActionResult SellHouse()
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

        
        public ActionResult Report(long id)
        {
            return View();
        }

        public void UploadPictures(List<HttpPostedFileBase> file)
        {
            foreach (var file1 in file)
            {
                if (file1 != null && file1.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file1.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file1.SaveAs(path);
                }
               
            }
            
        }
    }
}
