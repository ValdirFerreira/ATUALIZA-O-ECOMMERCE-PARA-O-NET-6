var objetoJson = {};

var jsonView = new JSONViewer();


function ConfiguraJson() {

    var json = $("#JsonInformacao").val();

    if (json != undefined && json != null && json != "") {

        objetoJson = JSON.parse(json);

        jsonView.showJSON(objetoJson);

        document.querySelector("#json").appendChild(jsonView.getContainer());
    }
}


$(function () {
    ConfiguraJson();
});