using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using BootstrapMvcSample.Controllers;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Services;
using RealEstate.Web.Models;


namespace RealEstate.Web.Controllers
{
    public class AccountController : BootstrapBaseController
    {
        private readonly IRepository _repository;
        

        public AccountController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult MyProfile()
        {
            var account = _repository.First<Account>(x => x.Email == User.Identity.Name);
            var model = Mapper.Map<Account, AccountProfileModel>(account);
            model.ImageUrl = "‪C:/Users/Edwin/Pictures/DSC03029.JPG";
            var lista = new List<Property>();
            var listacasas = new List<House>();
           
            model.ListaProperties = lista;
            model.ListCasas = listacasas;

            return View(model);
        }

        public ActionResult SearchProfile()
        {
            return View();
        }
        public ActionResult Profile(long id)
        {
            var propiedad = _repository.First<Property>(x => x.Id == id);
            var account = _repository.First<Account>(x => x.Id == propiedad.DueñoId);
            var model = Mapper.Map<Account, AccountProfileModel>(account);
            return View(model);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View(new AccountLoginModel());
        }

        [HttpPost]
        public ActionResult LogIn(AccountLoginModel model)
        {
            if (CheckCuentaExiste(model.Email))
            {
                if (!CheckCuentaBanned(model.Email))
                {
                    if (CheckCredenciales(model) != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                        return RedirectToAction("ListProperties", "Properties");
                    }
                    Error("La clave que ingreso no es la correcta para esa cuenta.");
                }
                else
                {
                    Error("Esa cuenta fue prohibida por un administrador, por violar los terminos de uso de la pagina.");
                }
                
            }
            else
            {
                Error("Esa cuenta no existe en nuestro sistema.");
            }
            
            
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login",new AccountLoginModel());
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new AccountInputModel());
        }

        [HttpPost]
        public ActionResult Register(AccountInputModel model)
        {
            if (!CheckCuentaExiste(model.Email))
            {
                if (!CheckUserNameExists(model.UserName))
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        var nuevaCuenta = Mapper.Map<AccountInputModel, Account>(model);
                        nuevaCuenta.MemberSince = DateTime.Now;
                        _repository.Create(nuevaCuenta);

                        Success("La cuenta se ha registrado correctamente");
                        return RedirectToAction("LogIn");
                    }
                    else
                    {
                        Error("Las contraseñas no son iguales");
                        model.Password = "";
                        model.ConfirmPassword = "";
                        return View("Register", model);
                    }
                }
                else
                {
                    Error("Ese usuario ya existe, elija otro");
                    model.Password = "";
                    model.ConfirmPassword = "";
                    model.UserName = "";
                    return View("Register", model);
                }
                
                
            }
            else
            {
                Error("Esa cuenta ya esta registrada en nuestro sistema.");
            }
            return RedirectToAction("LogIn");
        }

        private bool CheckUserNameExists(string userName)
        {
            var account = _repository.First<Account>(x => x.Username == userName);
            if (account != null)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return null;
        }
        [HttpGet]
        public ActionResult RecoverAccount()
        {
            return RedirectToAction("LogIn");
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index","Properties");
        }


        //Funciones Auxiliares
        public bool CheckCuentaBanned(string email)
        {
            var cuenta = _repository.First<Account>(x=>x.Email == email);
            return cuenta.Banned;
        }
        public bool CheckCuentaExiste(string email)
        {
            var account = _repository.First<Account>(x => x.Email == email);
            if (account != null)
            {
                return true;
            }
            return false;
        }
        public Account CheckCredenciales(AccountLoginModel model)
        {
            return CheckCredenciales(model.Email, model.Password);
        }
        public Account CheckCredenciales(string email, string password)
        {
            var account = _repository.First<Account>(x => x.Email == email);
            if (account != null)
            {
                if (account.Password == password)
                {
                    return account;
                }
            }
            return null;
            
        }
    }
}