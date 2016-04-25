using System;
using Gtk;

namespace DIA.View{
	public partial class MainWindow
		:Window{
		// Atributos home
		// Primer cuadrante
		private VBox calendarHome;

		private Calendar calendar;

		// Segundo cuadrante
		//private VBox profileHome;

		// Tercer cuadrante
		private ScrolledWindow showAllFoods;
		private CellRendererText rendererText;
		private TreeView foodTree;
		private TreeViewColumn column;

		// Cuarto cuadrante
		private VBox statsHome;
		private Entry caloriasE;
		private Entry pesosE;
		private Label labelCalorias;
		private Label labelPesos;

		// Constructor de home
		private void BuildHome(){
			// Primer cuadrante
			this.calendarHome.Destroy();

			this.calendarHome = new VBox();

			this.calendar = new Calendar();
			this.calendar.DisplayOptions = CalendarDisplayOptions.ShowHeading | CalendarDisplayOptions.ShowWeekNumbers | CalendarDisplayOptions.ShowDayNames;
			this.calendar.DaySelected += new EventHandler (date_clicked);
			this.calendar.DaySelectedDoubleClick += new EventHandler (this.OnDaySelected);
			this.calendar.MonthChanged += new EventHandler (month_clicked);
			this.markDays ();

			this.calendarHome.PackStart(this.calendar);
			this.colLeftRowUp.PackStart(this.calendarHome);
			this.colLeftRowUp.ShowAll ();

			// Segundo cuadrante
			//this.profileHome.Destroy();

			//this.profileHome = new VBox();

			//this.colRightRowUp.PackStart(this.profileHome);
			this.ListarPeso();

			// Tercer cuadrante
			this.BuildShowFoods();
			this.colLeftRowDown.ShowAll();
			this.addFoodWindow.Hide();	
			this.deleteFoodWindow.Hide();
			this.findFoodWindow.Hide();
			this.searchFoodWindow.Hide();
			//this.showAllWeights.Hide();
			this.AddWeightWindow.Hide();
			this.deleteWeightWindow.Hide ();
			this.mostrarDatosDia.Hide ();
	
			// Cuarto cuadrante
			this.statsHome.Destroy();
			this.labelPesos = new Label ("Weight Mean");
			this.labelCalorias = new Label ("Calories Mean");
			this.caloriasE = new Gtk.Entry("0");
			this.caloriasE.Alignment =1;
			this.pesosE = new Gtk.Entry("0");
			this.pesosE.Alignment =1;
			this.caloriasE.IsEditable = false;
			this.pesosE.IsEditable = false;
			this.statsHome = new VBox();
			var horizontalBoxMeans = new HBox ();
			var recheo = new HBox ();
			var horizontalBoxLabels = new HBox ();
			var horizontalBoxR = new HBox ();
			var Graph = new Label ("Y is Total amount, X is Day. Red for Weights and Green for Calories");
			horizontalBoxLabels.PackStart(this.labelCalorias, true, true, 5);
			horizontalBoxLabels.PackStart(this.labelPesos, true, true, 5);
			horizontalBoxMeans.PackStart (this.caloriasE, true, true, 5);
			horizontalBoxMeans.PackStart (this.pesosE, true, true, 5);
			this.BuildGrafica();
			this.statsHome.PackStart(horizontalBoxLabels, false, false, 5);
			this.statsHome.PackStart(horizontalBoxMeans, false,false, 5);
			this.statsHome.PackStart (Graph, false, false, 5);
			this.statsHome.PackStart (recheo, false, false, 30);
			horizontalBoxR.PackStart (this.drawingArea, true, true, 230);
			this.statsHome.PackStart (horizontalBoxR);
			this.colRightRowDown.PackStart(statsHome, true, true, 5);
			this.colRightRowDown.ShowAll ();
			this.getCalorias ();
			this.getPesos();
		}
	}
}