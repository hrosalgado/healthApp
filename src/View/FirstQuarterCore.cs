using System;
using System.Xml;
using System.Text;
using Gtk;

using DIA.Core;

namespace DIA.View{
	public partial class MainWindow
		:Window{

		private void markDays(){
			foreach (Food food in storage.Foods) {
				string[] format = food.Date.Split(' ');
				string aux = format [0];
				string[] format2 = aux.Split ('/');
				uint day = Convert.ToUInt16 (format2 [0]);

				this.calendar.MarkDay (day);
			}



			/*XmlDocument xDoc = new XmlDocument ();
			xDoc.Load("foods.xml");

			XmlNodeList xRegistros = xDoc.GetElementsByTagName ("Foods");
			XmlNodeList xLista = ((XmlElement)xRegistros [0]).GetElementsByTagName ("Food");

			foreach (XmlElement nodo in xLista) {

				dateToMark=nodo.GetAttribute ("Date");

				array to format the date and get the day number
				string[] format1 = dateToMark.Split (' ');
				string aux1 = format1 [0];
				string[] format2 = aux1.Split ('/');
				uint day = Convert.ToUInt16 (format2 [0]);

				this.calendar.MarkDay (day);*/
		}
	}
}