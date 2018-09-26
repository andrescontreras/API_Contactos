using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Contactos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Contactos.Controllers
{
	// Constructor
	[Route("api/[controller]")]
	public class PublicacionController : Controller
	{
		private readonly PublicacionContext _context;

		public PublicacionController(PublicacionContext context)
		{
			_context = context;

			if (_context.PublicacionItems.Count() == 0)
			{
				// Create a new TodoItem if collection is empty,
				// which means you can't delete all TodoItems.
				Contacto c = new Contacto { TipoContacto = "correo", Detalle = "correo@email.com" };
				Contacto c1 = new Contacto { TipoContacto = "correo", Detalle = "111correo@email.com" };
				Contacto c2 = new Contacto { TipoContacto = "correo", Detalle = "222correo@email.com" };
				List<Contacto> lc = new List<Contacto>();
				lc.Add(c);
				lc.Add(c1);
				lc.Add(c2);
				_context.PublicacionItems.Add(new Publicacion
				{ Sector = "Industria Textil",
					SubSector = "Confección",
					Empresa = "Coltejer",
					Cargo = "Administrador ventas",
					NombreContacto = "Pedro Alberto Gonzales",
					Descripcion = "Empresa que se encargar de la creación de telas para diferentes usos. El contacto publicado puede " +
					"ofrecer un punto de estrada para poder realizar pequeños o grandes negocios con un tercero y la empresa",
					formasC = { }
				});

				_context.PublicacionItems.Add(new Publicacion
				{
					Sector = "Industria Textil",
					SubSector = "Tejeduría",
					Empresa = "Protela S.A",
					Cargo = "Administrador proveedores",
					NombreContacto = "Julio Federico Rodrigez",
					Descripcion =  "Empresa que se encarga de la creación de hilos para su futuro uso en diferentes tipos de telas, " +
					"El contacto publicado puede ofrecer la generación de negocios ligados a las materias primas necesarias para cumplir el objetivo de las empresas",
					formasC = lc
				});

				_context.PublicacionItems.Add(new Publicacion
				{
					Sector = "Transporte",
					SubSector = "Transporte urbano",
					Empresa = "Transmilenio",
					Cargo = "Director de seguridad",
					NombreContacto = "Miriam Cardenas",
					Descripcion = "Empresa que se encarga en la prestación de servicios de transporte urbano en Bogotá, El contacto publicado puede ofrecer la potenciales" +
					" negocios los cuales puedan ser prestados por un tercero, el cual pueda mejorar la seguridad del sistema de transporte.",
					formasC = lc
				});

				_context.PublicacionItems.Add(new Publicacion
				{
					Sector = "Información y comunicaciones",
					SubSector = "Desarrollo de sistemas informáticos",
					Empresa = "Software S.A",
					Cargo = "Director de ventas",
					NombreContacto = "INMACULADA BOLAÑOS",
					Descripcion = "Empresa que se encarga en la optimización de procesos empresariales a través de sistemas complejos que mejoren la productividad de la empresa, " +
					"El contacto publicado es primera la primera forma de contacto para aquellas empresas que estén buscando optimizar sus procesos.",
					formasC = lc
				});

				_context.SaveChanges();
			}
		}

		// CRUD
		// Metodos Get
		[HttpGet]
		public ActionResult<List<Publicacion>> GetAll()
		{
			return _context.PublicacionItems.ToList();
		}

		
		[HttpGet("GetPublicacion/{id}", Name = "GetPublicacion")]
		public ActionResult<Publicacion> GetById(long id)
		{
			var item = _context.PublicacionItems.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return item;
		}

		// Metodo Post
		[HttpPost]
		public IActionResult Create([FromBody] Publicacion item)
		{

			_context.PublicacionItems.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetPublicacion", new { id = item.Id }, item);
		}

		// Metodo put
		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] Publicacion item)
		{
			var publicacion = _context.PublicacionItems.Find(id);
			if (publicacion == null)
			{
				return NotFound();
			}

			publicacion.Sector = item.Sector;
			publicacion.SubSector = item.SubSector;
			publicacion.Empresa = item.Empresa;
			publicacion.NombreContacto = item.NombreContacto;
			publicacion.Cargo = item.Cargo;

			_context.PublicacionItems.Update(publicacion);
			_context.SaveChanges();
			return NoContent();
		}

		// Metodo delete
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var publicacion = _context.PublicacionItems.Find(id);
			if (publicacion == null)
			{
				return NotFound();
			}

			_context.PublicacionItems.Remove(publicacion);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
