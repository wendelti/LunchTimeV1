using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioJaVotouException : Exception
    {
        public UsuarioJaVotouException(string message) : base(message) { }
    }
    public class RestauranteJaEscolhidoException : Exception
    {
        public RestauranteJaEscolhidoException(string message) : base(message) { }
    }
}
