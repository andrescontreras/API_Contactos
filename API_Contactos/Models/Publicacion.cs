using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Contactos.Models
{
	public class Publicacion
	{
		public long Id { get; set; }
		public string Sector { get; set; }
		public string SubSector { get; set; }
		public string empresa { get; set; }
		public string NombreContacto { get; set; }
		public string cargo { get; set; }
		//public List<Contacto> formasC { get; set; }

	}
}
