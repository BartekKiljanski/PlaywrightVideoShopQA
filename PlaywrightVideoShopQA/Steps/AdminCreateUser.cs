using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PlaywrightVideoShopQA.PageObjectLibrary;
using System.IO;
using System.Xml.Linq;


[Binding]
public class AdminCreateUser
{
	private readonly IPage _page;

	private readonly AdminLoginPO _adminLoginPo;
	private readonly AdminManagement _adminManagement;


	public AdminCreateUser(IPage page)
	{
		_page = page;

		_adminLoginPo = new AdminLoginPO(page);
		_adminManagement = new AdminManagement(page);
	}
	[Given(@"otwieram stronę logowania do aplikacji")]
	public async Task GivenOtwieramStroneLogowaniaDoAplikacji()
	{
		await _adminLoginPo.GoToApp();
	}

	[When(@"wybieram zakładkę Utwórz użytkownika")]
	public async Task WhenWybieramZakladkeUtworzUzytkownika()
	{
		await _adminManagement.GoToContentManagementAsync();
		await _adminManagement.GoToAccountItemAsync();
	}

	[When(@"wypełniam formularz danymi nowego konta")]
	public async Task WhenWypelniamFormularzDanymiNowegoKonta()
	{
		await _adminManagement.CreateNewAdminAccountAsync("admincreates12@gmail.com", "Tomasz", "Test.240397", "Test.240397", "123321123", "teste", "tests", "testa", "12333");
	}
	[When(@"wybieram opcję Rejestruj")]
	public async Task WhenWybieramOpcjeRejestruj()
	{
		await _adminManagement.GoToRegisterAccountAsync();
	}

	[Then(@"nowe konto zostaje dodane")]
	public async Task ThenNoweKontoZostajeDodane()
	{
		await _adminLoginPo.FindLogoutButtonAfterLogging();
	}

	[When(@"wpisuję email utworzonego konta")]
	public async Task WhenWpisujeEmailUtworzonegoKonta()
	{
		await _adminManagement.EnterAccountEmailAsync("admincreates12@gmail.com");
	}

	[When(@"wpisuję hasło utworzonego konta")]
	public async Task WhenWpisujeHasloUtworzonegoKonta()
	{
		await _adminManagement.EnterAccountPasswordAsync("Test.240397");
	}

	[Then(@"jestem zalogowany do systemu jako nowy użytkownik")]
	public async Task ThenJestemZalogowanyDoSystemuJakoNowyUzytkownik()
	{
		await _adminLoginPo.FindLogoutButtonAfterLogging();
	}



}
