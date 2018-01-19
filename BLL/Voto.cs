using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Voto
    {


        public class RestauranteVencedorDoDia
        {
            public int IDRestaurante { get; set; }
            public string NomeRestaurante { get { return Restaurante.RetornaLista().Where(r => r.ID == this.IDRestaurante).Single().Nome; } }
            public int Qtd { get; set; }
        }

        private static List<DAOVoto.DadosVoto> mLista = null;
        public static List<DAOVoto.DadosVoto> RetornaLista()
        {
            if (mLista == null)
            {
                mLista = DAOVoto.Instance.Get();
            }

            return mLista;
        }

        public static void Recarregar()
        {
            mLista = null;
        }
        public static string Salvar(DAOVoto.DadosVoto reg)
        {
            mLista = null;
            return DAOVoto.Instance.Salvar(reg);
        }

        public static void VerificaSeClienteJaVotou(DAOVoto.DadosVoto reg)
        {

            if (RetornaLista().Exists(v => v.DiaSemana == reg.DiaSemana && v.IDUsuario == reg.IDUsuario))
            {
                throw new UsuarioJaVotouException("Você Já Realizou um Voto Para Este Dia da Semana");
            }

        }

        public static RestauranteVencedorDoDia RetornaRestauranteVencedorPorDia(int DiaSemana)
        {
            return RetornaLista()
                    .Where(v => v.DiaSemana == DiaSemana)
                    .GroupBy(v => new { v.IDRestaurante })
                    .Select(v => new RestauranteVencedorDoDia { IDRestaurante = v.Key.IDRestaurante, Qtd = v.Count() })
                    .OrderByDescending(v => v.Qtd).FirstOrDefault();

        }


        public static void VerificaSeRestauranteJaFoiSelecionado(DAOVoto.DadosVoto reg)
        {
            
            for (int i =1; i < reg.DiaSemana; i++)
            {
                RestauranteVencedorDoDia rvd = RetornaRestauranteVencedorPorDia(i);
                if (rvd != null && rvd.IDRestaurante == reg.IDRestaurante)
                {
                    throw new RestauranteJaEscolhidoException("Este Restaurante Já Foi Selecionado Para Outro Dia da Semana");
                }

            }    

        }
        

        public static bool ValidaVoto(DAOVoto.DadosVoto reg)
        {

            VerificaSeClienteJaVotou(reg);
            VerificaSeRestauranteJaFoiSelecionado(reg);
            return true;
        }

    }
}
