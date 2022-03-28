
var ObjetoVenda = new Object();

ObjetoVenda.AdicionarCarrinho = function (idProduto) {

    var nome = $("#nome_" + idProduto).val();
    var qtd = $("#qtd_" + idProduto).val();

    $.ajax({
        type: 'POST',
        url: "/api/AdicionarProdutoCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        data: {
            "id": idProduto, "nome": nome, "qtd": qtd
        },
        success: function (data) {

            if (data.sucesso) {
                // 1 alert-success// 2 alert-warning// 3 alert-danger
                ObjetoAlerta.AlertarTela(1, "Produto adicionado no carrinho!");
            }
            else {
                // 1 alert-success// 2 alert-warning// 3 alert-danger
                ObjetoAlerta.AlertarTela(2, "Necessário efetuar o login!");
            }

        }
    });


}

ObjetoVenda.CarregaProdutos = function (descricao) {

    $.ajax({
        type: 'GET',
        url: "/api/ListarProdutosComEstoque",
        dataType: "JSON",
        cache: false,
        async: true,
        data: { descricao: descricao },

        success: function (data) {

            var htmlConteudo = "";

            data.forEach(function (Entitie) {

                htmlConteudo += " <div class='col-xs-12 col-sm-4 col-md-4 col-lg-4'>";

                var idNome = "nome_" + Entitie.id;
                var idQtd = "qtd_" + Entitie.id;

                htmlConteudo += "</br><label id='" + idNome + "' > Produto: " + Entitie.nome + "</label></br>";

                if (Entitie.url != null && Entitie.url != "" && Entitie.url != undefined) {

                    htmlConteudo += "<img width='200' height='100' src='" + Entitie.url + "'/></br>";
                }

                htmlConteudo += "<label>  Valor: " + Entitie.valor + "</label></br>";

                htmlConteudo += "Quantidade : <input type'number' value='1' id='" + idQtd + "'>";

                htmlConteudo += "<input type='button' onclick='ObjetoVenda.AdicionarCarrinho(" + Entitie.id + ")' value ='Comprar'> </br> ";

                htmlConteudo += " </div>";

            });

            $("#DivVenda").html(htmlConteudo);
        }
    });

}

ObjetoVenda.CarregaQtdCarrinho = function () {

    $("#qtdCarrinho").text("(0)");

    $.ajax({
        type: 'GET',
        url: "/api/QtdProdutosCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            if (data.sucesso) {
                $("#qtdCarrinho").text("(" + data.qtd + ")");
            }

        }
    });


    setTimeout(ObjetoVenda.CarregaQtdCarrinho, 10000);
}

function CarregarMenu() {
    $.ajax({
        type: 'GET',
        url: "/api/ListarMenu",
        dataType: "JSON",
        cache: false,
        async: true,

        success: function (data) {

            data.listaMenu.forEach(function (Entitie) {

                var html = $("<li>", { class: "nav-item" });

                if (Entitie.urlImagem != undefined && Entitie.urlImagem != "") {

                    html.append("<a class='nav-link text-dark' href=/" + Entitie.controller + "/" + Entitie.action + ">" + Entitie.descricao + " <img src=" + Entitie.urlImagem + " width='20' height='20' /> <span id=" + Entitie.idCampo + "></span> </a>")
                }
                else {
                    html.append("<a class='nav-link text-dark'  href=/" + Entitie.controller + "/" + Entitie.action + ">" + Entitie.descricao + "</a>")
                }
                $("#menuSite").append(html);

            });
        }
    });
}

$(function () {

    CarregarMenu();

    ObjetoVenda.CarregaProdutos();
    ObjetoVenda.CarregaQtdCarrinho();


    $("#buscar").click(
        function () {
            var descricao = $("#descricao").val();
            ObjetoVenda.CarregaProdutos(descricao);
        }
    );

});