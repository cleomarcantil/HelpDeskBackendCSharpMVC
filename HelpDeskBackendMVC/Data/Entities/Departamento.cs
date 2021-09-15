namespace HelpDeskBackendMVC.Data.Entities
{
	public class Departamento
	{
		public Departamento(int id, string nome)
		{
			Id = id;
			Nome = nome;
		}

		public int Id { get; private set; }

		public string Nome { get; private set; }

		public static Departamento Create(string nome)
		{
			return new Departamento(default, nome);
		}


	}
}
