using AutoMapper;
using BootstrapMvcSample.Controllers;
using Microsoft.Ajax.Utilities;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Services;
using RealEstate.Web.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Web.Controllers
{
    public class AdministratorController : BootstrapBaseController
    {
        //
        // GET: /Administrator/
        private readonly IRepository _repository;


        public AdministratorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult AdminCP()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PropertiesList()
        {
            var propiedades = _repository.GetAll<Property>();
            var listaPropiedades = new List<APropertiesListModel>();

            foreach (var prop in propiedades)
            {
                var model = Mapper.Map<Property, APropertiesListModel>(prop);
                var prop1 = prop;
                var dueno = _repository.First<Account>(x => x.Id == prop1.DueñoId);

                model.Owner = dueno.Username + "(" + dueno.Email + ")";
                listaPropiedades.Add(model);

            }
            return PartialView(listaPropiedades);
        }

        public ActionResult UsersList()
        {
            var usuarios = _repository.GetAll<Account>();
            var listaUsuarios = new List<AUserListModel>();

            foreach (var user in usuarios)
            {
                var model = Mapper.Map<Account, AUserListModel>(user);
                model.MemberSince = user.MemberSince.ToString("dd/MM/yyyy");
                listaUsuarios.Add(model);
            }
            return PartialView(listaUsuarios);
        }
        [HttpGet]
        public ActionResult DeleteProperty(long id)
        {
            var prop = _repository.First<Property>(x => x.Id == id);

            var model = Mapper.Map<Property, APropertiesListModel>(prop);
            model.Owner = _repository.First<Account>(x => x.Id == prop.DueñoId).Username;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteProperty(APropertiesListModel model)
        {
            var prop = _repository.First<Property>(x => x.Id == model.id);
            _repository.Delete(prop);
            Success("Se ha borrado la propiedad");
            return RedirectToAction("AdminCP");
        }
        [HttpGet]
        public ActionResult BanUser(long id)
        {
            var user = _repository.First<Account>(x => x.Id == id);
            var model = Mapper.Map<Account, BanUserModel>(user);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult BanUser(BanUserModel model)
        {
            var bannedAccount = _repository.First<Account>(x => x.Email == model.Email);
            var ban = new UserBans
            {
                BanDateTime = DateTime.Now,
                Administrator = _repository.First<Account>(x => x.Email == User.Identity.Name).Username,
                BanReason = model.BanReason,
                UserId = model.id
            };
            bannedAccount.Banned = true;
            _repository.Create(ban);
            _repository.Update(bannedAccount);
            Success("El usuario "+model.Email+" fue baneado");
            return RedirectToAction("AdminCP");
        }

        [HttpGet]
        public ActionResult BanProperty(long id)
        {
            var prop = _repository.First<Property>(x => x.Id == id);

            var model = Mapper.Map<Property, BanPropertyModel>(prop);
            model.Owner = _repository.First<Account>(x => x.Id == prop.DueñoId).Username;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult BanProperty(BanPropertyModel model)
        {
            var prop = _repository.First<Property>(x => x.Id == model.id);
            var ban = new PropertyBans
            {
                Administrator = _repository.First<Account>(x => x.Email == User.Identity.Name).Username,
                BanDate = DateTime.Now,
                BanReason = model.BanReason,
                PropertyId = prop.Id
            };
            prop.Banned = true;
            _repository.Update(prop);
            _repository.Create(ban);
            Success("La propiedad ha sido baneada");
            return RedirectToAction("AdminCP");
        }
    }


}