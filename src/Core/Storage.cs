using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DIA.Core{
	public class Storage{
		private List<Food> foods = new List<Food>();

		public List<Food> Foods{
			get{
				return this.foods;
			}
		}

		public void AddFood(Food food){
			//this.Foods.Add (food);

			string fecha = food.Date;

			string[] aux = fecha.Split ('/');
			//Console.WriteLine ("LOOOOL");
			if (aux [1].Length < 2) {
				aux [2] += "0";
			}
			if (aux [0].Length < 2) {
				aux[1] +="0";
			}
			string fecha2= Convert.ToString(aux[2]+aux[1]+aux[0]);
			//Console.WriteLine ("LOOOOL23");
			//Console.WriteLine (aux[2]);
			int fecha3 = Convert.ToInt32 (fecha2);
			//Console.WriteLine (fecha3);
			if (this.foods.Count == 0) {
				this.Foods.Add (food);
			}else{
				int i = 0;
				int fecha5 = 0;
				foreach (Food foood in this.Foods) {
					string[] auxF = foood.Date.Split('/');
					//Foods.Insert (i, foood);
					if (auxF [1].Length < 2) {
						auxF [2] += "0";
					}
					if (auxF [0].Length < 2) {
						auxF[1] +="0";
					}
					string fecha4= (auxF[2]+auxF[1]+auxF[0]);
					fecha5 = Convert.ToInt32 (fecha4);
					if (fecha3 <= fecha5 ) {
						//Console.WriteLine ("Fecha a insertar" +fecha3);
						//Console.WriteLine ("Fecha BD" +fecha5);
						this.Foods.Insert (i, food);
						break;
					}
					i++;
				}
				if (fecha3 > fecha5) {
					this.Foods.Add (food);
				}	
			}
		}

		public void loadXml(){
			if(File.Exists("foods.xml")){
				var xmlFile = new XmlDocument();

				try{
					xmlFile.Load("foods.xml");

					if(xmlFile.DocumentElement.Name == "Foods"){
						string name = "";
						string brand = "";
						string meal = "";
						int amount = 0;
						string portion = "";
						int calories = 0;
						string date = Convert.ToString(DateTime.Today);
						foreach(XmlNode node in xmlFile.DocumentElement.ChildNodes){
							if(node.Name == "Food"){
								XmlAttribute attrName = node.Attributes["Name"];
								if(attrName != null){
									name = attrName.InnerText;
								}

								XmlAttribute attrBrand = node.Attributes["Brand"];
								if(attrBrand != null){
									brand = attrBrand.InnerText;
								}

								XmlAttribute attrMeal = node.Attributes["Meal"];
								if(attrMeal != null){
									meal = attrMeal.InnerText;
								}

								XmlAttribute attrAmount = node.Attributes["Amount"];
								if(attrAmount != null){
									amount = Convert.ToInt32(attrAmount.InnerText);
								}

								XmlAttribute attrPortion = node.Attributes["Portion"];
								if(attrPortion != null){
									portion = attrPortion.InnerText;
								}

								XmlAttribute attrCalories = node.Attributes["Calories"];
								if(attrCalories != null){
									calories = Convert.ToInt32(attrCalories.InnerText);
								}

								XmlAttribute attrDate = node.Attributes["Date"];
								if(attrDate != null){
									date = attrDate.InnerText;
								}
							}

							name = name.Trim();
							brand = brand.Trim();
							meal = meal.Trim();
							portion = portion.Trim();

							Food food = new Food(name, brand, meal, amount, portion, calories, date);
							this.Foods.Add(food);
						}
					}
				} catch(Exception){
					Console.WriteLine("Error!");
				}
			}else Console.WriteLine("No hay archivo para cargar.");
		}

		public void SaveXml(){
			var xmlFile = new XmlTextWriter("foods.xml", Encoding.UTF8);
			xmlFile.Formatting = Formatting.Indented;

			xmlFile.WriteStartDocument();
			xmlFile.WriteStartElement("Foods");

			foreach(Food food in Foods){
				xmlFile.WriteStartElement("Food");

				xmlFile.WriteStartAttribute("Name");
				xmlFile.WriteString(food.Name);
				xmlFile.WriteEndAttribute();

				xmlFile.WriteStartAttribute("Brand");
				xmlFile.WriteString(food.Brand);
				xmlFile.WriteEndAttribute();

				xmlFile.WriteStartAttribute("Meal");
				xmlFile.WriteString(food.Meal);
				xmlFile.WriteEndAttribute();

				xmlFile.WriteStartAttribute("Amount");
				xmlFile.WriteValue(Convert.ToString(food.Amount));
				xmlFile.WriteEndAttribute();

				xmlFile.WriteStartAttribute("Portion");
				xmlFile.WriteString(food.Portion);
				xmlFile.WriteEndAttribute();

				xmlFile.WriteStartAttribute("Calories");
				xmlFile.WriteValue(Convert.ToString(food.Calories));
				xmlFile.WriteEndAttribute();

				xmlFile.WriteStartAttribute("Date");
				xmlFile.WriteString(food.Date);
				xmlFile.WriteEndAttribute();

				xmlFile.WriteEndElement();
			}

			xmlFile.WriteEndElement();
			xmlFile.WriteEndDocument();
			xmlFile.Close();
		}
	}
}

