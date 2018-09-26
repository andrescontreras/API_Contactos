using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Contactos.Models
{
	public class Publicacion
	{
		public Publicacion()
		{
			this.formasC = new List<Contacto>();
		}

		public long Id { get; set; }
		public string Sector { get; set; }
		public string SubSector { get; set; }
		public string Empresa { get; set; }
		public string NombreContacto { get; set; }
		public string Cargo { get; set; }
		public string Descripcion { get; set; }
		public List<Contacto> formasC  { get; set; }
		public string usuario { get; set; }
	}
}
