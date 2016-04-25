	using System;
	using Gtk;

	namespace DIA.View{

	public partial class MainWindow
		:Window {
	
			private void BuildGrafica() {
			// Drawing area
			this.drawingArea = new Gtk.DrawingArea ();
			this.drawingArea.ExposeEvent += (o, args) => this.OnExposeDrawingArea ();

		
		}
			private Gtk.DrawingArea drawingArea;
			

	}	
}