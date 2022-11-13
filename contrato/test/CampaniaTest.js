const DonacionesContrato = artifacts.require("DonacionesContrato");
const truffleAssert = require("truffle-assertions");

contract("DonacionesContrato", () => {
	before(async () => {
		this.donacionesContrato = await DonacionesContrato.deployed();
	});

	it("Donacion creada", async () => {
		const donacion1 = {
			idDonacion: 1,
			idOrganizacion: 1,
			organizacion: "Caritas",
			idCampania: 1,
			campania: "Navidad",
			idDonador: 1,
			productosDonados: [
				{
					descripcionProducto: "Arroz",
					cantidad: 5,
				},
			],
		};

		const donacion2 = {
			idDonacion: 2,
			idOrganizacion: 1,
			organizacion: "Caritas",
			idCampania: 1,
			campania: "Navidad",
			idDonador: 1,
			productosDonados: [
				{
					descripcionProducto: "Leche",
					cantidad: 5,
				},
			],
		};

		const donacion3 = {
			idDonacion: 3,
			idOrganizacion: 2,
			organizacion: "Cruz Roja",
			idCampania: 2,
			campania: "Campaña menos heridos",
			idDonador: 1,
			productosDonados: [
				{
					descripcionProducto: "Curitas",
					cantidad: 10,
				},
			],
		};

		const result1 = await this.donacionesContrato.crearDonacion(donacion1);
		const donacionresult1 = result1.logs[0].args.response;
		assert.notEqual(result1.receipt.transactionHash, null);
		assert.equal(donacionresult1.productosDonados.length, 1);
		assert.equal(donacionresult1.organizacion, "Caritas");
		assert.equal(donacionresult1.estado, "PROCESADO");

		const result2 = await this.donacionesContrato.crearDonacion(donacion2);
		const donacionresult2 = result2.logs[0].args.response;
		assert.notEqual(result2.receipt.transactionHash, null);
		assert.equal(
			donacionresult2.productosDonados[0].descripcionProducto,
			"Leche"
		);
		assert.equal(donacionresult2.organizacion, "Caritas");

		const result3 = await this.donacionesContrato.crearDonacion(donacion3);
		const donacionresult3 = result3.logs[0].args.response;
		assert.notEqual(result3.receipt.transactionHash, null);
		assert.equal(
			donacionresult3.productosDonados[0].descripcionProducto,
			"Curitas"
		);
		assert.notEqual(donacionresult3.organizacion, "Caritas");
		assert.equal(donacionresult3.organizacion, "Cruz Roja");
	});

	it("Consultar todas las donaciones", async () => {
		const result = await this.donacionesContrato.consultarTodasLasDonaciones();
		assert.equal(result.length, 3);
	});

	it("Consultar una donacion", async () => {
		const result = await this.donacionesContrato.consultarDonacionesPorId(1);
		assert.equal(result.productosDonados[0].descripcionProducto, "Arroz");
	});

	it("Consultar donaciones por organizacion", async () => {
		const result =
			await this.donacionesContrato.consultarDonacionesPorOrganizacion(1);
		assert.equal(result.length, 2);
	});

	it("Consultar una donación no existente", async () => {
		await truffleAssert.reverts(
			this.donacionesContrato.consultarDonacionesPorId(1000),
			"No se encontro la donacion con el id ingresado"
		);
	});

	// it('Modificar el estado de las donaciones a Reservado', () => {

	// });
});
