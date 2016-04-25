using System;
using Gtk;
namespace DIA.View{
	public partial class MainWindow
		:Window{
		// Ventana principal
		private VBox window;
	
		// Find
		private HBox findWindow;
		private VBox firstRowFind;
		private VBox secondRowFind;
		private VBox thirdRowFind;
		private Label nameHeaderFind;
		private Entry nameFind;
		private Button okFind;

		// Espacio de trabajo
		private VBox main;

		// Cuadrantes
		private HBox rowUp;
		private VBox colLeftRowUp;
		private VBox colRightRowUp;

		private HBox rowDown;
		private VBox colLeftRowDown;
		private VBox colRightRowDown;

		// Errores
		private MessageDialog errorWindow;

		public MainWindow()
			:base("·App"){
			//SetIconFromFile("icon.png");
			SetDefaultSize(1280, 720);
			SetPosition(WindowPosition.Center);
			this.window = new VBox();
			//ModifyBg (StateType.Normal, new Gdk.Color(255, 255, 0));
			this.Add(this.window);
			this.BuildMenuActions ();
			this.BuildMenu();
			this.BuildFind();
			this.BuildStructure();
			this.Init();
			this.BuildHome();
			this.ShowAll();

		}
			
		// Crea el esqueleto de ventanas
		private void BuildStructure(){
			// Ventana principal
			this.main = new VBox(true, 5);

			// Filas
			this.rowUp = new HBox(true, 0);
			this.rowDown = new HBox(true, 0);

			// Primer cuadrante
			this.colLeftRowUp = new VBox();

			this.calendarHome = new VBox();
			this.mostrarDatosDia = new VBox ();

			// Segundo cuadrante
			this.colRightRowUp = new VBox();

			this.showAllWeights = new ScrolledWindow();

			//this.profileHome = new VBox();

			// Tercer cuadrante
			this.colLeftRowDown = new VBox();

			this.showAllFoods = new ScrolledWindow();
			//this.showAllWeights = new ScrolledWindow();
			this.addFoodWindow = new VBox();
			this.AddWeightWindow = new VBox ();
			this.deleteFoodWindow = new VBox();
			this.deleteWeightWindow = new VBox ();
			this.findFoodWindow = new VBox();
			this.searchFoodWindow = new ScrolledWindow();

			// Cuarto cuadrante
			this.colRightRowDown = new VBox();

			this.statsHome = new VBox();

			// Empaquetado
			this.rowUp.PackStart(this.colLeftRowUp);
			this.rowUp.PackStart(this.colRightRowUp);
			this.rowDown.PackStart(this.colLeftRowDown);
			this.rowDown.PackStart(this.colRightRowDown);

			this.main.PackStart(this.rowUp);
			this.main.PackStart(this.rowDown);

			this.window.PackStart(this.main);
		}

		private void BuildFind(){
			this.findWindow = new HBox();

			this.firstRowFind = new VBox(false, 5);
			this.secondRowFind = new VBox(false, 5);
			this.thirdRowFind = new VBox(false, 5);

			this.nameHeaderFind = new Label("Search a food");
			this.firstRowFind.PackStart(this.nameHeaderFind, false, false, 5);

			this.nameFind = new Entry();
			this.secondRowFind.PackStart(this.nameFind, false, false, 5);

			this.okFind = new Button("Search!");
			this.thirdRowFind.PackStart(this.okFind, false, false, 5);

			this.findWindow.PackStart(this.firstRowFind, true, true, 5);
			this.findWindow.PackStart(this.secondRowFind, true, true, 5);
			this.findWindow.PackStart(this.thirdRowFind, true, true, 5);

			this.window.PackStart(this.findWindow, false, false, 5);

			this.okFind.Clicked += (object sender, EventArgs e) => this.FindFood(this.storage, this.nameFind.Text);
		}

		private void BuildExit(){
			this.Exit();
			Application.Quit();
		}
	}
}