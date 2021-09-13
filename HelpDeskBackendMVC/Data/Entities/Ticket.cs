using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskBackendMVC.Data.Entities
{
	public class Ticket
	{
		private List<TicketMensagem> _mensagens = new();
		private List<TicketMensagem> _notasInternas = new();

		public Ticket(int usuarioId, string mensagem, TicketStatus status, int? atendenteId = null)
		{
			UsuarioId = usuarioId;
			Status = status;
			AtendenteId = atendenteId;
			_mensagens.Add(new TicketMensagem(usuarioId, mensagem));
		}

		public int UsuarioId { get; private set; }

		public TicketStatus Status { get; private set; }

		public int? AtendenteId { get; private set; }

		public IReadOnlyCollection<TicketMensagem> Mensagens => _mensagens;

		public IReadOnlyCollection<TicketMensagem> NotasInternas => _notasInternas;


		public static Ticket Create(int usuarioId, string mensagem)
		{
			var ticket = new Ticket(usuarioId, mensagem, TicketStatus.EmAberto);

			return ticket;
		}

		public void IniciarAtendimento(int atendenteId)
		{
			AtendenteId = atendenteId;
			Status = TicketStatus.EmAtendimento;
		}

		public void AdicionarMensagem(int usuarioId, string conteudo)
		{
			_mensagens.Add(new TicketMensagem(usuarioId, conteudo));
		}

		public void AdicionarNotaInterna(int usuarioId, string conteudo)
		{
			_notasInternas.Add(new TicketMensagem(usuarioId, conteudo));
		}
	}

	public enum TicketStatus
	{
		EmAberto,
		EmAtendimento,
	}

}
