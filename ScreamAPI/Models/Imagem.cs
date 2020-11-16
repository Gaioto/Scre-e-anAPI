using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScreamAPI.Models
{
    [Table("Tb_Imagens")]
    public class Imagem
    {
        [Column("id_imagem")]
        [Key]
        public int IdImagem { get; set; }

        [Column("nm_imagem")]
        public string NomeImagem { get; set; }

        [Column("arq_imagem")]
        public string ArquivoImagem { get; set; }

        [Column("ex_imagem")]
        public bool ExclusaoImagem { get; set; }

    }
}
