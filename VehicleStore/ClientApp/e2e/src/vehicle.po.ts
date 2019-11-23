import { browser, element, by, Key } from 'protractor';

export class VehiclesPage {
    navigateTo() {
        return browser.get('/');
    }

    getVehiclesStatus() {
        return element.all(by.css('.alert'));
    } 

    changeStatus() {
        return element(by.id('rpConnected')).click();
    }

    checkIfThereIsInvalidStatus() {
        return element.all(by.css('.alert alert-danger'));
    }
}
