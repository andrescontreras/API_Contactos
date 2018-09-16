using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Contactos.Models
{
	public class Contacto
	{	
		public long Id { get; set; }
		public string TipoContacto { get; set; }
		public string Detalle { get; set; }

		public static implicit operator List<object>(Contacto v)
		{
			throw new NotImplementedException();
		}
	}
}
