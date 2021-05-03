using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceCOA.Models.Response;
using WebServiceCOA.Models;
using WebServiceCOA.Models.Request;

namespace WebServiceCOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try {
                using (COABDContext db = new COABDContext())
                {
                    var lst = db.Usuarios.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }


        [HttpGet("{IdUsuario}")]
        public IActionResult Get(int IdUsuario)
        {
            Respuesta<Usuario> oRespuesta = new Respuesta<Usuario>();

            try
            {
                using (COABDContext db = new COABDContext())
                {
                    var lst = db.Usuarios.Find(IdUsuario);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }


        [HttpPost]
        public IActionResult Add(UsuarioRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (COABDContext db = new COABDContext())
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.UserName = model.UserName;
                    oUsuario.Nombre = model.Nombre;
                    oUsuario.Email = model.Email;
                    oUsuario.Telefono = model.Telefono;
                    db.Usuarios.Add(oUsuario);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }


        [HttpPut]
        public IActionResult Edit(UsuarioRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (COABDContext db = new COABDContext())
                {
                    Usuario oUsuario = db.Usuarios.Find(model.IdUsuario);
                    oUsuario.UserName = model.UserName;
                    oUsuario.Nombre = model.Nombre;
                    oUsuario.Email = model.Email;
                    oUsuario.Telefono = model.Telefono;
                    db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }


        [HttpDelete("{IdUsuario}")]
        public IActionResult Delete(int IdUsuario)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (COABDContext db = new COABDContext())
                {
                    Usuario oUsuario = db.Usuarios.Find(IdUsuario);
                    db.Remove(oUsuario);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

    }
}
