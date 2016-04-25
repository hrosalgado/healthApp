using System;
using Gtk;
using DIA.Core;
using System.Collections.Generic;

namespace DIA.View{
	public partial class MainWindow
		:Window{
		//Elimina peso
		private void DeleteWeight(string date){
			int i = 0;
			try{
				List<Peso> pesos = getStoragePesos ();
				foreach(Peso peso in pesos){
					if(peso.Fecha==date)
					{
						storagePeso.Peso.Remove(peso);
						i++;
						break;
					}
				}
				if(i==0){
					this.BuildError ("It doesn´t exist a weight in this date");
					this.BuildDeletePeso();
				}
				this.BuildHome();
				//this.ListarPeso();
			}catch{
				
				this.BuildDeletePeso();
			}
		}
		private void AddPeso(StoragePeso storagePeso, string peso, string date)
		{
			bool flag = false;
			foreach(Peso pesoo in storagePeso.Peso){
				if(pesoo.Fecha == date){
					flag = true;
					break;
				}
			}
			if(!flag){

				try{
					Peso pesoo = new Peso(Convert.ToInt32(peso), date);
					this.storagePeso.AddPeso(pesoo);
					this.BuildHome();
				}catch{
					string error = "Error! You have put some incorrect data.\nTry again ;).";
					this.BuildError(error);
					this.BuildAddPeso();
				}
			}else{
				string error = "Error! You have already put a weight with that date.\nTry again ;)";
				this.BuildError(error);
				this.BuildAddPeso();
			}
		}
	}
}