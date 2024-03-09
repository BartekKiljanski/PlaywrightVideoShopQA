using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightVideoShopQA.PageObjectLibrary;


[Binding]
public class AdminLoginSteps
{
	private readonly IPage _page;

	private readonly AdminLoginPO _adminLoginPo;

	public AdminLoginSteps(IPage page)
	{
		_page = page;
	
		_adminLoginPo = new AdminLoginPO(page);
	}

	[Given(@"otwieram stronę logowania do panelu administracyjnego")]
	public async Task GivenOtwieramStroneLogowaniaDoPaneluAdministracyjnego()
	{
		await _adminLoginPo.GoToApp();
	}

	[When(@"wybieram opcję Zaloguj")]
	public async Task WhenWybieramOpcjeZaloguj()
	{
		await _adminLoginPo.GoToLoginAsync();
	}

	[When(@"wpisuję email administratora")]
	public async Task WhenWpisujeEmailAdministratora()
	{
		await _adminLoginPo.EnterEmail();
	}

	[When(@"wpisuję hasło administratora")]
	public async Task WhenWpisujeHasloAdministratora()
	{
		await _adminLoginPo.EnterPassword();
	}

	
	[When(@"zatwierdzam formularz logowania")]
	public async Task WhenZatwierdzamFormularzLogowania()
	{
		await _adminLoginPo.GoToLoginSubmit();
	}

	[Then(@"jestem zalogowany do systemu jako administrator")]
	public async Task ThenJestemZalogowanyDoSystemuJakoAdministrator()
	{
		await _adminLoginPo.FindLogoutButtonAfterLogging();
	}



}
