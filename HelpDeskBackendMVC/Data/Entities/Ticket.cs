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

		public Ticket(Usuario autor, Departamento departamento, string mensagem, TicketStatus status, Usuario? atendente = null)
		{
			Autor = autor;
			Departamento = departamento;
			Status = status;
			Atendente = atendente;
			_mensagens.Add(new TicketMensagem(autor, mensagem));
		}

		public Usuario Autor { get; private set; }

		public Departamento Departamento { get; private set; }

		public TicketStatus Status { get; private set; }


		// TODO: Refatorar Usuario para Atendente
		public Usuario? Atendente { get; private set; }

		public IReadOnlyCollection<TicketMensagem> Mensagens => _mensagens;

		public IReadOnlyCollection<TicketMensagem> NotasInternas => _notasInternas;


		public static Ticket Create(Usuario usuario, Departamento departamento, string mensagem)
		{
			var ticket = new Ticket(usuario, departamento, mensagem, TicketStatus.EmAberto);

			return ticket;
		}

		// TODO: Refatorar Usuario para Atendente
		public void IniciarAtendimento(Usuario atendente)
		{
			Atendente = atendente;
			Status = TicketStatus.EmAtendimento;
		}

		public void AdicionarMensagem(Usuario usuario, string conteudo)
		{
			_mensagens.Add(new TicketMensagem(usuario, conteudo));
		}

		public void AdicionarNotaInterna(Usuario usuario, string conteudo)
		{
			_notasInternas.Add(new TicketMensagem(usuario, conteudo));
		}

		// TODO: Refatorar Usuario para Atendente
		public void Encaminhar(Usuario atendenteDestino, string notaEncaminhamento)
		{
			var atendenteAtual = this.Atendente ?? atendenteDestino;

			_notasInternas.Add(new TicketMensagem(atendenteAtual, notaEncaminhamento));
			Atendente = atendenteDestino;
			Status = TicketStatus.Encaminhado;
		}

		// TODO: Refatorar Usuario para Atendente
		public void Finalizar(Usuario atendenteFinalizacao, string notaFinalizacao)
		{
			_notasInternas.Add(new TicketMensagem(atendenteFinalizacao, notaFinalizacao));
			Atendente = null;
			Status = TicketStatus.Finalizado;
		}
	}
}
