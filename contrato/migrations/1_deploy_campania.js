const DonacionesContrato = artifacts.require("DonacionesContrato");

module.exports = function (deployer) {
	deployer.deploy(DonacionesContrato);
};
