"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var protractor_1 = require("protractor");
var VehiclesPage = /** @class */ (function () {
    function VehiclesPage() {
    }
    VehiclesPage.prototype.navigateTo = function () {
        return protractor_1.browser.get('/');
    };
    VehiclesPage.prototype.getVehiclesStatus = function () {
        return protractor_1.element.all(protractor_1.by.css('.alert'));
    };
    VehiclesPage.prototype.changeStatus = function () {
        return protractor_1.element(protractor_1.by.id('rpConnected')).click();
    };
    VehiclesPage.prototype.checkIfThereIsInvalidStatus = function () {
        return protractor_1.element.all(protractor_1.by.css('.alert alert-danger'));
    };
    return VehiclesPage;
}());
exports.VehiclesPage = VehiclesPage;
//# sourceMappingURL=vehicle.po.js.map