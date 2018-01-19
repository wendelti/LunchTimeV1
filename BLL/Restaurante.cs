using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Restaurante
    {

        private static List<DAORestaurante.DadosRestaurante> mLista = null;
        public static List<DAORestaurante.DadosRestaurante> RetornaLista()
        {
            if (mLista == null)
            {
                mLista = DAORestaurante.Instance.Get();
            }

            return mLista;
        }

        public static string Salvar(DAORestaurante.DadosRestaurante reg)
        {
            mLista = null;
            return DAORestaurante.Instance.Salvar(reg);
        }


    }
}
