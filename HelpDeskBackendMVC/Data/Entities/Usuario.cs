namespace HelpDeskBackendMVC.Data.Entities
{
	public class Usuario
	{
		public Usuario(int id, string nome)
		{
			Id = id;
			Nome = nome;
		}

		public int Id { get; private set; }

		public string Nome { get; private set; }

		public static Usuario Create(string nome)
		{
			return new Usuario(default, nome);
		}

	}
}
