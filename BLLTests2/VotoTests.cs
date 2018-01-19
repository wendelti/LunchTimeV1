using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.Voto;

namespace BLL.Tests
{
    [TestClass()]
    public class VotoTests
    {
        [TestMethod()]
        public void RetornaListaTest()
        {
            Voto target = new Voto();

            PrivateType pt = new PrivateType(typeof(Voto));
            var lista = pt.InvokeStatic("RetornaLista");

            Assert.AreEqual(lista.GetType(), typeof(List<DAOVoto.DadosVoto>));

        }
        

        [TestMethod()]
        [ExpectedException( typeof(BLL.UsuarioJaVotouException))]
        public void VerificaSeClienteJaVotouTest()
        {
            //Dados de um voto salvo no banco
            DAOVoto.DadosVoto dados = new DAOVoto.DadosVoto();
            dados.DiaSemana = 1;
            dados.IDRestaurante = 1;
            dados.IDUsuario = 1;

            PrivateType pt = new PrivateType(typeof(Voto));
            pt.InvokeStatic("ValidaVoto", dados);
            

        }
        

        [TestMethod()]
        [ExpectedException(typeof(BLL.RestauranteJaEscolhidoException))]
        public void VerificaSeRestauranteJaFoiSelecionadoTest()
        {
            DAOVoto.DadosVoto dados = new DAOVoto.DadosVoto();
            dados.DiaSemana = 3;
            dados.IDUsuario = 1;

            PrivateType pt = new PrivateType(typeof(Voto));
            RestauranteVencedorDoDia rvd = (RestauranteVencedorDoDia)pt.InvokeStatic("RetornaRestauranteVencedorPorDia", 2);

            dados.IDRestaurante = rvd.IDRestaurante;
            pt.InvokeStatic("ValidaVoto", dados);

        }
        
    }
}