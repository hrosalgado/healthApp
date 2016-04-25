using System;

namespace DIA.Core{
	public class Food{
		public string Name{ get; set; }
		public string Brand{ get; set; }
		public string Meal{ get; set; }
		public int Amount{ get;	set; }
		public string Portion{ get; set; }
		public int Calories{ get; set; }
		public string Date{ get; set; }

		public Food(string name, string brand, string meal, int amount, string portion, int calories, string date){
			this.Name = name;
			this.Brand = brand;
			this.Meal = meal;
			this.Amount = amount;
			this.Portion = portion;
			this.Calories = calories;
			this.Date = date;
		}
	}
}

