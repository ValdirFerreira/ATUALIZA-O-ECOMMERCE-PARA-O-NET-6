var objetoDivItemDashBoard = new Object();

objetoDivItemDashBoard.contator = 0;

objetoDivItemDashBoard.CarregaItem = function () {

    cuboDashbord.CriaItem('divitemDashBord1', 'Meu Teste1', cuboDashbord.corItem.purble);
    $("#divitemDashBord1Conteudo").html(objetoDivItemDashBoard.CriartabelaPesquisa());
    objetoDivItemDashBoard.AtualizaConteudo();
}


objetoDivItemDashBoard.CriartabelaPesquisa = function () {

    var div = $('<div>');
    var span = $('<span>');
    span.text("Pesquisa: ");

    var input = $('<input>', { id: "txtPesquisa" });
    input.keyup(function () {
        objetoDivItemDashBoard.Pesquisa();
    });

    div.append(span);
    div.append(input);

    var tabela = $('<table>', { id: "tabela1", class: "table table-striped table-bordered" });
    var tr = $('<tr>');
    tr.append("<th>Nome</th>")
    tr.append("<th>Valor</th>")
    tabela.append(tr);

    var stringUrl = "/api/ListarProdutosVendidos";

    $.ajax({
        type: "GET",
        url: stringUrl,
        dataType: "JSON",
        success: function (data) {

            data.forEach(function (entidade) {
                var row = $('<tr>');
                row.append("<th>" + entidade.nome + "</th>");
                row.append("<th>" + entidade.valor + "</th>");
                tabela.append(row);
            });
        }
    });

    div.append("<div></br></div>");
    div.append(tabela);

    return div;

}

objetoDivItemDashBoard.Pesquisa = function () {

    var tabela = $("#tabela1");

    var tr = $('<tr>');
    tr.append("<th>Nome</th>")
    tr.append("<th>Valor</th>")
    tabela.html(tr);

    var stringUrl = "/api/ListarProdutosVendidos";

    var filtro = $("#txtPesquisa").val();

    $.ajax({
        type: "GET",
        url: stringUrl,
        dataType: "JSON",
        data: { filtro: filtro },
        success: function (data) {

            data.forEach(function (entidade) {
                var row = $('<tr>');
                row.append("<th>" + entidade.nome + "</th>");
                row.append("<th>" + entidade.valor + "</th>");
                tabela.append(row);
            });
        }
    });

}

objetoDivItemDashBoard.CriarDiv = function (numeroDiv) {

    var div = $('<div>');
    var span = $('<span>');
    span.text("Teste meu teste Conteudo div " + numeroDiv + " - " + objetoDivItemDashBoard.contator);
    div.append(span);

    div.css('width', '290px');
    div.css('height', '180px');
    div.css('background-color', 'green');
    div.css('border-radius', '7px');

    return div;
}

objetoDivItemDashBoard.AtualizaConteudo = function () {
    setTimeout(objetoDivItemDashBoard.AtualizaConteudo, 3000);
    objetoDivItemDashBoard.contator++;
}




$(function () {
    objetoDivItemDashBoard.CarregaItem();
});