
document.addEventListener("DOMContentLoaded", () => {

    let url = location.href;

    mostrarHora();
    setInterval(mostrarHora, 1000);
    migaPan();    

    if (location.href.includes('Home')) {
        consoleText(['Hola Administrador', 'Éste es su panel principal', 'Aquí podra gestionar y crear publicaciones para sus clientes'], 'text', ['white', 'white', 'white']);
    }

    if (url.includes("Home")) {
        fadeVentana();
        watchInputs();
        resaltarCabecera();
    }

    if (url.includes("Usuarios")) {
        usuariosActuales();
        borrarDuplicados();
    }

    if (url.includes("Roles")) {
        mostrarModal();
        rolesActivos();
    }

})

function mostrarHora() {

    let element = document.getElementById("hora");
    let date = new Date();
    let horas = date.getHours();
    let minutos = date.getMinutes();
    let segundos = date.getSeconds();
    let dia = date.getDay();
    let diaMes = date.getDate();
    let mes = date.getMonth();
    let horaMostrar = "";

    switch (dia) {
        case 1:
            dia = "Lunes";
            break;
        case 2:
            dia = "Martes";
            break;
        case 3:
            dia = "Miércoles";
            break;
        case 4:
            dia = "Jueves";
            break;
        case 5:
            dia = "Viernes";
            break;
        case 6:
            dia = "Sábado";
            break;
        case 7:
            dia = "Domingo";
            break;
    }

    switch (mes + 1) {
        case 1:
            mes = "Enero";
            break;
        case 2:
            mes = "Febrero";
            break;
        case 3:
            mes = "Marzo";
            break;
        case 4:
            mes = "Abril";
            break;
        case 5:
            mes = "Mayo";
            break;
        case 6:
            mes = "Junio";
            break;
        case 7:
            mes = "Julio";
            break;
        case 7:
            mes = "Agosto";
            break;
        case 7:
            mes = "Septiembre";
            break;
        case 7:
            mes = "Octubre";
            break;
        case 7:
            mes = "Noviembre";
            break;
        case 7:
            mes = "Diciembre";
            break;
    }

    if (horas < 10) {
        horas = "0" + horas;
    }
    if (minutos < 10) {
        minutos = "0" + minutos;
    }
    if (segundos < 10) {
        segundos = "0" + segundos;
    }

    

    horaMostrar = `${dia} <span class="text-warning">${diaMes}</span> ${mes} - ${horas}:${minutos}:${segundos}`;
    element.innerHTML = horaMostrar;
}

function rotateImg1() {

    let imagenFooter1 = document.getElementById("imgFooter1");
    imagenFooter1.classList.add("imgFooter1");
}

function quitRotate1() {
    let imagenFooter1 = document.getElementById("imgFooter1");
    imagenFooter1.classList.remove("imgFooter1");
}

function rotateImg2() {

    let imagenFooter1 = document.getElementById("imgFooter2");
    imagenFooter1.classList.add("imgFooter2");
}

function quitRotate2() {
    let imagenFooter1 = document.getElementById("imgFooter2");
    imagenFooter1.classList.remove("imgFooter2");
}

function rotateImg3() {

    let imagenFooter1 = document.getElementById("imgFooter3");
    imagenFooter1.classList.add("imgFooter3");
}

function quitRotate3() {
    let imagenFooter1 = document.getElementById("imgFooter3");
    imagenFooter1.classList.remove("imgFooter3");
}


function consoleText(words, id, colors) {
    if (colors === undefined) colors = ['#fff'];
    var letterCount = 1;
    var x = 1;
    var waiting = false;
    var target = document.getElementById(id)
    target.setAttribute('style', 'color:' + colors[0])
    window.setInterval(function () {

        if (letterCount === 0 && waiting === false) {
            waiting = true;
            target.innerHTML = words[0].substring(0, letterCount)
            window.setTimeout(function () {
                var usedColor = colors.shift();
                colors.push(usedColor);
                var usedWord = words.shift();
                words.push(usedWord);
                x = 1;
                target.setAttribute('style', 'color:' + colors[0])
                letterCount += x;
                waiting = false;
            }, 1000)
        } else if (letterCount === words[0].length + 1 && waiting === false) {
            waiting = true;
            window.setTimeout(function () {
                x = -1;
                letterCount += x;
                waiting = false;
            }, 1000)
        } else if (waiting === false) {
            target.innerHTML = words[0].substring(0, letterCount)
            letterCount += x;
        }
    }, 70)

}

function fadeVentana() {
    let body = document.getElementsByTagName("body")[0];
    let botonIniciarSesión = document.getElementById("iniciarSesion");
    let bodyFormularioLogin = document.getElementById("formularioLogin");
    let formularioLogin = document.getElementById("formLogin");
    let dashboard = document.getElementById("dashboard");

    window.addEventListener("load", () => {
        dashboard.classList.remove("oculto");
        dashboard.classList.add("visible");
    })
}

function migaPan() {

    let menu = document.getElementById("menu");
    let opcionMenu = document.getElementsByClassName("menuLink");

    let url = location.href;
    let urlsbstr = url.substring(23, url.length);
    let urlmodif = urlsbstr.replaceAll('/', ' > ');

    document.getElementById("migaPan").innerHTML = urlmodif;

    if (urlsbstr.includes("Home")) {
        for (elementValue of opcionMenu) {
            if (elementValue.innerHTML == "Dashboard") {
                elementValue.classList.add("colorOpcionMenuMigaPan");
            }
        }
    } else if (urlsbstr.includes("Roles")) {
        for (elementValue of opcionMenu) {
            if (elementValue.innerHTML == "Roles") {
                elementValue.classList.add("colorOpcionMenuMigaPan");
            }
        }
    } else if (urlsbstr.includes("Usuarios")) {
        for (elementValue of opcionMenu) {
            if (elementValue.innerHTML == "Usuarios") {
                elementValue.classList.add("colorOpcionMenuMigaPan");
            }
        }
    } else if (urlsbstr.includes("Archivos")) {
        for (elementValue of opcionMenu) {
            if (elementValue.innerHTML == "Archivos Validados") {
                elementValue.classList.add("colorOpcionMenuMigaPan");
            }
        }
    }
}

function watchInputs() {

    let campoTitulo = document.getElementById("inputSearchTitle");
    let campoContenido = document.getElementById("inputSearchContent");
    let campoFecha = document.getElementById("inputSearchDate");

    campoTitulo.addEventListener("focus", () => {
        campoTitulo.style.backgroundColor = "#EEF7FF";
    })
    campoTitulo.addEventListener("blur", () => {
        campoTitulo.style.backgroundColor = "white";
    })

    campoContenido.addEventListener("focus", () => {
        campoContenido.style.backgroundColor = "#EEF7FF";
    })
    campoContenido.addEventListener("blur", () => {
        campoContenido.style.backgroundColor = "white";
    })

    campoFecha.addEventListener("focus", () => {
        campoFecha.style.backgroundColor = "#EEF7FF";
    })
    campoFecha.addEventListener("blur", () => {
        campoFecha.style.backgroundColor = "white";
    })
}


function resaltarCabecera() {

    let infoCabecera = document.getElementById("infoCabecera");

    window.addEventListener("scroll", () => {

        if (window.scrollY >= 400) {
            infoCabecera.style.backgroundColor = "#61A3BA";
            infoCabecera.style.textTransform = "uppercase";

        } else {
            infoCabecera.style.backgroundColor = "#6B8A7A";
            infoCabecera.style.textTransform = "capitalize";
        }

    })
}

function rutasAbsolutas() {

    let pathCreate = document.getElementById("ruta");
    let pathEdit = document.getElementById("rutaEditar");

    document.getElementById("rutaValorCrear").setAttribute("value", pathCreate.value);
    document.getElementById("rutaValorEditar").setAttribute("value", pathEdit.value);
    
}

function usuariosActuales() {

    let contadorTotal = 0;
    let arrayUsuarios = [];
    let objUsu = {};
    let usuarios = document.getElementsByClassName("usuariosActuales");

    for (let usu of usuarios) {
        arrayUsuarios.push(usu.innerHTML.trim());
        contadorTotal++;
    }

    for (const nombre of arrayUsuarios) {
        if (objUsu[nombre]) {
            objUsu[nombre]++; // Si ya existe, incrementa la ocurrencia
        } else {
            objUsu[nombre] = 1; // Si no existe, inicializa la ocurrencia
        }
    }

    for (let usu in objUsu) {
        let element = document.createElement("div");
        element.className = "child"
        element.innerHTML = `${usu}: ${objUsu[usu]}`
        document.getElementById("usuariosActivos").appendChild(element);
    }    
    
    document.getElementById("totUsu").innerHTML = contadorTotal;
}

function borrarDuplicados() {

    var children = document.querySelectorAll(".child");
    var tmpTexts = [];
    let usuarios = "";
    let element = document.getElementById("usuariosActivos");

    for (const c of children) {
        if (tmpTexts.includes(c.innerText)) continue
        tmpTexts.push(c.innerText)
        c.parentNode.removeChild(c)
    }

    for (let i = 0; i < tmpTexts.length; i++) {
        if (i == (tmpTexts.length - 1)) {
            usuarios += `<span style="font-weight:bold; font-family:arial; font-style:italic">${tmpTexts[i]}</span>`;
            break;
        }
        usuarios += `<span style="font-weight:bold; font-family:arial; font-style:italic">${tmpTexts[i]}</span> | `
    }
    element.innerHTML = usuarios;
}

function rolesActivos() {   

    let roles = document.getElementsByClassName("rolesActuales");
    let contador = 0;
    let rolesExistentes = "";

    for (let rol of roles) {
        contador++;
        rolesExistentes += `<span style="font-weight:bold; font-family:arial; font-style:italic">${rol.innerHTML}</span> | `
    }

    document.getElementById("totRol").innerHTML = contador;
    document.getElementById("nombresRoles").innerHTML = rolesExistentes

}

function mostrarModal() {
    $(document).ready(function () {
        $('#infoModal').modal('show');
    });
}


