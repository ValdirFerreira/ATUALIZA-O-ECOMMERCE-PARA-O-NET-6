var cuboDashbord = new Object();

cuboDashbord.corItem =
{
    grey: 0,
    white: 1,
    red: 2,
    purble: 3
};

cuboDashbord.CriaItem = function (idDiv, titulo, corItem, conteudo = "") {

    var _titulo = "Sem titulo";

    if (titulo == null || titulo == "" || titulo == undefined) {
        titulo = _titulo;
    }
    var cores = cuboDashbord.ObterCoresItem(corItem);

    var divTopo = $('<div>');
    divTopo.addClass('ItemTop');
    divTopo.css('color', cores.corTitulo);

    var divCabecalho = $('<div>');
    divCabecalho.addClass('itemCabecalho');

    var divTitulo = $('<div>');
    divTitulo.text(titulo);
    divTitulo.addClass('itemTitulo');

    var divControles = $('<div>');
    divControles.addClass('itemControle');

    cuboDashbord.ConfigurarBotoes(idDiv, divControles);

    var divConteudo = $('<div>');
    divConteudo.addClass('itemConteudo');
    divConteudo.attr('id', idDiv + 'Conteudo');
    divConteudo.css('overflow', 'auto');

    $('#' + idDiv).html('');
    $('#' + idDiv).append(divTopo);
    divTopo.append(divCabecalho);
    divCabecalho.append(divTitulo);
    divTitulo.append(divControles);

    divConteudo.css('height', '180px');
    divConteudo.append(conteudo);
    divTopo.append(divConteudo);

    $('#' + idDiv).css('background-color', cores.corFundo);
    $('#' + idDiv).addClass('efeitoDiv');

}

cuboDashbord.ObterCoresItem = function (corItem) {
    var retorno = { corFundo: 'grey', corTexto: 'white', corTitulo: 'white' };

    switch (corItem) {

        case cuboDashbord.corItem.grey:
            retorno.corFundo = 'rgb(105,105,105)';
            retorno.corTexto = 'white';
            retorno.corTitulo = 'white';
            break;

        case cuboDashbord.corItem.white:
            retorno.corFundo = 'rgb(248, 248, 255)';
            retorno.corTexto = 'black';
            retorno.corTitulo = 'black';
            break;

        case cuboDashbord.corItem.red:
            retorno.corFundo = 'rgb(255,0,0)';
            retorno.corTexto = 'black';
            retorno.corTitulo = 'black';
            break;

        case cuboDashbord.corItem.purble:
            retorno.corFundo = 'rgb(128,0,128)';
            retorno.corTexto = 'black';
            retorno.corTitulo = 'black';
            break;
    }

    return retorno;
}

cuboDashbord.ConfigurarBotoes = function (idDiv, divControles) {

    var btnMinimizar = cuboDashbord.CriarBotoes(idDiv, divControles, '../img/minimizar.png', 'MinMax', 'itemBotaoMax');
    btnMinimizar.click(function () {
        cuboDashbord.ModoBotao(idDiv, this);
    });

    var btnFechar = cuboDashbord.CriarBotoes(idDiv, divControles, '../img/fechar.png', 'fechar');

    btnFechar.click(function () {
        $("#" + idDiv).hide('slow', function () {
            var divCubo = $(this).parent();
            divCubo.remove()
        })
    });

}

cuboDashbord.ModoBotao = function (idDiv, botao) {

    var classeNome = $('#' + botao.id).attr('class');

    if (classeNome == 'itemBotaoMax') {
        $('#' + idDiv + "Conteudo").hide('slow', function () {
            $('#' + botao.id).attr('src', '../img/maximizar.png');
        });

        $('#' + botao.id).removeClass('itemBotaoMax');
        $('#' + botao.id).addClass('itemBotao');

    }

    if (classeNome == 'itemBotao') {
        $('#' + idDiv + "Conteudo").animate({ height: '180px' }, 500, 'swing', function () {
            $('#' + idDiv + "Conteudo").show('slow');
            $('#' + botao.id).attr('src', '../img/minimizar.png');
            $('#' + botao.id).attr('minimizado', 'false');
        });

        $('#' + botao.id).addClass('itemBotaoMax');
        $('#' + botao.id).removeClass('itemBotao');

    }


}

cuboDashbord.CriarBotoes = function (idDiv, divControles, img, sufixo, classe = "") {

    var novoBotao = $('<img>');
    var idBotao = 'Botao' + idDiv + sufixo;
    novoBotao.attr('id', idBotao);

    var classeBotao = "itemBotao";

    if (classe != "") {
        classeBotao = classe;
    }

    novoBotao.addClass(classeBotao);
    novoBotao.attr('divContainer', idDiv);
    novoBotao.attr('src', img);

    divControles.append(novoBotao);

    return novoBotao;
}


