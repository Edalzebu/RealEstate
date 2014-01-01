using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BootstrapMvcSample.Controllers;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Services;
using RealEstate.Web.Models;
using Omu.ValueInjecter;

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
            var houses = _repository.GetAll<House>();
            /*foreach (var property in properties)
            {
                
            }
            foreach (var house in houses)
            {
                
            }*/
            foreach (var property in properties)
            {
                ListPropertiesModel model;
                model = Mapper.Map<Property, ListPropertiesModel>(property);
                model.Owner = _repository.First<Account>(x => x.Id == property.DueñoId).Username;
                model.ImageUrl = "Test.jpg";
                model.IsaHouse = false;
                
                foreach (var house in houses.Where(house => property.Id == house.Id))
                {
                    model = Mapper.Map<House, ListPropertiesModel>(house);
                    model.IsaHouse = true;
                    model.Owner = _repository.First<Account>(x => x.Id == house.DueñoId).Username;
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
            var model = new SellPropertyModel { StartingDate = DateTime.Now };
            return View(model);
        }
        
       [HttpPost]
        public ActionResult SellProperty(SellPropertyModel propertyModel, SellHouseModel houseModel, List<HttpPostedFileBase> files)
        {

           var property = Mapper.Map<SellPropertyModel, Property>(propertyModel);
           property.DueñoId = _repository.First<Account>(x => x.Email == User.Identity.Name).Id;
           property.Banned = false;
           if (CheckIfHouseModelHasUsefulData(houseModel))
           {
               var casa = Mapper.Map<SellHouseModel, House>(houseModel);
               //casa.InjectFrom(property); ** Doesn't work as intended, research needed. **

               casa.Id = property.Id;
               casa.IsArchived = false;
               casa.LandArea = property.LandArea;
               casa.ConstructionArea = property.ConstructionArea;
               casa.Price = property.Price;
               casa.Suburb = property.Suburb;
               casa.City = property.City;
               casa.Country = property.Country;
               casa.DueñoId = property.DueñoId;
               casa.NombrePropiedad = property.NombrePropiedad;
               casa.PropertyDescription = property.PropertyDescription;
               casa.StartingDate = property.StartingDate;
               casa.Banned = false;
               _repository.Create(casa);
               Success("Casa en venta");
           }
           else
           {
               Success("Propiedad en venta");
               _repository.Create(property);
           }

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
