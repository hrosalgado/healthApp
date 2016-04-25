using System;
using Gtk;
using System.Collections.Generic;
using System.Text;
using DIA.Core;
namespace DIA.View{
	public partial class MainWindow
		:Window{
		// Atributos
		private ListStore storeDay;
		// Añadir comida
		private HBox firstRowAdd;
		private HBox secondRowAdd;
		private HBox thirdRowAdd;
		private HBox fourthRowAdd;
		private HBox fivethRowAdd;
		private HBox sixthRowAdd;

		private Label nameHeaderAdd;
		private Entry nameAdd;
		private Label brandHeaderAdd;
		private Entry brandAdd;
		private Label mealHeaderAdd;
		private Entry mealAdd;
		private Label amountHeaderAdd;
		private Entry amountAdd;
		private Label portionHeaderAdd;
		private Entry portionAdd;
		private Label caloriesHeaderAdd;
		private Entry caloriesAdd;
		private Label pesoHeaderAdd;
		private Entry pesoAdd;
		private Calendar calendarAdd;
		private DateTime dateAdd;
		private Button okAdd;

		// Eliminar comida
		private VBox deleteFoodWindow;

		private HBox firstRowDelete;
		private HBox secondRowDelete;
		private HBox thirdRowDelete;

		private Label nameHeaderDelete;
		private Entry nameDelete;
		private Button okDelete;

		// Buscar comida
		private VBox findFoodWindow;

		/*private HBox firstRowFind;
		private HBox secondRowFind;
		private HBox thirdRowFind;

		private Label nameHeaderFind;
		private Entry nameFind;
		private Button okFind;*/

		private ScrolledWindow searchFoodWindow;

		private CellRendererText rendererTextSearch;
		private TreeView foodTreeSearch;
		private TreeViewColumn columnSearch;

		// Mostrar fechas por día
		private VBox mostrarDatosDia;

		private string aux2="";
		private string [] aux;
		private string output="";

		private VBox addFoodWindow;
		private VBox AddWeightWindow;

		// Eliminar peso
		private VBox deleteWeightWindow;
		private HBox firstRowDel;
		private HBox secondRowDel;
		private HBox thirdRowDel;

		private ScrolledWindow showAllWeights;

		// Añadir una comida
		private void BuildAddFood(){
			this.addFoodWindow.Destroy();

			this.addFoodWindow = new VBox();

			this.firstRowAdd = new HBox(false, 0);
			this.secondRowAdd = new HBox(false, 0);
			this.thirdRowAdd = new HBox(false, 0);
			this.fourthRowAdd = new HBox(false, 0);
			this.fivethRowAdd = new HBox(false, 0);
			this.sixthRowAdd = new HBox(false, 0);

			this.nameHeaderAdd = new Label("Name");
			this.nameAdd = new Entry();

			this.firstRowAdd.PackStart(this.nameHeaderAdd, true, true, 5);
			this.secondRowAdd.PackStart(this.nameAdd, true, true, 5);

			this.brandHeaderAdd = new Label("Brand");
			this.brandAdd = new Entry();

			this.firstRowAdd.PackStart(this.brandHeaderAdd, true, true, 5);
			this.secondRowAdd.PackStart(this.brandAdd, true, true, 5);

			this.mealHeaderAdd = new Label("Meal");
			this.mealAdd = new Entry();

			this.firstRowAdd.PackStart(this.mealHeaderAdd, true, true, 5);
			this.secondRowAdd.PackStart(this.mealAdd, true, true, 5);

			this.amountHeaderAdd = new Label("Amount");
			this.amountAdd = new Entry();

			this.thirdRowAdd.PackStart(this.amountHeaderAdd, true, true, 5);
			this.fourthRowAdd.PackStart(this.amountAdd, true, true, 5);

			this.portionHeaderAdd = new Label("Portion");
			this.portionAdd = new Entry();

			this.thirdRowAdd.PackStart(this.portionHeaderAdd, true, true, 5);
			this.fourthRowAdd.PackStart(this.portionAdd, true, true, 5);

			this.caloriesHeaderAdd = new Label("Calories");
			this.caloriesAdd = new Entry();

			this.thirdRowAdd.PackStart(this.caloriesHeaderAdd, true, true, 5);
			this.fourthRowAdd.PackStart(this.caloriesAdd, true, true, 5);

			this.calendarAdd = new Calendar();
			//this.dateAdd = Convert.ToDateTime("01/01/0001 00:00:00");
			this.calendarAdd.DaySelected += new EventHandler(this.OnDaySelected);
			/*string date = Convert.ToString(this.dateAdd);
			string dateDefault = "01/01/0001 00:00:00";
			if(date == dateDefault){
				this.dateAdd = DateTime.Today;
			}*/
			this.output = Convert.ToString (DateTime.Today.Day+"/"+DateTime.Today.Month+"/"+DateTime.Today.Year);
			//Console.WriteLine(this.output);
			//this.aux = output.Split (' ');
			//this.aux2 = aux [0];
	
			this.fivethRowAdd.PackStart(this.calendarAdd);

			this.okAdd = new Button("Add");

			this.sixthRowAdd.PackStart(this.okAdd);

			this.addFoodWindow.PackStart(this.firstRowAdd, false, false, 5);
			this.addFoodWindow.PackStart(this.secondRowAdd, false, false, 5);
			this.addFoodWindow.PackStart(this.thirdRowAdd, false, false, 5);
			this.addFoodWindow.PackStart(this.fourthRowAdd, false, false, 5);
			this.addFoodWindow.PackStart(this.fivethRowAdd);
			this.addFoodWindow.PackStart(this.sixthRowAdd, false, false, 5);
			
			this.colLeftRowDown.PackStart(this.addFoodWindow);

			this.colLeftRowDown.ShowAll();
			this.showAllFoods.Hide();
			this.deleteFoodWindow.Hide();
			this.findFoodWindow.Hide();
			this.searchFoodWindow.Hide();
			this.mostrarDatosDia.Hide ();
			this.okAdd.Clicked += 
				(sender, e) => 
					this.AddFood(this.storage, this.nameAdd.Text, this.brandAdd.Text, this.mealAdd.Text, this.amountAdd.Text, this.portionAdd.Text, this.caloriesAdd.Text, this.output);
		}

		private void OnDaySelected(object sender, EventArgs args){
			this.calendarAdd = (Calendar) sender;
			this.dateAdd = new DateTime(this.calendarAdd.Year, this.calendarAdd.Month + 1, this.calendarAdd.Day);
			this.output = Convert.ToString (this.dateAdd.Day+"/"+this.dateAdd.Month+"/"+this.dateAdd.Year);
			this.aux = output.Split (' ');
			this.aux2 = aux [0];
		}

		private void BuildShowFoods(){
			this.showAllFoods.Destroy();
			this.showAllFoods = new ScrolledWindow();

			this.showAllFoods.ShadowType = ShadowType.EtchedIn;
			this.showAllFoods.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);

			this.FillStore();

			this.foodTree = new TreeView(this.store);
			this.foodTree.RulesHint = true;
			this.showAllFoods.Add(this.foodTree);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Name", this.rendererText, new object[]{ "text", Column.Name });
			this.foodTree.AppendColumn(this.column);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Brand", this.rendererText, new object[]{ "text", Column.Brand });
			this.foodTree.AppendColumn(this.column);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Meal", this.rendererText, new object[]{ "text", Column.Meal });
			this.foodTree.AppendColumn(this.column);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Amount", this.rendererText, new object[]{ "text", Column.Amount });
			this.foodTree.AppendColumn(this.column);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Portion", this.rendererText, new object[]{ "text", Column.Portion });
			this.foodTree.AppendColumn(this.column);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Calories", this.rendererText, new object[]{ "text", Column.Calories });
			this.foodTree.AppendColumn(this.column);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Date", this.rendererText, new object[]{ "text", Column.Date });
			this.foodTree.AppendColumn(this.column);

			this.colLeftRowDown.PackStart(this.showAllFoods);

			this.colLeftRowDown.ShowAll();
			this.addFoodWindow.Hide();	
			this.deleteFoodWindow.Hide();
			this.findFoodWindow.Hide();
			this.searchFoodWindow.Hide();
			//this.AddWeightWindow.Hide();
			this.mostrarDatosDia.Hide ();
		}

		private void BuildError(string text){
			this.errorWindow = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Close, text);
			this.errorWindow.Run();
			this.errorWindow.Destroy();
		}

		private void BuildDeleteFood(){
			this.BuildShowFoods();

			this.deleteFoodWindow.Destroy();

			this.deleteFoodWindow = new VBox();

			this.firstRowDelete = new HBox(false, 0);
			this.secondRowDelete = new HBox(false, 0);
			this.thirdRowDelete = new HBox(false, 0);

			this.nameHeaderDelete = new Label("Enter the food to delete");

			this.firstRowDelete.PackStart(this.nameHeaderDelete, true, true, 5);

			this.nameDelete = new Entry();

			this.secondRowDelete.PackStart(this.nameDelete, true, true, 5);
			
			this.okDelete = new Button("Delete");

			this.thirdRowDelete.PackStart(this.okDelete, true, true, 5);

			this.deleteFoodWindow.PackStart(this.firstRowDelete, false, false, 5);
			this.deleteFoodWindow.PackStart(this.secondRowDelete, false, false, 5);
			this.deleteFoodWindow.PackStart(this.thirdRowDelete, false, false, 5);

			this.colLeftRowDown.PackStart(this.deleteFoodWindow);

			this.colLeftRowDown.ShowAll();
			this.addFoodWindow.Hide();
			this.findFoodWindow.Hide();
			this.searchFoodWindow.Hide();
			//this.showAllWeights.Hide();
			//this.AddWeightWindow.Hide();
			//this.deleteWeightWindow.Hide();
			this.mostrarDatosDia.Hide ();
			this.okDelete.Clicked += (object sender, EventArgs e) => this.DeleteFood(this.storage, this.nameDelete.Text);
		}

		/*private void BuildFindFood(){
			this.findFoodWindow.Destroy();

			this.findFoodWindow = new VBox();

			this.firstRowFind = new HBox(false, 5);
			this.secondRowFind = new HBox(false, 5);
			this.thirdRowFind = new HBox(false, 5);

			this.nameHeaderFind = new Label("Enter the food to find");

			this.firstRowFind.PackStart(this.nameHeaderFind, true, true, 5);

			this.nameFind = new Entry();

			this.secondRowFind.PackStart(this.nameFind, true, true, 5);

			this.okFind = new Button("Find");

			this.thirdRowFind.PackStart(this.okFind, true, true, 5);

			this.findFoodWindow.PackStart(this.firstRowFind, false, false, 5);
			this.findFoodWindow.PackStart(this.secondRowFind, false, false, 5);
			this.findFoodWindow.PackStart(this.thirdRowFind, false, false, 5);

			this.colLeftRowDown.PackStart(this.findFoodWindow);

			this.colLeftRowDown.ShowAll();
			this.showAllFoods.Hide();
			this.addFoodWindow.Hide();
			this.deleteFoodWindow.Hide();
			this.searchFoodWindow.Hide();
			this.showAllWeights.Hide();
			this.AddWeightWindow.Hide();
			this.deleteWeightWindow.Hide ();

			this.okFind.Clicked += (object sender, EventArgs e) => this.FindFood(this.storage, this.nameFind.Text);
		}*/

		private void BuildSearchFood(){
			this.searchFoodWindow.Destroy();

			this.searchFoodWindow = new ScrolledWindow();

			this.searchFoodWindow.ShadowType = ShadowType.EtchedIn;
			this.searchFoodWindow.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);

			this.foodTreeSearch = new TreeView(this.searchStore);
			this.foodTreeSearch.RulesHint = true;
			this.searchFoodWindow.Add(this.foodTreeSearch);
			this.rendererTextSearch = new CellRendererText();
			this.columnSearch = new TreeViewColumn("Name", this.rendererTextSearch, new object[]{ "text", Column.Name });
			this.foodTreeSearch.AppendColumn(this.columnSearch);
			this.rendererTextSearch = new CellRendererText();
			this.columnSearch = new TreeViewColumn("Brand", this.rendererTextSearch, new object[]{ "text", Column.Brand });
			this.foodTreeSearch.AppendColumn(this.columnSearch);
			this.rendererTextSearch = new CellRendererText();
			this.columnSearch = new TreeViewColumn("Meal", this.rendererTextSearch, new object[]{ "text", Column.Meal });
			this.foodTreeSearch.AppendColumn(this.columnSearch);
			this.rendererTextSearch = new CellRendererText();
			this.columnSearch = new TreeViewColumn("Amount", this.rendererTextSearch, new object[]{ "text", Column.Amount });
			this.foodTreeSearch.AppendColumn(this.columnSearch);
			this.rendererTextSearch = new CellRendererText();
			this.columnSearch = new TreeViewColumn("Portion", this.rendererTextSearch, new object[]{ "text", Column.Portion });
			this.foodTreeSearch.AppendColumn(this.columnSearch);
			this.rendererTextSearch = new CellRendererText();
			this.columnSearch = new TreeViewColumn("Calories", this.rendererTextSearch, new object[]{ "text", Column.Calories });
			this.foodTreeSearch.AppendColumn(this.columnSearch);
			this.rendererTextSearch = new CellRendererText();
			this.columnSearch = new TreeViewColumn("Date", this.rendererTextSearch, new object[]{ "text", Column.Date });
			this.foodTreeSearch.AppendColumn(this.columnSearch);

			this.colLeftRowDown.PackStart(this.searchFoodWindow);

			this.colLeftRowDown.ShowAll();
			this.showAllFoods.Hide();
			this.addFoodWindow.Hide();
			this.deleteFoodWindow.Hide();
			this.findFoodWindow.Hide();
			//this.showAllWeights.Hide();
			//this.AddWeightWindow.Hide();
			//this.deleteWeightWindow.Hide ();
			this.mostrarDatosDia.Hide ();
		}

		private void BuildMostrarOnClick(string fecha){
			int i=0;
			this.mostrarDatosDia.Destroy ();

			this.mostrarDatosDia = new VBox ();

			List<Food> foods = getStorage();

			this.storeDay = new ListStore(new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(string), typeof(int) });
			foreach(Food food in foods){
				if (food.Date == fecha) {
					i++;
					this.storeDay.AppendValues(new object[] { food.Name, food.Brand, food.Meal, food.Amount, food.Portion, food.Calories });
				}


			}
			if (i == 0) {
				this.storeDay.AppendValues(new object[] { "Ninguna comida en este dia", null, null, null, null, null });
			}

			TreeView tree = new TreeView (this.storeDay);
			tree.RulesHint = true;

			mostrarDatosDia.Add (tree);

			rendererText = new CellRendererText ();

			TreeViewColumn colNombre = new TreeViewColumn ();
			colNombre.Title="Name";
			tree.AppendColumn (colNombre);
			CellRendererText foodNameCell = new CellRendererText ();
			colNombre.PackStart (foodNameCell, true);

			TreeViewColumn colBrand= new TreeViewColumn ();
			colBrand.Title="Brand";
			tree.AppendColumn (colBrand);
			CellRendererText foodBrandCell = new CellRendererText ();
			colBrand.PackStart (foodBrandCell, true);


			TreeViewColumn colMeal = new TreeViewColumn ();
			colMeal.Title="Meal";
			tree.AppendColumn (colMeal);
			CellRendererText foodMealCell = new CellRendererText ();
			colMeal.PackStart (foodMealCell, true);



			TreeViewColumn colAmount = new TreeViewColumn ();
			colAmount.Title="Amount";
			tree.AppendColumn (colAmount);
			CellRendererText foodAmountCell = new CellRendererText ();
			colAmount.PackStart (foodAmountCell, true);


			TreeViewColumn colPortion = new TreeViewColumn ();
			colPortion.Title="Portion";
			tree.AppendColumn (colPortion);
			CellRendererText foodPortionCell = new CellRendererText ();
			colPortion.PackStart (foodPortionCell, true);


			TreeViewColumn colCalorias = new TreeViewColumn ();
			colCalorias.Title="Calory";
			tree.AppendColumn (colCalorias);
			CellRendererText foodCaloryCell = new CellRendererText ();
			colCalorias.PackStart (foodCaloryCell, true);

			colNombre.AddAttribute (foodNameCell, "text", 0);
			colBrand.AddAttribute (foodBrandCell, "text", 1);
			colMeal.AddAttribute (foodMealCell, "text", 2);
			colAmount.AddAttribute (foodAmountCell, "text", 3);
			colPortion.AddAttribute (foodPortionCell, "text", 4);
			colCalorias.AddAttribute (foodCaloryCell, "text", 5);


			/*Label lab1 = new Label ();
			Label lab2 = new Label ();
			Label lab3 = new Label ();
			Label lab4 = new Label ();
			Label lab5 = new Label ();
			Label lab6 = new Label ();
			Label lab7 = new Label ();
			Label lab8 = new Label ();
			Label lab9 = new Label ();



			foreach (Food food in storage.Foods) {

				//Aquí cojemos las variables


				string[] format = food.Date.Split (' ');
				string aux = format [0];
				string[] format2 = aux.Split ('/');
				uint dayList = Convert.ToUInt16 (format2 [0]);
				uint monthList = Convert.ToUInt16 (format2 [1]);
				uint yearList = Convert.ToUInt16 (format2 [2]);

				if (dayList == daySelected && monthList == monthSelected && yearList == yearSelected) {
					lab9.Text = "---------------------------------------";
					lab2.Text = "Food Name: " + food.Name;
					lab3.Text = "Brand: " + food.Brand;
					lab4.Text = "Meal: " + food.Meal;
					lab5.Text = "Amount: " + food.Amount;
					lab6.Text = "Portion: " + food.Portion;
					lab7.Text = "Calories: " + food.Calories;
					lab8.Text = "---------------------------------------";

				}
			}


			lab1.Text = "Datos del día " + this.daySelected + "/" + this.monthSelected + "/" + this.yearSelected;
			mostrarDatosDia.Add (lab9);
			mostrarDatosDia.Add (lab1);
			mostrarDatosDia.Add (lab2);
			mostrarDatosDia.Add (lab3);
			mostrarDatosDia.Add (lab4);
			mostrarDatosDia.Add (lab5);
			mostrarDatosDia.Add (lab6);
			mostrarDatosDia.Add (lab7);
			mostrarDatosDia.Add (lab8);

			*/




			// Contenido a mostrar

			/* **************** */

			this.colLeftRowDown.PackStart (this.mostrarDatosDia);

			this.colLeftRowDown.ShowAll ();
			this.showAllFoods.Hide();
			this.addFoodWindow.Hide();
			this.deleteFoodWindow.Hide();
			this.findFoodWindow.Hide();
			this.searchFoodWindow.Hide ();
			//this.AddWeightWindow.Hide ();
			//this.showAllWeights.Hide ();
		}
	}
}