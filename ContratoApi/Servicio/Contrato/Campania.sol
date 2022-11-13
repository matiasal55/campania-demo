// SPDX-License-Identifier: MIT
pragma solidity >=0.5.0 <0.9.0;

contract Campania {
    struct DonacionRequest {
        uint idDonacion;
        uint idOrganizacion;
        string organizacion;
        uint idCampania;
        string campania;
        uint idDonador;
        string descripcionProducto;
        uint cantidad;
    }

    struct Donacion {
        uint idDonacion;
        uint idOrganizacion;
        string organizacion;
        uint idCampania;
        string campania;
        uint idDonador;
        string descripcionProducto;
        uint cantidad;
        uint timestamp;
        bool entregado;
    }

    struct DonacionResponse {
        uint idDonacion;
        string organizacion;
        string campania;
        string descripcionProducto;
        uint cantidad;
        uint timestamp;
        bool entregado;
    }

    Donacion[] private donaciones;
    address private owner;

    constructor(){
        owner = msg.sender;
    }

    event datosDonacion (
        DonacionResponse response
    );

    modifier chequearModificador() {
        require(owner == msg.sender, "No esta autorizado a modificar los datos dentro del contrato");
        _;
    }

    function crearResponse(Donacion memory donacion) private pure returns (DonacionResponse memory response) {
        response = DonacionResponse(donacion.idDonacion, donacion.organizacion, donacion.campania, donacion.descripcionProducto, donacion.cantidad, donacion.timestamp, donacion.entregado);
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
        Donacion memory nuevaDonacion = Donacion(request.idDonacion, request.idOrganizacion, request.organizacion, request.idCampania, request.campania, request.idDonador, request.descripcionProducto, request.cantidad, timestamp, false);
        donaciones.push(nuevaDonacion);
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
}