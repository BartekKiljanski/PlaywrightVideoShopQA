using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using PlaywrightVideoShopQA.PageObjectLibrary;
using System.IO;
using System.Xml.Linq;


[Binding]
public class AdminCompanyManagementSteps
{
	private readonly IPage _page;

	private readonly AdminLoginPO _adminLoginPo;
	private readonly AdminManagement _adminManagement;


	public AdminCompanyManagementSteps(IPage page)
	{
		_page = page;
	
		_adminLoginPo = new AdminLoginPO(page);
		_adminManagement = new AdminManagement(page);
	}
	[When(@"wybieram zakładkę Firmy")]
	public async Task WhenWybieramZakladkeFirmy()
	{
		await _adminLoginPo.GoToContentManagementAsync();
		await _adminManagement.GoToCompanyItemAsync();
	}

	[When(@"wybieram opcję Utwórz nową firmę")]
	public async Task WhenWybieramOpcjeUtworzNowaFirme()
	{
		await _adminManagement.GoToCreateNewCompanyAsync();
	}

	[When(@"wypełniam formularz danymi firmy")]
	public async Task WhenWypelniamFormularzDanymiFirmy()
	{
		await _adminManagement.CreateNewCompanyAsync("FirmaPlayWright", "123321123", "Playwrightstreet", "CityPlayWright", "Wojewodztwo", "14123");
	}

	[When(@"wybieram opcję Utwórz firmę")]
	public async Task WhenWybieramOpcjeUtworzFirme()
	{
		await _adminManagement.GoToCreateCompanyAsync();
	}

	[Then(@"nowa firma zostaje dodana")]
	public async Task ThenNowaFirmaZostajeDodana()
	{
		await _adminLoginPo.FindTextAfterCreateProductAsync("FirmaPlayWright");
	}

	[When(@"wybieram istniejącą firmę do edycji")]
	public async Task WhenWybieramIstniejacaFirmeDoEdycji()
	{
		await _adminManagement.GoToEditCompanyAsync();
	}

	[When(@"modyfikuję dane w formularzu firmy")]
	public async Task WhenModyfikujeDaneWFormularzuFirmy()
	{
		await _adminManagement.EditCompanyAsync("EditFirmaPlay");
	}

	[Then(@"zmodyfikowana firma zostaje zaktualizowana")]
	public async Task ThenZmodyfikowanaFirmaZostajeZaktualizowana()
	{
		await _adminLoginPo.FindTextAfterCreateProductAsync("EditFirmaPlay");
	}

	[When(@"wybieram istniejącą firmę do usunięcia")]
	public async Task WhenWybieramIstniejacaFirmeDoUsuniecia()
	{
		await _adminManagement.GoToDeleteCompanyAsync();
	}

	[When(@"potwierdzam chęć usunięcia firmy")]
	public async Task WhenPotwierdzamChecUsunieciaFirmy()
	{
		await _adminManagement.GoToAlertCompanyDeleteAsync();
	}

	[Then(@"wybrana firma zostaje usunięta")]
	public async Task ThenWybranaFirmaZostajeUsunieta()
	{
		await _page.WaitForTimeoutAsync(2000);
		await _adminManagement.FindButtonAfterDeleteCompanyAsync();
	}





}
