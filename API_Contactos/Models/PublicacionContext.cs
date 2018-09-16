using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_Contactos.Models
{
	public class PublicacionContext : DbContext
	{
		public PublicacionContext(DbContextOptions<PublicacionContext> options)
		   : base(options)
		{
		}

		public DbSet<Publicacion> PublicacionItems { get; set; }
	}
}
