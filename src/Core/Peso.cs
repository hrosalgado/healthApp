using System;
namespace DIA
{
	public class Peso
	{
		public Peso (int pes, string fecha)
		{
			this.Pes = pes;
			this.Fecha = fecha;

		}
		public int Pes {
			get;
			set;
		}
		public string Fecha {
			get;
			set;
		}
		public override string ToString(){
			string salida = ("Peso: " + Pes + "Fecha " + Fecha);
			return salida;
		}
	}
}

