namespace Web.Model
{
	//Костыль:
	// Не понял как решить проблему в Circular Dependency ( не мог в Application.Interfaces напрямую обратиться к данному классу,
	// из-за этого класс находится здесь, а не в Web.Model)
	public class EatModel
	{
		public DateTime EatTime { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }
		public string DishName { get; set; }
	}
}
