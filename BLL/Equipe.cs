using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Equipe
    {

        private static List<DAOEquipe.DadosEquipe> mLista = null;
        public static List<DAOEquipe.DadosEquipe> RetornaLista()
        {
            if(mLista == null)
            {
                mLista = DAOEquipe.Instance.Get();
            }

            return mLista;
        }

        public static string Salvar(DAOEquipe.DadosEquipe reg)
        {
            mLista = null;
            return DAOEquipe.Instance.Salvar(reg);
        }
        

    }
}
