namespace HelpDeskBackendMVC.Data.Entities
{
	public class TicketMensagem
	{
		public TicketMensagem(int usuarioId, string conteudo)
		{
			UsuarioId = usuarioId;
			Conteudo = conteudo;
		}

		public int UsuarioId { get; set; }

		public string Conteudo { get; private set; }

	}

}
