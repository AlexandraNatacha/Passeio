﻿using System.ComponentModel.DataAnnotations;

namespace Passeio.Dtos.Local
{
    public class CriarLocalDto
    {
        [Required(ErrorMessage = "O título é obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="A descrição é obrigatória!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="A localização é obrigatória!")]
        public string Localizacao { get; set; }

        [Required(ErrorMessage ="A Imagem é obrigatória")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "Digite seu usuário!")]
        public string UsuarioCriador { get; set; }
    }
}
