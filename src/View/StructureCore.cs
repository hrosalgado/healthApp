using System;
using System.Collections.Generic;
using Gtk;

using DIA.Core;

namespace DIA.View{
	public partial class MainWindow{
		// Almacenamiento de comidas
		private Storage storage;
		private StoragePeso storagePeso;

		public List<Food> getStorage(){
			return this.storage.Foods;
		}

		public List<Peso> getStoragePesos(){
			return this.storagePeso.Peso;
		}

		// Mostrar todas las comidas
		private ListStore store;

		// Nested Types - Para crear el listado total de comidas
		private enum Column{
			Name,
			Brand,
			Meal,
			Amount,
			Portion,
			Calories,
			//Peso,
			Date
		}
		private enum ColumnPeso{
			Peso,
			Date
		}

		// Crea un nuevo almacenamiento de comidas.
		// Se ejecuta cada vez que se lanza la aplicación
		private void Init(){
			//Cargado de comidas
			this.storage = new Storage();
			this.storage.loadXml();
			//Cargado de pesos
			this.storagePeso = new StoragePeso();
			this.storagePeso.loadXml();
		}

		// Exit
		// Guarda las comidas almacenadas en cada ejecución de la aplicación en un archivo .xml
		// Se ejecuta al salir de la aplicación
		private void Exit(){
			this.storage.SaveXml();
			this.storagePeso.SaveXml ();
		}
	}
}