using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAORestaurante : Base
    {


        private static volatile DAORestaurante instance;
        private static object syncRoot = new Object();

        private DAORestaurante()
        {
            this.servico = "Restaurante";
        }

        public static DAORestaurante Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DAORestaurante();
                    }
                }

                return instance;
            }
        }

        public class DadosRestaurante
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Preco { get; set; }
        }
        

        public string Salvar(DadosRestaurante reg)
        {
            return this.Salvar<DadosRestaurante>(reg);
        }

        public List<DadosRestaurante> Get()
        {
            return this.Get<DadosRestaurante>();
        }

    }
}
