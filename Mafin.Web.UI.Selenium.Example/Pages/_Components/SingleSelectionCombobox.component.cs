namespace Mafin.Web.UI.Selenium.Example.Pages.Components;

public partial class SingleSelectionComboboxComponent<TComponent, TConditions, TCondition>
{
    public string SelectedOption => Selected.Text.Trim();

    public void Expand()
    {
        Arrow.Click();
    }

    public TComponent Select(string optionName)
    {
        Expand();

        Flyout.Options[o => o.Text.TrimEnd() == optionName].Click();

        return component;
    }
}
