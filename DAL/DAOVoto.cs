using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class DAOVoto : Base
    {

        private static volatile DAOVoto instance;
        private static object syncRoot = new Object();

        private DAOVoto()
        {
            this.servico = "Voto";
        }

        public static DAOVoto Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DAOVoto();
                    }
                }

                return instance;
            }
        }


        public class DadosVoto
        {
            public int ID { get; set; }
            public int IDUsuario { get; set; }
            public int IDRestaurante { get; set; }
            public int DiaSemana { get; set; }
            
        }
        

        public string Salvar(DadosVoto reg)
        {
            return this.Salvar<DadosVoto>(reg);
        }

        public List<DadosVoto> Get()
        {
            return this.Get<DadosVoto>();
        }

    }

}