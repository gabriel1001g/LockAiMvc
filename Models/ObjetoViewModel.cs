using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LockaiMvc.Models
{
    public class ObjetoViewModel
    {
         public int Id { get; set; }

        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public string LocalidadePrimaria { get; set; }

        public string LocalidadeSecundaria { get; set; }

        public string LocalidadeTercearia { get; set; }

        public string Situacao { get; set; }

        public int idTipoObjeto { get; set; } 

        public string DataInclusao { get; set; }

        public int IdUsuarioInclusao { get; set; }

        public string DataAtualizacao { get; set; }

        public int IdUsuarioAtualizacao { get; set; }
        
    }
}