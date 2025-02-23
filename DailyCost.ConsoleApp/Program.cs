using DailyCost.ConsoleApp;

DailyCostAdo ado= new DailyCostAdo();
//ado.Create();
//ado.Read();
//ado.Update();
//ado.Delete();

DailyAdoService adoService=new DailyAdoService();
adoService.Edit(1);
//adoService.Read();