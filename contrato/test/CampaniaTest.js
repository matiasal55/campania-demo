const Campania = artifacts.require("Campania");
const truffleAssert = require("truffle-assertions");

contract("Campania", () => {
	before(async () => {
		this.campania = await Campania.deployed();
	});

	it("Donacion creada", async () => {
		const donacion1 = {
			idDonacion: 1,
			idOrganizacion: 1,
			organizacion: "Caritas",
			idCampania: 1,
			campania: "Navidad",
			idDonador: 1,
			descripcionProducto: "Arroz",
			cantidad: 5,
		};

		const donacion2 = {
			idDonacion: 2,
			idOrganizacion: 1,
			organizacion: "Caritas",
			idCampania: 1,
			campania: "Navidad",
			idDonador: 1,
			descripcionProducto: "Leche",
			cantidad: 5,
		};

		const donacion3 = {
			idDonacion: 3,
			idOrganizacion: 2,
			organizacion: "Cruz Roja",
			idCampania: 2,
			campania: "Campaña menos heridos",
			idDonador: 1,
			descripcionProducto: "Curitas",
			cantidad: 10,
		};

		const result1 = await this.campania.crearDonacion(donacion1);
		const donacionresult1 = result1.logs[0].args.response;
		assert.notEqual(result1.receipt.transactionHash, null);
		assert.equal(donacionresult1.descripcionProducto, "Arroz");
		assert.equal(donacionresult1.organizacion, "Caritas");

		const result2 = await this.campania.crearDonacion(donacion2);
		const donacionresult2 = result2.logs[0].args.response;
		assert.notEqual(result2.receipt.transactionHash, null);
		assert.equal(donacionresult2.descripcionProducto, "Leche");
		assert.equal(donacionresult2.organizacion, "Caritas");

		const result3 = await this.campania.crearDonacion(donacion3);
		const donacionresult3 = result3.logs[0].args.response;
		assert.notEqual(result3.receipt.transactionHash, null);
		assert.equal(donacionresult3.descripcionProducto, "Curitas");
		assert.notEqual(donacionresult3.organizacion, "Caritas");
		assert.equal(donacionresult3.organizacion, "Cruz Roja");
	});

	it("Consultar todas las donaciones", async () => {
		const result = await this.campania.consultarTodasLasDonaciones();
		assert.equal(result.length, 3);
	});

	it("Consultar una donacion", async () => {
		const result = await this.campania.consultarDonacionesPorId(1);
		assert.equal(result.descripcionProducto, "Arroz");
	});

	it("Consultar donaciones por organizacion", async () => {
		const result = await this.campania.consultarDonacionesPorOrganizacion(1);
		assert.equal(result.length, 2);
	});

	it("Consultar una donación no existente", async () => {
		await truffleAssert.reverts(
			this.campania.consultarDonacionesPorId(1000),
			"No se encontro la donacion con el id ingresado"
		);
	});
});
