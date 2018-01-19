using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Services;
using static BLL.Voto;

public partial class _Default : Page
{
    public class AjaxRequestResult
    {
        public bool result { get; set; }
        public string msg { get; set; }
        public string json { get; set; }
        public AjaxRequestResult(bool pResult, string pMsg)
        {
            result = pResult;
            msg = pMsg;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {

            ddlEquipe.DataSource = Equipe.RetornaLista();
            ddlEquipe.DataBind();

            
            rblRestaurante.DataSource = Restaurante.RetornaLista();
            rblRestaurante.DataBind();

            foreach (ListItem item in rblRestaurante.Items)
            {
                item.Attributes.Add("class", "btn btn-primary");
            }


        }
    }



    [WebMethod]
    public static AjaxRequestResult SalvarCadastro(string pNome, string pEmail)
    {
        AjaxRequestResult r;

        try
        {

            DAL.DAOUsuario.DadosUsuario oUsuario = new DAL.DAOUsuario.DadosUsuario();
            oUsuario.Nome = pNome;
            oUsuario.Email = pEmail;


            if (Usuario.VerificaSeExiste(pEmail))
            {
                if (string.IsNullOrEmpty(pNome))
                {
                    r = new AjaxRequestResult(true, "");
                }
                else
                {
                    r = new AjaxRequestResult(false, "Email Já Cadastrado!\nVocê Será Direcionado Para a Votação!");
                }
            }
            else
            {
                r = Newtonsoft.Json.JsonConvert.DeserializeObject<AjaxRequestResult>(Usuario.Salvar(oUsuario));
            }

        }
        catch (Exception e)
        {
            r = new AjaxRequestResult(false, e.Message);
        }


        return r;

    }

    [WebMethod]
    public static AjaxRequestResult SalvarVoto(int pDiaSemana, string pEmail, int pIDRestaurante)
    {
        AjaxRequestResult r;

        try
        {

            DAL.DAOVoto.DadosVoto oVoto = new DAL.DAOVoto.DadosVoto();
            oVoto.IDRestaurante = pIDRestaurante;
            oVoto.DiaSemana = pDiaSemana;
            oVoto.IDUsuario = Usuario.RetornaIDUsuario(pEmail);

            Voto.ValidaVoto(oVoto);

            r = Newtonsoft.Json.JsonConvert.DeserializeObject<AjaxRequestResult>(Voto.Salvar(oVoto));
            
        }
        catch (Exception e)
        {
            r = new AjaxRequestResult(false, e.Message);
        }


        return r;

    }


    [WebMethod]
    public static AjaxRequestResult VerResultado(int pDiaSemana)
    {
        AjaxRequestResult r;

        try
        {
            Voto.Recarregar();
            RestauranteVencedorDoDia ret = Voto.RetornaRestauranteVencedorPorDia(pDiaSemana);
            if(ret == null)
            {
                r = new AjaxRequestResult(true, "Dia Ainda Sem Votos");
            } else
            {
                r = new AjaxRequestResult(true, "");
                r.json = Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }

        }
        catch (Exception e)
        {
            r = new AjaxRequestResult(false, e.Message);
        }


        return r;

    }



}