const Campania = artifacts.require("Campania");

module.exports = function (deployer) {
	deployer.deploy(Campania);
};
