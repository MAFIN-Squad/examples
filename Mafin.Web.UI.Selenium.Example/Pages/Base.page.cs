using OpenQA.Selenium;

namespace Mafin.Web.UI.Selenium.Example.Pages;

public partial class BasePage
{
    public void AcceptCookies()
    {
        var pane = CookiesPane.Expect(it => it.IsDisplayed().IsAnimated());
        pane.AcceptAll.Click();
        pane.Expect(it => it.IsNotDisplayed());
    }

    public void Navigate(string menuName)
    {
        Header.Navigation.Items[i => i.Title == menuName].Click();
    }

    public void Navigate(string menuName, string subMenuName)
    {
        Header.Navigation
            .Items[i => i.Title == menuName].Hover()
            .Flyout.SubItem(subMenuName)
            .Click();
    }

    public partial class CookiesPaneComponent
    {
        public partial class Conditions<TSelf>
        {
            public TSelf IsAnimated() => Styles["bottom"].Is("0px");
        }
    }

    public partial class HeaderComponent
    {
        public partial class SearchComponent
        {
            public SearchPage Search(string text, bool usingKeyboard = false)
            {
                SearchButton.Click()
                    .SearchInput.Type(text, when => when.IsDisplayed().IsEnabled());

                if (usingKeyboard)
                {
                    SearchInput.Type(Keys.Enter);
                }
                else
                {
                    FindButton.Click(when => when.IsEnabled());
                }

                return SpaceOptions.Services.Get<YaSpace>().Pages.SearchPage;
            }
        }
    }
}
