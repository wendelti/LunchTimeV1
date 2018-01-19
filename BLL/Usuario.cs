using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class Usuario
    {

        public static List<DAOUsuario.DadosUsuario> RetornaLista()
        {
            return DAOUsuario.Instance.Get();
        }

        public static bool VerificaSeExiste(string pEmail)
        {
            return Usuario.RetornaLista().Exists(u => u.Email == pEmail);
        }

        public static int RetornaIDUsuario(string pEmail)
        {
            return Usuario.RetornaLista().Find(u => u.Email == pEmail).ID;
        }

        public static string Salvar(DAOUsuario.DadosUsuario reg)
        {
            return DAOUsuario.Instance.Salvar(reg);
        }

    }
}
