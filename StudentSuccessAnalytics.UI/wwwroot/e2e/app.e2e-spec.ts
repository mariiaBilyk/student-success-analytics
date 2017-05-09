import { StudentsStatisticsPage } from './app.po';

describe('students-statistics App', () => {
  let page: StudentsStatisticsPage;

  beforeEach(() => {
    page = new StudentsStatisticsPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
