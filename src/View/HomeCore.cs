using System;
using System.Collections.Generic;
using Gtk;
using System.Text;

using DIA.Core;

namespace DIA.View{
	public partial class MainWindow
		:Window{
		private DateTime dateFirst;
		// Listado de todas las comidas
		private void FillStore(){
			List<Food> foods = getStorage();
			this.store = new ListStore(new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(string), typeof(int), typeof(string) });
			foreach(Food food in foods){
				this.store.AppendValues(new object[] { food.Name, food.Brand, food.Meal, food.Amount, food.Portion, food.Calories, food.Date });
			}
		}
		private void PesosStore(){
			List<Peso> pesos = getStoragePesos ();
			this.store = new ListStore(new Type[] { typeof(int), typeof(string) });
			foreach (Peso peso in pesos) {
				this.store.AppendValues(new object[] { peso.Pes, peso.Fecha});

			}
		}

		
		/*************************PARTE DE ALEJANDRO*********************************************/
		/*variables empleadas para mostrar la informacion del dia en concreto*/
		private uint daySelected;
		private uint monthSelected;
		private uint yearSelected;


		private void month_clicked(object sender, EventArgs args){
			int dayAux = this.calendar.Day;
			int month = this.calendar.Month + 1;
			int year = this.calendar.Year;
			//Console.WriteLine ("Día " + dayAux + " Mes " + month + " Ano " + year);
			this.calendar.ClearMarks ();
			for (uint i = 1; i<= 31; i++) {

				uint day = 0;
				int month2 = 0;
				int year2 = 0;

				foreach (Food food in storage.Foods) {
					string[] format = food.Date.Split (' ');
					string aux = format [0];
					string[] format2 = aux.Split ('/');
					day = Convert.ToUInt16 (format2 [0]);
					month2 = Convert.ToInt16 (format2 [1]);
					year2 = Convert.ToInt16 (format2 [2]);

					if (i == day && month == month2 && year == year2) {

						this.calendar.MarkDay (i);
					}
				}
			}
		}

		private void date_clicked(object sender, EventArgs args){
			///Cojemos la fecha seleccionada del calendario.
			this.calendar = (Calendar)sender;
			this.dateFirst = new DateTime (this.calendar.Year, this.calendar.Month + 1, this.calendar.Day);



			string displayed = this.dateFirst.ToString ("yyyyMMdd");
			string yearAux = this.dateFirst.ToString ("yyyy");
			yearSelected = Convert.ToUInt16 (yearAux);
			string monthAux = this.dateFirst.ToString("MM");
			monthSelected = Convert.ToUInt16 (monthAux);
			string dayAux = this.dateFirst.ToString("dd");
			daySelected = Convert.ToUInt16 (dayAux);

			//Introduciendo a mayores dia seleccionado, mes y año no? -->TO alejandro
			string salida = this.daySelected+"/"+ this.monthSelected+"/"+ this.yearSelected;
			this.BuildMostrarOnClick (salida);



		}


		private void OnClose() {
			Gtk.Application.Quit();
		}




		private void getPesos()
		{

			//this.l = this.mean.getListWeights();
			//double []auxContainer = this.l.ToArray();


			/*foreach(Peso peso in this.p){
				Console.WriteLine(peso.Pes);
			}*/
			//Console.WriteLine(this.p);
			this.pesos = this.storagePeso.Peso.ToArray();
			double toRet = 0;
			short aux = 0;
			for (int i = 0; i < pesos.Length; ++i) {

				toRet += this.pesos[i].Pes;
				aux += 1;

			}

			this.pesosE.Text = Convert.ToString (toRet / aux);



		}

		private void getCalorias()
		{	

			//this.l = this.mean.getListCalories();
			//double []auxContainer = this.l.ToArray();
			this.calorias = this.storage.Foods.ToArray();
			double toRet = 0;
			short aux = 0;
			for (int i = 0; i < calorias.Length; ++i) {

				toRet += this.calorias[i].Calories;
				aux += 1;

			}

			this.caloriasE.Text = Convert.ToString (toRet / aux);

		}

		private Peso[] pesos;
		private Food[] calorias;
	}
}