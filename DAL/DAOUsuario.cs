using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public sealed class DAOUsuario : Base
    {

        private static volatile DAOUsuario instance;
        private static object syncRoot = new Object();

        private DAOUsuario()
        {
            this.servico = "Usuario";
        }

        public static DAOUsuario Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DAOUsuario();
                    }
                }

                return instance;
            }
        }

        public class DadosUsuario
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Nascimento { get; set; }
        }
        

        public string Salvar(DadosUsuario reg)
        {
            return this.Salvar<DadosUsuario>(reg);
        }

        public List<DadosUsuario> Get()
        {
            return this.Get<DadosUsuario>();
        }



    }
}
