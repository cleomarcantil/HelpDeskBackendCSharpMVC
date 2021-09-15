namespace HelpDeskBackendMVC.Data.Entities
{
	public class TicketMensagem
	{
		public TicketMensagem(Usuario autor, string conteudo)
		{
			Autor = autor;
			Conteudo = conteudo;
		}

		public Usuario Autor { get; set; }

		public string Conteudo { get; private set; }

	}

}
