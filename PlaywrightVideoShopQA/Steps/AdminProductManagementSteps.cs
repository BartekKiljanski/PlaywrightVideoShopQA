using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightVideoShopQA.PageObjectLibrary;

[Binding]
public class AdminProductManagementSteps
{
	private readonly IPage _page;
	private readonly AdminLoginPO _adminLoginPo;

	public AdminProductManagementSteps(IPage page)
	{
		_page = page;
		_adminLoginPo = new AdminLoginPO(page);
	}

	
	

	[Given(@"jestem zalogowany jako administrator")]
	public async Task  GivenJestemZalogowanyJakoAdministrator()
	{
		await _adminLoginPo.FindLogoutButtonAfterLogging();
	}

	[When(@"wybieram zakładkę Produkty")]
	public async Task WhenWybieramZakladkeProdukty()
	{
		await _adminLoginPo.GoToContentManagementAsync();
		await _adminLoginPo.GoToProductItemAsync();
	}

	[When(@"wybieram opcję Utwórz nowy produkt")]
	public async Task WhenWybieramOpcjeUtworzNowyProdukt()
	{
		await _adminLoginPo.GoToCreateNewProductAsync();
	}

	[When(@"wypełniam formularz danymi produktu")]
	public async Task WhenWypelniamFormularzDanymiProduktu()
	{
		await _adminLoginPo.CreateNewProductAsync();
	}

	[When(@"wybieram opcję Utwórz produkt")]
	public async Task WhenWybieramOpcjeUtworzProdukt()
	{
		await _adminLoginPo.GoToCreateProductAsync();
	}

	

	[When(@"wybieram istniejący produkt do edycji")]
	public async Task WhenWybieramIstniejacyProduktDoEdycji()
	{
		await _adminLoginPo.GoToEditProductAsync();
	}

	[When(@"modyfikuję dane w formularzu produktu")]
	public async Task WhenModyfikujeDaneWFormularzuProduktu()
	{
		await _adminLoginPo.GoToEditTitleProductAsync();
	}

	[When(@"wybieram opcję Zapisz zmiany")]
	public async Task WhenWybieramOpcjeZapiszZmiany()
	{
		await _adminLoginPo.SaveEditProductAsync();
	}

	[Then(@"zmodyfikowany produkt zostaje zaktualizowany w bazie danych")]
	public async Task ThenZmodyfikowanyProduktZostajeZaktualizowanyWBazieDanych()
	{
		await _adminLoginPo.FindTextAfterCreateProductAsync("TitleTestEdit");
	}

	[When(@"wybieram istniejący produkt do usunięcia")]
	public async Task WhenWybieramIstniejacyProduktDoUsuniecia()
	{
		await _adminLoginPo.GoToDeleteProductAsync();
	}

	[When(@"potwierdzam chęć usunięcia produktu")]
	public async Task WhenPotwierdzamChecUsunieciaProduktu()
	{
		await _adminLoginPo.GoToAlertDeleteAsync();
	}


	[Then(@"widzę nowy produkt na liście produktów")]
	public async Task ThenWidzeNowyProduktNaLiscieProduktow()
	{
		await _adminLoginPo.FindButtonAfterCreateProductAsync();
	}


	[Then(@"zmodyfikowany produkt zostaje zaktualizowany na liście produktów")]
	public async Task ThenZmodyfikowanyProduktZostajeZaktualizowanyNaLiscieProduktow()
	{
		await _adminLoginPo.VerifyTitleElementAsync();
	}

	[Then(@"wybrany produkt zostaje usunięty")]
	public async Task ThenWybranyProduktZostajeUsuniety()
	{
		await _page.WaitForTimeoutAsync(2000);
		await _adminLoginPo.FindButtonAfterDeleteProductAsync();
	}
}
