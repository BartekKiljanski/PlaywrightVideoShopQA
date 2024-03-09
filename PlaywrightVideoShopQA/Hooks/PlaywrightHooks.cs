using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]


namespace PlaywrightVideoShopQA.Hooks;

[Binding]
public class PlaywrightHooks
{
	private IBrowser _browser;
	private IPage _page;
	private readonly IObjectContainer _objectContainer;

	public PlaywrightHooks(IObjectContainer objectContainer)
	{
		_objectContainer = objectContainer;
	}

	[BeforeScenario]
	public async Task BeforeScenario()
	{
		var playwright = await Playwright.CreateAsync();
		_browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
		_page = await _browser.NewPageAsync();

		// Rejestruj IPage w kontenerze SpecFlow IoC, aby mo¿na by³o go wstrzykn¹æ do kroków scenariusza
		_objectContainer.RegisterInstanceAs<IPage>(_page);
	}

	[AfterScenario]
	public async Task AfterScenario()
	{
		await _page.CloseAsync();
		await _browser.CloseAsync();
	}
}
