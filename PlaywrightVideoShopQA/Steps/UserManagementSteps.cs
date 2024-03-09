using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;
using PlaywrightVideoShopQA.PageObjectLibrary;
using System.IO;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Binding]
public class UserManagementSteps
{
	private readonly IPage _page;
	private readonly AdminLoginPO _adminLoginPo;
	private readonly UserManagementPO _userManagementPO;

	public UserManagementSteps(IPage page)
	{
		_page = page;
		_adminLoginPo = new AdminLoginPO(page);
		_userManagementPO = new UserManagementPO(page);
	}



	[Given(@"przechodzę na stronę aplikacji")]
	public async Task GivenPrzechodzeNaStroneAplikacji()
	{
		await _adminLoginPo.GoToApp();
	}

	[When(@"wybieram zakładkę Zarejestruj")]
	public async Task WhenWybieramZakladkeZarejestruj()
	{
		await _userManagementPO.GoToRegisterAsync();
	}

	[When(@"Uzupełniam formularz danymi")]
	public async Task WhenUzupelniamFormularzDanymi()
	{
		await _userManagementPO.CreateNewAccountAsync("testsplay12@gmail.com", "Bartek", "Bartek.240397", "Bartek.240397", "123321123", "Testowa", "TestCity", "TestRunState", "12331");
	}
	[When(@"Wybieram opcję Rejestruj")]
	public async Task WhenWybieramOpcjeRejestruj()
	{
		await _userManagementPO.GoToRegister();
	}

	[Then(@"jesteśmy zalogowani")]
	public async Task ThenJestesmyZalogowani()
	{
		await _adminLoginPo.FindLogoutButtonAfterLogging();
	}

	[When(@"wpisuję email użytkownika")]
	public async Task WhenWpisujeEmailUzytkownika()
	{
		await _userManagementPO.EnterUserEmailAsync("testsplay12@gmail.com");
	}

	[When(@"wpisuję hasło użytkownika")]
	public async Task WhenWpisujeHasloUzytkownika()
	{
		await _userManagementPO.EnterUserPasswordAsync("Bartek.240397");
	}

	[Then(@"jestem zalogowany do systemu")]
	public async Task ThenJestemZalogowanyDoSystemu()
	{
		await _adminLoginPo.FindLogoutButtonAfterLogging();
	}

	[Then(@"wybieram szczegóły wybranego filmu")]
	public async Task ThenWybieramSzczegolyWybranegoFilmu()
	{
		await _userManagementPO.GoToProductAsync();
	}

	[Then(@"wybieram ilość produktów")]
	public async Task ThenWybieramIloscProduktow()
	{
		await _userManagementPO.SendCountNumberAsync();
	}

	[Then(@"dodaje do koszyka")]
	public async Task ThenDodajeDoKoszyka()
	{
		await _userManagementPO.AddToCartAsync();
	}

	[Then(@"przechodzę do koszyka")]
	public async Task ThenPrzechodzeDoKoszyka()
	{
		await _userManagementPO.ClickBasketAsync();
	}

	[Then(@"wybieram podsumowanie")]
	public async Task ThenWybieramPodsumowanie()
	{
		await _userManagementPO.ClickSummaryAsync();
	}

	[Then(@"składam zamówienie")]
	public async Task ThenSkladamZamowienie()
	{
		await _userManagementPO.SubmitYourOrderAsync();
	}

	[Then(@"podaje danę do karty")]
	public async Task ThenPodajeDaneDoKarty()
	{
		await _userManagementPO.AddCardDataAsync("testsplay@gmail.com", "4242424242424242", "1224", "1233", "Jan Kowalski");
	}

	[Then(@"wybieram opcję Zapłać")]
	public async Task ThenWybieramOpcjeZaplac()
	{
		await _userManagementPO.PayByCardAsync();
	}

	[Then(@"Zamówienie zostanie pomyślnie złożone")]
	public async Task ThenZamowienieZostaniePomyslnieZlozone()
	{
		await _userManagementPO.FindFinishSummaryTextAsync();
	}

}
