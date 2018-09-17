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
				{ Sector = "Sector1",
					SubSector = "SubSector1",
					Empresa = "empresa1",
					Cargo = "Cargo contacto",
					NombreContacto = "nombre contacto",
					formasC = lc
				});

				_context.PublicacionItems.Add(new Publicacion
				{
					Sector = "Sector2",
					SubSector = "SubSector1",
					Empresa = "empresa1",
					Cargo = "Cargo contacto",
					NombreContacto = "nombre contacto",
					formasC = lc
				});

				_context.PublicacionItems.Add(new Publicacion
				{
					Sector = "Sector3",
					SubSector = "SubSector1",
					Empresa = "empresa1",
					Cargo = "Cargo contacto",
					NombreContacto = "nombre contacto",
					formasC = lc
				});

				_context.PublicacionItems.Add(new Publicacion
				{
					Sector = "Sector4",
					SubSector = "SubSector1",
					Empresa = "empresa1",
					Cargo = "Cargo contacto",
					NombreContacto = "nombre contacto",
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

		[HttpGet("{id}", Name = "GetPublicacion")]
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
