<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">É HORA DO ALMOÇO!</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav" style="float: right;">
            <li><a href="#" id="linkSair">Sair</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <br />

    <div class="row">
        <div class="col-md-6">
            <h4>Segundo o Guia do Mochileiro das Galáxias:</h4>
            <p>
                A história de todas as grandes civilizações tende a atravessar três fases distintas: a da Sobrevivência, a da interrogação e a da Sofisticação. A Sobrevivência pode ser caracterizada pela pergunta: “Como vamos poder comer?”; a interrogação, pela pergunta: “Por que comemos?” e A Sofisticação, pela pergunta: <strong> “Aonde vamos almoçar?”</strong>.    
            </p>
        </div>
        <div class="col-md-6">

            <div class="tab-content">
                <ul class="nav nav-tabs hide">
                    <li><a href="#tab1" data-toggle="tab">Cadastro</a></li>
                    <li><a href="#tab2" data-toggle="tab">Votação</a></li>
                    <li><a href="#tab3" data-toggle="tab">Resultado</a></li>
                </ul>

	            <div class="tab-pane active" id="tab1">
                    
                      <div class="form-group">
                        <h3>Insira seu Email e Vote</h3>
                      </div>
                      <div class="form-group">
                        <label for="email">Email:</label>
                        <div class="form-inline">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"></asp:TextBox>
                            <button type="button" class="btn btn-primary btnEnviarCadastro" ID="btnEnviarCadastro1" data-loading-text="Enviando..." ><strong>Enviar</strong></button>
                        </div>
                      </div>
                    

                    
                      <div class="form-group">
                        <h3>Ou Complete seu Cadastro!</h3>
                      </div>

                      <div class="form-group">
                        <label for="email">Nome:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNome"></asp:TextBox>
                      </div>

                      <div class="form-group">
                        <label for="email">Equipe:</label>
                        <div class="form-inline">
                            <asp:DropDownList runat="server" ID="ddlEquipe" CssClass="form-control" DataTextField="Nome" DataValueField="ID">

                            </asp:DropDownList>
                            <button type="button" class="btn btn-primary btnEnviarCadastro" ID="btnEnviarCadastro2" data-loading-text="Enviando..." ><strong>Enviar</strong></button>
                        </div>
                      </div>
        
	            </div>

	            <div class="tab-pane" id="tab2">
            
                        <div class="form-group">
                            <label for="email">Dia da Semana:</label>
                            <div class="controls">
                
                                <asp:RadioButtonList runat="server" ID="rblDiaSemana" RepeatDirection="Horizontal" RepeatLayout="Flow"  CssClass="btn-group" data-toggle="buttons">
                                    <asp:ListItem Text="Segunda" Value="1" class="btn btn-primary"></asp:ListItem>
                                    <asp:ListItem Text="Terça" Value="2" class="btn btn-primary"></asp:ListItem>
                                    <asp:ListItem Text="Quarta" Value="3" class="btn btn-primary"></asp:ListItem>
                                    <asp:ListItem Text="Quinta" Value="4" class="btn btn-primary"></asp:ListItem>
                                    <asp:ListItem Text="Sexta" Value="5" class="btn btn-primary"></asp:ListItem>
                                </asp:RadioButtonList>

                                <button type="button" class="btn btn-success btn-lg btnVerResultado" id="btnVerResultado" data-loading-text="Consultando...">
                                  <strong>Ver Resultado</strong>
                                </button>

                            </div>
                        </div> 
            
                        <div class="form-group">
                            <label for="email">Restaurante:</label>
                            <div class="controls">
                
                                <asp:RadioButtonList runat="server" ID="rblRestaurante" DataTextField="Nome" DataValueField="ID" RepeatDirection="Horizontal" RepeatLayout="Flow"  CssClass="btn-group" data-toggle="buttons">

                                </asp:RadioButtonList>
                                
                                <button type="button" class=" hide btn btn-success btn-lg" data-toggle="modal" data-target="#myModal">
                                  <strong>Add Restaurante</strong>
                                </button>
                            </div>
                        </div> 

                        <div class="controls">
                
                            <button type="button" class="btn btn-success btn-lg" ID="btnEnviarVoto" data-loading-text="Enviando..." ><strong>Votar</strong></button>
                        
                        </div>
                    
	            </div>
	            <div class="tab-pane" id="tab3">
                        
                    <div id="boxResultado">

                        <h4>Com <label id="lblQtdVotos"></label> Voto(s)</h4>
                        <h3><label id="lblDiaSemana"></label> é dia de <label id="lblRestauranteVencedor"></label>!</h3>
                        
                        <button type="button" class="btn btn-success btn-lg btnVerResultado" id="btnAtualizarResultado" data-loading-text="Consultando...">
                            <strong><span class="glyphicon glyphicon-refresh"></span> Atualizar</strong>
                        </button>

                    </div>

                    <div id="boxSemResultado">
                        <h3>Nenhum Restaurante foi Selecionado Para Este Dia!</h3>
                    </div>
                    <br />
                    <button type="button" class="btn btn-success btn-lg" ID="btnVoltar" data-loading-text="Enviando..." >
                        <strong><span class="glyphicon glyphicon-arrow-left"></span> Retornar</strong>
                    </button>
                    
                
                </div>
                
  
            </div>


            <!-- Modal -->
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Adicionar Restaurante</h4>
                  </div>
                  <div class="modal-body">
                      <div class="form-group">
                        <label for="email">Nome Restaurante:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtRestaurante"></asp:TextBox>
                      </div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                    <button type="button" class="btn btn-primary" id="btnSalvarOpcao">Salvar</button>
                  </div>
                </div>
              </div>
            </div>

            
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#boxSemResultado").hide();
            ActiveMenu("#tab1")
            var EmailAtual = localStorage.getItem("EmailAtual");
            if (localStorage.getItem("EmailAtual") != null && localStorage.getItem("EmailAtual") != "") {
                //$('.nav-tabs a[href=""]').tab('show');
                ActiveMenu("#tab2")
            }


            $("#btnVoltar").bind("click", function () {
                //$('.nav-tabs a[href="#tab2"]').tab('show');
                ActiveMenu("#tab2")
            })


            $(".btnEnviarCadastro").bind("click", function () {
                var btn = $(this).button('loading');
                var data = { pNome: $("#txtNome").val(), pEmail: $("#txtEmail").val() }


            
                if (data.pEmail == "") {
                    alert("Prencha o Email");
                    return false;
                }

                $.ajax({
                    type: "POST",
                    url: "Default.aspx/SalvarCadastro",
                    data: JSON.stringify(data),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        console.log(result);
                        var ret = result.d;
                        console.log(ret);
                        btn.button('reset');
                        if (!ret.result) {
                            alert(ret.msg);
                        }

                        localStorage.setItem("EmailAtual", $("#txtEmail").val());
                        EmailAtual = $("#txtEmail").val();
                        //$('.nav-tabs a[href="#tab2"]').tab('show');
                        ActiveMenu("#tab2")
                    }
                });

            })


            $("#btnEnviarVoto").bind("click", function () {
                var btn = $(this).button('loading');

                if (!$("#rblDiaSemana input:checked").val()) {
                    alert("Selecione o Dia da Semana!");
                    btn.button('reset');
                    return false;
                }


                if ($("#rblDiaSemana input:checked").val() != new Date().getDay()) {

                    if ($("#rblDiaSemana input:checked").val() > new Date().getDay()) {
                        alert("Calma aí, cada dia sua votação! Escolha um restaurante para hoje!");
                    } else {
                        alert("Tarde demais, " + $("#rblDiaSemana input:checked").next().text() + " já passou!");
                    }

                    btn.button('reset');
                    return false;
                }

                if (!$("#rblRestaurante input:checked").val()) {
                    alert("Selecione o Restaurante!");
                    btn.button('reset');
                    return false;
                }

                var data = { pDiaSemana: $("#rblDiaSemana input:checked").val(), pEmail: EmailAtual, pIDRestaurante: $("#rblRestaurante input:checked").val(), }

                console.log("DATA");
                console.log(data);

                $.ajax({
                    type: "POST",
                    url: "Default.aspx/SalvarVoto",
                    data: JSON.stringify(data),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        console.log(result);
                        var ret = result.d;
                        console.log(ret);
                        btn.button('reset');
                        if (ret.result) {

                            ExibirResultado(data.pDiaSemana)
                            btn.button('reset');

                        } else {
                            alert(ret.msg);
                        }
                    }
                });

            })

            $(".btnVerResultado").bind("click", function () {
                var btn = $(this).button('loading');

                if (!$("#rblDiaSemana input:checked").val()) {
                    alert("Selecione o Dia da Semana!");
                    btn.button('reset');
                    return false;
                }

                ExibirResultado($("#rblDiaSemana input:checked").val());
                btn.button('reset');
            })
            
            $("#linkSair").bind("click", function () {
                localStorage.clear();
                ActiveMenu("#tab1");
            })



        });


        function ActiveMenu(active) {

            $('.nav-tabs a[href=' + active + ']').tab('show');
            
        }

        function ExibirResultado(pDiaSemana) {

            var data = { pDiaSemana: pDiaSemana }

            $.ajax({
                type: "POST",
                url: "Default.aspx/VerResultado",
                data: JSON.stringify(data),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    console.log(result);
                    var ret = result.d;
                    console.log(ret);
                    if (ret.result) {

                        //$('.nav-tabs a[href="#tab3"]').tab('show');
                        ActiveMenu("#tab3")

                        if (ret.msg == "") {

                            $("#boxResultado").show();
                            $("#boxSemResultado").hide();
                            console.log(ret.msg);
                            var json = JSON.parse(ret.json);
                            $("#lblRestauranteVencedor").text(json.NomeRestaurante);
                            $("#lblQtdVotos").text(json.Qtd);
                            if (new Date().getDay() == pDiaSemana) {
                                $("#lblDiaSemana").text("Hoje");
                            } else {
                                $("#lblDiaSemana").text($("#rblDiaSemana input:checked").next().text());
                            }

                        } else {
                            $("#boxResultado").hide();
                            $("#boxSemResultado").show();
                        }


                    } else {
                        alert(ret.msg);
                    }
                }
            });

        }

        

    </script>


</asp:Content>
