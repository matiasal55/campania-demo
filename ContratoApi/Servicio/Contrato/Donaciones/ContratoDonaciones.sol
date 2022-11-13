// SPDX-License-Identifier: MIT
pragma solidity >=0.5.0 <0.9.0;

contract DonacionesContrato {

    struct ProductoDonado {
        string descripcionProducto;
        uint cantidad;
    }

    enum EstadoDonacion {
        PROCESADO,
        RESERVADO,
        TRASLADO,
        ENTREGADO
    }
    
    struct DonacionRequest {
        uint idDonacion;
        uint idOrganizacion;
        string organizacion;
        uint idCampania;
        string campania;
        uint idDonador;
        ProductoDonado[] productosDonados;
    }

    struct Donacion {
        uint idDonacion;
        uint idOrganizacion;
        string organizacion;
        uint idCampania;
        string campania;
        uint idDonador;
        ProductoDonado[] productosDonados;
        uint timestamp;
        EstadoDonacion estado;
    }

    struct DonacionResponse {
        uint idDonacion;
        string organizacion;
        string campania;
        ProductoDonado[] productosDonados;
        uint timestamp;
        string estado;
    }

    struct DonacionConIndex {
        Donacion donacion;
        uint index;
    }

    struct DonacionHistorico {
        uint idDonacion;
        EstadoDonacion estado;
        uint timestamp;
    }

    event datosDonacion (
        DonacionResponse response
    );

    modifier chequearModificador() {
        require(owner == msg.sender, "No esta autorizado a modificar los datos dentro del contrato");
        _;
    }

    Donacion[] private donaciones;
    DonacionHistorico[] private donacionesHistorico;
    address private owner;
    mapping (EstadoDonacion => string) estados;

    constructor(){
        owner = msg.sender;
        estados[EstadoDonacion.PROCESADO] = "PROCESADO";
        estados[EstadoDonacion.RESERVADO] = "RESERVADO";
        estados[EstadoDonacion.TRASLADO] = "TRASLADO";
        estados[EstadoDonacion.ENTREGADO] = "ENTREGADO";
    }

    function crearResponse(Donacion memory donacion) private view returns (DonacionResponse memory response) {
        response = DonacionResponse(donacion.idDonacion, donacion.organizacion, donacion.campania, donacion.productosDonados, donacion.timestamp, estados[donacion.estado]);
    }

    function chequearExistencia(DonacionRequest memory donacion) private view {
        for (uint256 i = 0; i < donaciones.length; i++) {
            if(donaciones[i].idDonacion == donacion.idDonacion){
                revert("Ya existe una donacion con el id asignado");
            }
        }
    }

    function crearDonacion(DonacionRequest memory request) public chequearModificador {
        chequearExistencia(request);
        uint timestamp = block.timestamp;
        Donacion storage nuevaDonacion = donaciones.push();
        DonacionHistorico storage nuevaDonacionHistorico = donacionesHistorico.push();

        nuevaDonacion.idDonacion = request.idDonacion;
        nuevaDonacion.idOrganizacion = request.idOrganizacion;
        nuevaDonacion.organizacion = request.organizacion;
        nuevaDonacion.idCampania = request.idCampania;
        nuevaDonacion.campania = request.campania;
        nuevaDonacion.idDonador = request.idDonador;
        nuevaDonacion.timestamp = timestamp;
        nuevaDonacion.estado = EstadoDonacion.PROCESADO;

        nuevaDonacionHistorico.idDonacion = request.idDonacion;
        nuevaDonacionHistorico.estado = EstadoDonacion.PROCESADO;
        nuevaDonacionHistorico.timestamp = timestamp;

        for (uint256 i = 0; i < request.productosDonados.length; i++) {
            nuevaDonacion.productosDonados.push(request.productosDonados[i]);
        }

        DonacionResponse memory response = crearResponse(nuevaDonacion);
        emit datosDonacion(response);
    }

    function consultarTodasLasDonaciones() public view returns (DonacionResponse[] memory){
        DonacionResponse[] memory lista = new DonacionResponse[](donaciones.length);
        for (uint256 i = 0; i < donaciones.length; i++) {
            lista[i] = crearResponse(donaciones[i]);
        }
        return lista;
    }

    function consultarHistorialDonaciones() public view returns (DonacionHistorico[] memory){
        DonacionHistorico[] memory lista = new DonacionHistorico[](donacionesHistorico.length);
        for (uint256 i = 0; i < donacionesHistorico.length; i++) {
            lista[i] = donacionesHistorico[i];
        }
        return lista;
    }

    function consultarDonacionesPorId(uint idDonacion) public view returns (DonacionResponse memory){
        for (uint256 i = 0; i < donaciones.length; i++) {
            if(donaciones[i].idDonacion == idDonacion){
                return crearResponse(donaciones[i]);
            }
        }

        revert("No se encontro la donacion con el id ingresado");
    }


    function consultarDonacionesPorOrganizacion(uint idOrganizacion) public view returns (DonacionResponse[] memory) {
        Donacion[] memory listaFiltrada = new Donacion[](donaciones.length);
        uint contador = 0;
        for (uint256 i = 0; i < donaciones.length; i++) {
            Donacion memory request = donaciones[i];
            if(request.idOrganizacion == idOrganizacion){
                listaFiltrada[contador] = donaciones[i];
                contador++;
            }
        }

        DonacionResponse[] memory lista = new DonacionResponse[](contador);

        for (uint256 i = 0; i < contador; i++) {
            lista[i] = crearResponse(listaFiltrada[i]);
        }

        return lista;
    }

    function traerDatosDeDonacion(uint idDonacion) private view returns (DonacionConIndex memory){
        for (uint256 i = 0; i < donaciones.length; i++) {
            if(donaciones[i].idDonacion == idDonacion){
                return DonacionConIndex(donaciones[i], i);
            }
        }

        revert("No se encontro la donacion con el id ingresado");
    }

    function cambiarEstadoDeDonaciones(uint[] memory donacionesId, EstadoDonacion estado) private {
        DonacionConIndex[] memory listaDonaciones = new DonacionConIndex[](donaciones.length);
        uint contador = 0;
        uint timestamp = block.timestamp;

        for (uint256 i = 0; i < donacionesId.length; i++) {
            DonacionConIndex memory datos = traerDatosDeDonacion(donacionesId[i]);
            if(uint8(datos.donacion.estado) == uint8(estado)){
                revert(string(bytes.concat(bytes("Una de las donaciones ya se encuentra con estado "), bytes(estados[estado]))));
            }
            if(uint8(datos.donacion.estado) + 1 != uint8(estado)){
                revert("El estado a cambiar no corresponde con el ingresado");
            }
            datos.donacion.estado = estado;
            datos.donacion.timestamp = timestamp;
            listaDonaciones[contador] = datos;
            contador++;
        }

        for (uint256 i = 0; i < contador; i++) {
            donaciones[listaDonaciones[i].index].estado = estado;
            DonacionHistorico storage nuevoHistorico = donacionesHistorico.push();
            nuevoHistorico.idDonacion = listaDonaciones[i].donacion.idDonacion;
            nuevoHistorico.estado = estado;
            nuevoHistorico.timestamp = timestamp;
        }
    }

    function confirmarReservaProductosEnDonaciones(uint[] memory donacionesId) public {
        cambiarEstadoDeDonaciones(donacionesId, EstadoDonacion.RESERVADO);
    }

    function confirmarTrasladoProductosEnDonaciones(uint[] memory donacionesId) public {
        cambiarEstadoDeDonaciones(donacionesId, EstadoDonacion.TRASLADO);
    }

    function confirmarEntregaProductosEnDonaciones(uint[] memory donacionesId) public {
        cambiarEstadoDeDonaciones(donacionesId, EstadoDonacion.ENTREGADO);
    }
}