using System;
using Gtk;

namespace DIA.View{
	public partial class MainWindow
		:Window{
		private void BuildAddPeso(){
			this.AddWeightWindow.Destroy();

			this.AddWeightWindow = new VBox();

			this.firstRowAdd = new HBox(false, 0);
			this.secondRowAdd = new HBox(false, 0);
			this.thirdRowAdd = new HBox(false, 0);
			this.fourthRowAdd = new HBox (false, 0);
			this.pesoHeaderAdd = new Label("Weight (Kg)");
			this.pesoAdd = new Entry();

			this.firstRowAdd.PackStart(this.pesoHeaderAdd,true,true,5);
			this.secondRowAdd.PackStart(this.pesoAdd,true,true,5);

			this.calendarAdd = new Calendar();
			this.calendarAdd.DaySelected += new EventHandler(this.OnDaySelected);

			this.output = Convert.ToString (DateTime.Today.Day+"/"+DateTime.Today.Month+"/"+DateTime.Today.Year);
			this.aux = output.Split (' ');
			this.aux2 = aux [0];

			this.thirdRowAdd.PackStart(this.calendarAdd,true,true,5);

			this.okAdd = new Button("Add");

			this.fourthRowAdd.PackStart(this.okAdd,true,true,5);

			this.AddWeightWindow.PackStart(this.firstRowAdd,false,false,2);
			this.AddWeightWindow.PackStart(this.secondRowAdd,false,false,2);
			this.AddWeightWindow.PackStart(this.thirdRowAdd,false,false,2);
			this.AddWeightWindow.PackStart(this.fourthRowAdd,false,false,2);
			this.colRightRowUp.PackStart(this.AddWeightWindow);

			this.colRightRowUp.ShowAll();

			this.showAllWeights.Hide();
			this.deleteWeightWindow.Hide();

			this.okAdd.Clicked += 
				(sender, e) =>
				this.AddPeso (this.storagePeso, this.pesoAdd.Text,  this.output);
		}

		private void ListarPeso(){
			this.showAllWeights.Destroy();

			this.showAllWeights = new ScrolledWindow();

			this.showAllWeights.ShadowType = ShadowType.EtchedIn;
			this.showAllWeights.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);

			this.PesosStore();

			this.foodTree = new TreeView(this.store);
			this.foodTree.RulesHint = true;
			this.showAllWeights.Add(this.foodTree);
			this.rendererText = new CellRendererText();
			this.column = new TreeViewColumn("Weight", this.rendererText, new object[]{ "text", ColumnPeso.Peso });
			this.foodTree.AppendColumn(this.column);
			this.column = new TreeViewColumn("Date", this.rendererText, new object[]{ "text", ColumnPeso.Date });
			this.foodTree.AppendColumn(this.column);

			this.colRightRowUp.PackStart(this.showAllWeights);

			this.colRightRowUp.ShowAll();

			this.deleteWeightWindow.Hide();
			this.AddWeightWindow.Hide();
		}

		private void BuildDeletePeso(){
			this.ListarPeso();

			this.deleteWeightWindow.Destroy();

			this.deleteWeightWindow = new VBox();

			this.firstRowDel = new HBox(false, 0);
			this.secondRowDel = new HBox(false, 0);
			this.thirdRowDel = new HBox(false, 0);

			this.nameHeaderDelete = new Label("Enter the date weight to delete (DD/MM/YY)");

			this.firstRowDel.PackStart(this.nameHeaderDelete, true, true, 5);

			this.nameDelete = new Entry();

			this.secondRowDel.PackStart(this.nameDelete, true, true, 5);

			this.okDelete = new Button("Delete");

			this.thirdRowDel.PackStart(this.okDelete, true, true, 5);

			this.deleteWeightWindow.PackStart(this.firstRowDel, false, false, 5);
			this.deleteWeightWindow.PackStart(this.secondRowDel, false, false, 5);
			this.deleteWeightWindow.PackStart(this.thirdRowDel, false, false, 5);

			this.colRightRowUp.PackStart(this.deleteWeightWindow);

			this.colRightRowUp.ShowAll();
			this.AddWeightWindow.Hide();

			this.okDelete.Clicked += (object sender, EventArgs e) => this.DeleteWeight(this.nameDelete.Text);
		}
	}
}