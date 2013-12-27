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
                ListPropertiesModel model;
                if (property.IsaHouse)
                {
                    var property1 = property;
                    var house = _repository.First<House>(x => x.PropertyId == property1.Id);
                    model = Mapper.Map<Property, ListPropertiesModel>(property);
                    model.Kitchens = house.Kitchens;
                    model.Bedrooms = house.Bedrooms;
                    model.Floors = house.Floors;
                    model.GarageFor = house.GarageFor;
                    model.LivingRooms = house.LivingRooms;

                    /*
                     *Creo que aqui tuvieramos que hacer que House herede de Property, pero hay que ver que pedo con nhibernate;
                     * */
                }
                else
                {
                    model = Mapper.Map<Property, ListPropertiesModel>(property);
                    model.Owner = _repository.First<Account>(x => x.Id == property.DueñoId).Username;
                    model.ImageUrl = "Test.jpg";
                }
                
                
                listcontent.Add(model);
            }
            return View(listcontent);
        }

        [HttpGet]
        public ActionResult SellPropertyForm()
        {
            var model = new SellPropertyModel {StartingDate = DateTime.Now};
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult SellProperty()
        {
            var model = new SellPropertyModel {StartingDate = DateTime.Now};
            return View(model);
        }
        
       [HttpPost]
        public ActionResult SellProperty(SellPropertyModel propertyModel, SellHouseModel houseModel, List<HttpPostedFileBase> files)
        {

           if (CheckIfHouseModelHasUsefulData(houseModel))
           {
               var property = Mapper.Map<SellPropertyModel, Property>(propertyModel);
               var casa = Mapper.Map<Property, House>(property);
               
               _repository.Create(casa);
           }







            var propiedad = Mapper.Map<SellPropertyModel, Property>(propertyModel);
            propiedad.IsaHouse = CheckIfHouseModelHasUsefulData(houseModel);
            propiedad.DueñoId = _repository.First<Account>(x => x.Email == User.Identity.Name).Id;
            var propiedadconid = _repository.Create(propiedad);
            Success("Propiedad en venta!");
            if (!CheckIfHouseModelHasUsefulData(houseModel)) return RedirectToAction("ListProperties", "Properties");
            var house = Mapper.Map<SellHouseModel, House>(houseModel);
            house.PropertyId = propiedadconid.Id;
            _repository.Create(house);
            /*
             * Falta agregar como se van a guardar las imagenes so keep it in mind.
             * 
            */
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

        public bool CheckIfHouseModelHasUsefulData(SellHouseModel model)
        {
            if (model.Bedrooms == 0 && model.CarsSpace == 0 && model.Garage == false && model.LivingRooms == 0 &&
                model.NumberofFloors == 0 && model.Pool == false)
            {
                return false;
            }
            return true;
        }
    }
}
