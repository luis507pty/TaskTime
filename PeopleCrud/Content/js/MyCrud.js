
async function MyAjaxPostAsync(_url, element, datos) {
    let retunrRespuesta;
    await $.ajax(_url,
        {
            data: datos,
            async: true,
            method: "POST",
            type: "json",
            beforeSend: function () {
                //    if (element != "") document.getElementById(element).innerHTML = cargando;
            },
            success: function (respuesta) {
                if (respuesta.IsDone) notificacion(respuesta.mensaje)
                else notificacionError(respuesta.mensaje)
                retunrRespuesta = respuesta
            }, error: () => { notificacionError("Error de consulta") }
        })

    return retunrRespuesta
}

function MyAjaxHtml(_url, element, metodo, datos) {

    $.ajax({
        url: _url, method: metodo, data: datos, success: (respuesta) => {
            $("#" + element).html(respuesta);
        }
    })
}

function notificacionError(Mensaje) {
    alertify.error(Mensaje);
}

function notificacion(Mensaje) {
    alertify.success(Mensaje);
}

function CallTab() {
    MyAjaxHtml("/Task/ViewTab", "tab-contend", "GET", null)
}  

async function Delete(Id) {

    let token = document.getElementById('delete-token').firstChild; token = token.value;
    var data = { id:Id, __RequestVerificationToken: token }

    var respuesta = await MyAjaxPostAsync("/Task/Delete", "", data)
    if (respuesta.IsDone) { MyAjaxHtml("/Task/ViewCreateForm", "div-form", "GET", null); CallTab() }
    else { }
}

//Funcion para crear un registro
async function Create() {
    var data = GetInputData()
    var respuesta = await MyAjaxPostAsync("/Task/Create", "", data)
    if (respuesta.IsDone) {
        MyAjaxHtml("/Task/ViewCreateForm", "div-form", "GET", null);
        CallTab(); 
        window.location.hash = "#4"
        window.location.hash = "#tab-contend";
    }
    else { MyAjaxHtml("/Task/FailViewCreate", "div-form", "GET", data) }
} 
//Funcion para actualizar un registro
async function Update() {
    var data = GetInputData()
    var respuesta = await MyAjaxPostAsync("/Task/Update", "", data)
    if (respuesta.IsDone) {

        MyAjaxHtml("/Task/ViewCreateForm", "div-form", "GET", null);
        CallTab();

        window.location.hash = "#4"
        window.location.hash = "#tab-contend";
 }
    else { MyAjaxHtml("/Task/FailViewUpdate", "div-form", "GET", data) }
}  

function formfocus() { 
    window.location.hash = "#4"
    window.location.hash = "#" 
}

//Obtengo los tados del formulario
function GetInputData() {
    let id = $("#Id").val()
    let nombre = $("#Nombre").val()
    let descripcion = $("#Descripcion").val()
    let token = document.getElementById('token').firstChild; token = token.value;
    let data = { Id: id, Nombre: nombre, Descripcion: descripcion, __RequestVerificationToken: token }
    return data;
}

