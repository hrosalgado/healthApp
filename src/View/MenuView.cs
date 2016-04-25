using System;

namespace DIA.View{
	public partial class MainWindow
		:Gtk.Window{
		// Atributos menú
		private Gtk.VBox menu;

		//private Toolbar barMenu;
		private Gtk.MenuBar menuBar;
		private Gtk.MenuItem miAdd;
		private Gtk.Menu mAdd;
		private Gtk.Action actAddPeso;
		private Gtk.Action actAddComida;
		private Gtk.MenuItem miHome;
		private Gtk.Menu mHome;
		private Gtk.Action actHome;
		//private Gtk.Action actFind;
		//private Gtk.Action actListPeso;
		private Gtk.MenuItem miDelete;
		private Gtk.Menu mDelete;
		private Gtk.Action actDeleteFood;
		private Gtk.Action actDeletePeso;
		private Gtk.MenuItem miApli;
		private Gtk.Menu mApli;
		private Gtk.Action actAboutt;
		private Gtk.Action actQuitt;

		// Constructor del menú superior
		private void BuildMenuActions(){
			this.actHome = new Gtk.Action( "Go home", "Home", "Go home", null );
			this.actHome.Activated += (obj, evt) => this.BuildHome();

			//this.actFind = new Gtk.Action( "Go find", "Find", "Go find", null );
			//this.actFind.Activated += (obj, evt) => this.BuildFindFood();

			/*this.actListPeso = new Gtk.Action( "List weight", "List weight", "List weight", null );
			this.actListPeso.Activated += (obj, evt) => this.ListarPeso();*/

			this.actAddComida = new Gtk.Action( "AddComida", "Food", "AddComida", null );
			this.actAddComida.Activated += (obj, evt) => this.BuildAddFood();

			this.actAddPeso = new Gtk.Action( "AddPeso", "Weight", "AddPeso", null );
			this.actAddPeso.Activated += (obj, evt) => this.BuildAddPeso();

			this.actDeleteFood = new Gtk.Action( "Delete food", "Food", "Delete food", null );
			this.actDeleteFood.Activated += (obj, evt) => this.BuildDeleteFood();

			this.actDeletePeso = new Gtk.Action( "Delete Weight", "Weight", "Delete Weight", null );
			this.actDeletePeso.Activated += (obj, evt) => this.BuildDeletePeso();

			this.actAboutt = new Gtk.Action( "About", "About", "About", null );
			this.actAboutt.Activated += (obj, evt) => this.BuildAbout();

			this.actQuitt = new Gtk.Action( "Quit", "Quit", "Quit", null );
			this.actQuitt.Activated += (obj, evt) => this.BuildExit();
		}

		private void BuildMenu(){
			this.menu = new Gtk.VBox(true, 5);
			this.menuBar = new Gtk.MenuBar();
			this.miHome = new Gtk.MenuItem( "Go" );
			this.mHome = new Gtk.Menu();
			this.miAdd = new Gtk.MenuItem( "Add" );
			this.mAdd = new Gtk.Menu();
			this.miDelete = new Gtk.MenuItem( "Delete" );
			this.mDelete = new Gtk.Menu();
			this.miApli = new Gtk.MenuItem( "Aplication" );
			this.mApli = new Gtk.Menu();

			miAdd.Submenu = mAdd;
			mAdd.Append( this.actAddComida.CreateMenuItem() );
			mAdd.Append( this.actAddPeso.CreateMenuItem() );

			miHome.Submenu = mHome;
			mHome.Append( this.actHome.CreateMenuItem() );
			//mHome.Append( this.actFind.CreateMenuItem() );
			//mHome.Append (this.actListPeso.CreateMenuItem ());
		

			miDelete.Submenu = mDelete;
			mDelete.Append( this.actDeleteFood.CreateMenuItem() );
			mDelete.Append( this.actDeletePeso.CreateMenuItem() );
	
			miApli.Submenu = mApli;
 			mApli.Append( this.actAboutt.CreateMenuItem() );
			mApli.Append( this.actQuitt.CreateMenuItem() );

			menuBar.Append( miHome );
			menuBar.Append( miAdd );
			menuBar.Append( miDelete );
			menuBar.Append( miApli);
			this.menu.PackStart(this.menuBar, true, true, 0);
			this.window.PackStart(this.menu, false, false, 0);

			this.menu.ShowAll();
		}
	}
}