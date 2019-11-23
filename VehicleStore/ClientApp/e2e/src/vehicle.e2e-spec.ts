import { VehiclesPage } from './vehicle.po';
import { browser } from 'protractor';


describe('App', () => {
    let page: VehiclesPage;

    beforeEach(() => {
        page = new VehiclesPage();
    });

    it('should display a list of vehicle statuses', () => {
        page.navigateTo();
        expect(page.getVehiclesStatus().count()).toBeGreaterThan(0);
    });

    it('should display only connected vehicles', () => {
        page.navigateTo();
        expect(page.changeStatus().then(page.checkIfThereIsInvalidStatus)).toEqual(0);
    });

});

