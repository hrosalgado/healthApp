using System;
using System.Text;

namespace DIA.View{

	public partial class Grafica {

		private void OnExposeDrawingArea()
		{
			using ( var canvas = Gdk.CairoHelper.Create( this.drawingArea.GdkWindow) )
			{
				// Axis
				canvas.MoveTo( 0, 100 );
				canvas.ShowText( Encoding.UTF8.GetBytes( "y".ToCharArray() ) );
				canvas.LineWidth = 4;//ancho ejes
				canvas.MoveTo( 10, 10 );//inclinación eje Y
				canvas.LineTo( 10, 110 );//longitud eje y negativa
				canvas.LineTo( 110, 110 );
				canvas.MoveTo( 110, 120 );
				canvas.ShowText( Encoding.UTF8.GetBytes( "x".ToCharArray() ) );
				canvas.Stroke();

				// DataPesos
				canvas.LineWidth = 2;//ancho linea datos
				canvas.SetSourceRGBA( 255, 0, 0, 255 );
				canvas.MoveTo( 0, 100);
				/*double aux1 = (double)m.getPesos (0)/100;
				double aux2 = (double)m.getPesos(1)/100;
				double aux3 = (double)m.getPesos(2)/100;
				double aux4 = (double)m.getPesos(3)/100;

				canvas.LineTo(10, aux1);
				canvas.LineTo(20, aux2);
				canvas.LineTo(30, aux3);
				canvas.LineTo(40, aux4);
				canvas.Stroke();*/

				// DataCalorias
				canvas.LineWidth = 2;//ancho linea datos
				canvas.SetSourceRGBA( 128, 124, 0, 255 );
				canvas.MoveTo( 0, 150);
				/*double aux5 = (double)m.getCalorias(0);
				double aux6 = (double)m.getCalorias(1);
				double aux7 = (double)m.getCalorias(2);
				double aux8 = (double)m.getCalorias(3);


				canvas.LineTo( 10, aux5);
				canvas.LineTo( 20, aux6);
				canvas.LineTo( 30, aux7);
				canvas.LineTo( 40, aux8);
				canvas.Stroke();*/
				// Clean
				canvas.GetTarget().Dispose();
			}

		}


	}
}

