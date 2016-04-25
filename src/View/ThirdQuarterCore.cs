using System;
using System.Collections.Generic;
using Gtk;

using DIA.Core;

namespace DIA.View{
	public partial class MainWindow
		:Window{
		// Atributos
		private ListStore searchStore;

		// Añade una comida y un peso
		private void AddFood(Storage storage, string name, string brand, string meal, string amount, string portion, string calories,/*string peso,*/ string date){
			bool flag = false;

			foreach(Food food in storage.Foods){
				if(food.Name == name){
					flag = true;
					break;
				}
			}

			if(!flag){
				try{
					Food food = new Food(name, brand, meal, Convert.ToInt32(amount), portion, Convert.ToInt32(calories), date);
					this.storage.AddFood(food);
					this.BuildHome();
				}catch{
					string error = "Error! You have put some incorrect data.\nTry again ;).";
					this.BuildError(error);
					this.BuildAddFood();
				}
			}else{
				string error = "Error! You have already put a food with that name.\nTry again ;)";
				this.BuildError(error);
				this.BuildAddFood();
			}
		}



		// Elimina una comida
		private void DeleteFood(Storage storage, string name){
			try{
				int i = 0;

				foreach(Food food in storage.Foods){
					if(food.Name == name) break;
					else i++;
				}

				this.storage.Foods.RemoveAt(i);

				this.BuildHome();
				//this.BuildShowFoods();
			}catch{
				this.BuildError ("It doesn´t exist this food");
				// Mostrar mensaje de error!
				this.BuildDeleteFood();
			}
		}

		// Buscar una comida
		private void FindFood(Storage storage, string name){
			// Devuelve las tuplas que coincidan con el nombre a buscar. En caso negativo, devuelve una lista vacía
			var search = new List<Food>();

			foreach(Food food in storage.Foods){
				if(food.Name == name){
					search.Add(food);
					break;
				}
			}

			if(search.Count > 0){
				this.searchStore = new ListStore(new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(string), typeof(int), typeof(string) });
				foreach(Food food in search){ 
					this.searchStore.AppendValues(new object[] { food.Name, food.Brand, food.Meal, food.Amount, food.Portion, food.Calories, food.Date });
				}

				this.BuildSearchFood();
			}else{
				this.BuildError("Search not found :(");
				//this.BuildFindFood();
			}
		}
	}
}