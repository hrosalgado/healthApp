using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DIA.Core{
	public class StoragePeso{
		private List<Peso> pesos = new List<Peso>();

		public List<Peso> Peso{
			get{
				return this.pesos;
			}
		}

		public void AddPeso(Peso peso){
			//pesos.Add(peso);


			string fecha = peso.Fecha;

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
			if (this.pesos.Count == 0) {
				this.pesos.Add (peso);
			}else{
				int i = 0;
				int fecha5 = 0;
				foreach (Peso pesoo in this.Peso) {
					string[] auxF = pesoo.Fecha.Split('/');
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
						this.pesos.Insert (i, peso);
						break;
					}
					i++;
				}
				if (fecha3 > fecha5) {
					this.pesos.Add (peso);
				}
			}
		}

		public void loadXml(){
			if(File.Exists("listaPesos.xml")){
				var xmlFile = new XmlDocument();

				try{
					xmlFile.Load("listaPesos.xml");

					if(xmlFile.DocumentElement.Name == "Pesos"){
						int peso = 0;
						string date = Convert.ToString(DateTime.Today);
						foreach(XmlNode node in xmlFile.DocumentElement.ChildNodes){
							if(node.Name == "Peso"){

								XmlAttribute attrCalories = node.Attributes["peso"];
								if(attrCalories != null){
									peso = Convert.ToInt32(attrCalories.InnerText);
								}

								XmlAttribute attrDate = node.Attributes["fecha"];
								if(attrDate != null){
									date = attrDate.InnerText;
								}
							}
								
							Peso pesoo = new Peso(peso, date);
							this.pesos.Add(pesoo);
						}
					}
				} catch(Exception){
					Console.WriteLine("Error!");
				}
			}else Console.WriteLine("No hay archivo para cargar.");
		}

		public void SaveXml(){
			var xmlFile = new XmlTextWriter("listaPesos.xml", Encoding.UTF8);
			xmlFile.Formatting = Formatting.Indented;

			xmlFile.WriteStartDocument();
			xmlFile.WriteStartElement("Pesos");

			foreach(Peso peso in Peso){
				xmlFile.WriteStartElement("Peso");

				xmlFile.WriteStartAttribute("peso");
				xmlFile.WriteValue(peso.Pes);
				xmlFile.WriteEndAttribute();

				xmlFile.WriteStartAttribute("fecha");
				xmlFile.WriteString(peso.Fecha);
				xmlFile.WriteEndAttribute();

				xmlFile.WriteEndElement();
			}

			xmlFile.WriteEndElement();
			xmlFile.WriteEndDocument();
			xmlFile.Close();
		}
	}
}

