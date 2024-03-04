using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Vehiculos
{
	[Key]
	public int VehiculoId { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime Fecha { get; set; } = DateTime.Today;

	[Required(ErrorMessage = "Debe ingresar una descripción")]
	public string Descripcion { get; set; }

    [Range(0.01,float.MaxValue, ErrorMessage = "La cantidad para el costo del vehículo no es válida")]
    public decimal Costo { get; set; }

	[Range(0.01, float.MaxValue, ErrorMessage = "La cantidad para el gasto del vehículo no es válida")]
	public decimal Gastos { get; set; }


	[ForeignKey("VehiculoId")]
	public ICollection<VehiculosDetalle> VehiculosDetalles { get; set; } = new List<VehiculosDetalle>();
}
