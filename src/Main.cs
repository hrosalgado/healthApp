using System;

using DIA.Core;
using DIA.View;

namespace DIA{

    class MainClass{
		public static void Main(string[] args){
		    Gtk.Application.Init();
		    var mainWindow = new MainWindow();
		    mainWindow.ShowAll();
		    Gtk.Application.Run();
		}
    }
}
