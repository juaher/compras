﻿var selectVendedor = $('[name ="selectvendedor"]');
var selectCliente = $('[name ="selectcliente"]');
var selectArticulo = $('[name ="selectarticulo"]');
var inputNumero = $('[name ="inputnumero"]');
var inputCantidad = $('[name ="inputcantidad"]');
var inputValor = $('[name ="inputvalor"]');

var tbodyArticulo = $('[name ="tbodyarticulo"]');
var btnAgregar = $('[name ="btnagregar"]');



var articulos = new Array();

var clear = function () {
    selectArticulo.val("");
    inputNumero.val(0);
    inputCantidad.val(0);
    inputValor.val(0);
};

clear();

var generarTabla = function () {
    tbodyArticulo.html("");
    var text = "";
    for (i = 0; i < articulos.length; i++) {
        text += "<tr>";
        text += "<td>" + articulos[i].idArticulo + "</td>";
        text += "<td>" + articulos[i].numero + "</td>";
        text += "<td>" + articulos[i].cantidad + "</td>";
        text += "<td>" + articulos[i].valor + "</td>";
        text += "</tr>";
    }

    tbodyArticulo.html(text);
}

var agregarArticulo = function () {
    var idArticulo = selectArticulo.val();
    var numero = inputNumero.val();
    var cantidad = inputCantidad.val();
    var valor = inputValor.val();
    var articulo = new Object();
    articulo.idArticulo = idArticulo;
    articulo.numero = numero;
    articulo.cantidad = cantidad;
    articulo.valor = valor;
    articulo.articulo = articulo;
    articulos.push(articulo);
    generarTabla();
    clear();
}

var funcCancelar = function () {
    articulos = new Object();
    clear();
};

var funcAceptar = function () {
    
};

btnAgregar.on("click", agregarArticulo);

btnCancelar.on("click", funcCancelar);

btnAceptar.on("click", funcAceptar);