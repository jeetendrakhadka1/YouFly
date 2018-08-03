import { ClientPortalPage } from './app.po';

describe('client-portal App', function() {
  let page: ClientPortalPage;

  beforeEach(() => {
    page = new ClientPortalPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
