using System;
using System.Text;

namespace DIA.View{

	public partial class MainWindow {

		private void OnExposeDrawingArea()
		{
			using (var canvas = Gdk.CairoHelper.Create (this.drawingArea.GdkWindow)) {
				// Axis

				canvas.MoveTo (0, 100);
				canvas.ShowText (Encoding.UTF8.GetBytes ("Y".ToCharArray ()));
				canvas.LineWidth = 4;//ancho ejes
				canvas.MoveTo (10, 10);//inclinación eje Y
				canvas.LineTo (10, 110);//longitud eje y negativa
				canvas.LineTo (110, 110);
				canvas.MoveTo (110, 120);
				canvas.ShowText (Encoding.UTF8.GetBytes ("X".ToCharArray ()));
				canvas.Stroke ();




				// DataWeight
				canvas.LineWidth = 2;//ancho linea datos
				canvas.SetSourceRGBA (255, 0, 0, 255);
				canvas.MoveTo (10, 110);
				Peso[] datosP;
				DIA.Core.Food[] datosC;
				datosP = this.storagePeso.Peso.ToArray ();
				datosC = this.storage.Foods.ToArray ();
				int[] pesoNormalizdo = new int[datosP.Length];
				int[] caloriasNormalizadas = new int[datosC.Length];
				if (datosP.Length > 0) {
					int segmentos = 100 / datosP.Length;
				
					//Console.WriteLine (datosP.Length);
					for (int i = 0; i < datosP.Length; ++i) {
						pesoNormalizdo [i] = (datosP [i].Pes / 10);
						canvas.LineTo (100 + (i * segmentos), (110 - pesoNormalizdo [i]));
					}
				
					canvas.Stroke ();

					//DataCalories
					canvas.LineWidth = 2;//ancho linea datos
					canvas.SetSourceRGB (0, 255, 0);
					canvas.MoveTo (10, 110);
					for (int i = 0; i < datosC.Length; ++i) {
				
						caloriasNormalizadas [i] = (datosC [i].Calories / 10);
						canvas.LineTo (100 + (i * segmentos), (110 - caloriasNormalizadas [i]));

					}
					canvas.Stroke ();


					canvas.GetTarget ().Dispose ();
				}
			}
			
		}


	}

}
