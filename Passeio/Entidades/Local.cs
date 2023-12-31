﻿using Passeio.Api.Enums;

namespace Passeio.Entidades
{
    public class Local
    {
        public Local(string titulo, string descricao, string localizacao, string imagem, string usuarioCriador)
        {
            Titulo = titulo;
            Descricao = descricao;
            Localizacao = localizacao;
            Imagem = imagem;
            UsuarioCriador = usuarioCriador;
            Comentarios = new List<Comentario>();
            DataDeCriacao = DateTime.Now;
            Status = StatusDoLocal.Ativo;
        }

        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Localizacao { get; private set; }
        public string Imagem { get; private set; }
        public string UsuarioCriador { get; private set; }
        public List<Comentario> Comentarios { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }
        public StatusDoLocal Status { get; private set; }

        public void Editar(string titulo, string descricao, string localizacao, string imagem )
        {
            Titulo = titulo;
            Descricao = descricao;
            Localizacao = localizacao;
            Imagem = imagem;
            DataDeAtualizacao = DateTime.Now;
        }

        public void Inativar()
        {
            Status = StatusDoLocal.Inativo;
        }
    }
}
