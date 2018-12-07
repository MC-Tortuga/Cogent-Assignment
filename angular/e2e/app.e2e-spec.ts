import { CogentTemplatePage } from './app.po';

describe('Cogent App', function() {
  let page: CogentTemplatePage;

  beforeEach(() => {
    page = new CogentTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
