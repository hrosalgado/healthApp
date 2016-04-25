using System;
using Gtk;

namespace DIA.View{
	public partial class MainWindow
		:Window{
		// Atributos
		private AboutDialog aboutWindow;

		// About
		private void BuildAbout(){
			this.aboutWindow = new AboutDialog();
			this.aboutWindow.TransientFor = this;
			this.aboutWindow.WindowPosition = WindowPosition.CenterOnParent;
			this.aboutWindow.Title = "About us";
			this.aboutWindow.ProgramName = "Health";
			this.aboutWindow.Version = "v1.0";
			this.aboutWindow.Copyright = "(c) 2015";
			this.aboutWindow.Run();
			this.aboutWindow.Destroy();
		}
	}
}