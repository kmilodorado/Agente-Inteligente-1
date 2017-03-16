var xhr;

function CreateXmlHttp() {
    // Probamos con IE
    try {        // Funcionará para JavaScript 5.0
        xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch (e) {
        try {
            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (oc) {
            xmlHttp = null;
        }
    }
    // Si no se trataba de un IE, probamos con esto
    if (!xmlHttp && typeof XMLHttpRequest != "undefined") {
        xmlHttp = new XMLHttpRequest();
    }

    return xmlHttp;
}



//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Esc() {
    xh = CreateXmlHttp();
    xh.open("GET", "../ActualizarEscenario.aspx", true);//ultimo parametro true asincrono false sincrono
    xh.onreadystatechange = ESC; //despue del = nombre de la funcion que controla la respuesta
    xh.send(null);//post sen el elemento que contiene la informacion
}

function ESC() {
    if (xh.readyState == 4) {
        document.getElementById("Tabl").innerHTML = xh.responseText;
    }
}

function Res() {
    return axios.get("../RestablecerSistema.aspx")
}

function Lim() {
   return axios.get("../LimpiarOstaculos.aspx")
}


function Ost() {
    // Make a request for a user with a given ID
    return axios.get("../GenerarOstaculos.aspx");
}

function Age() {
    xh = CreateXmlHttp();
    xh.open("GET", "../UbicacionAgente.aspx", true);//ultimo parametro true asincrono false sincrono
    xh.onreadystatechange = AGE; //despue del = nombre de la funcion que controla la respuesta
    xh.send(null);//post sen el elemento que contiene la informacion
}

function AGE() {
    if (xh.readyState == 4) {
    }
}