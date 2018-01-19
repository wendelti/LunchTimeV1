using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAOEquipe : Base
    {

        private static volatile DAOEquipe instance;
        private static object syncRoot = new Object();

        private DAOEquipe()
        {
            this.servico = "Equipe";
        }

        public static DAOEquipe Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DAOEquipe();
                    }
                }

                return instance;
            }
        }

        public class DadosEquipe
        {
            public int ID { get; set; }
            public string Nome { get; set; }
        }
        
        public string Salvar(DadosEquipe reg)
        {
            return this.Salvar<DadosEquipe>(reg);
        }

        public List<DadosEquipe> Get()
        {
            return this.Get<DadosEquipe>();
        }
    }
}
