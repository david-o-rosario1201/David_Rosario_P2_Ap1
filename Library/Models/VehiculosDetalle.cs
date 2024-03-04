using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class VehiculosDetalle
{
	[Key]
	public int Id { get; set; }

    public int VehiculoId { get; set; }

    public int AccesorioId { get; set; }

    public decimal Valor { get; set; }
}
