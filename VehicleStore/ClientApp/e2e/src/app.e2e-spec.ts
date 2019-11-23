import { AppPage } from './app.po';

describe('App', () => {
    let page: AppPage;

    beforeEach(() => {
        page = new AppPage();
    });

    it('should display system name', () => {
        page.navigateTo();
        expect(page.getMainHeading()).toEqual('Vehicle Monitoring System');
    });


});
