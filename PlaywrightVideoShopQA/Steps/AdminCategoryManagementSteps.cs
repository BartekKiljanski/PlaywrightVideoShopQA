using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using PlaywrightVideoShopQA.PageObjectLibrary;


[Binding]
public class AdminCategoryManagementSteps
{
	private readonly IPage _page;

	private readonly AdminLoginPO _adminLoginPo;
	private readonly AdminManagement _adminManagement;


	public AdminCategoryManagementSteps(IPage page)
	{
		_page = page;
	
		_adminLoginPo = new AdminLoginPO(page);
		_adminManagement = new AdminManagement(page);
	}
	[When(@"wybieram zakładkę Kategoria")]
	public async Task WhenWybieramZakladkeKategoria()
	{
		await _adminLoginPo.GoToContentManagementAsync();
		await _adminManagement.GoToCategoryItemAsync();
	}

	[When(@"wybieram opcję Utwórz nową kategorię")]
	public async Task WhenWybieramOpcjeUtworzNowaKategorie()
	{
		await _adminManagement.GoToCreateNewCategoryAsync();
	}

	[When(@"wypełniam formularz danymi")]
	public async Task WhenWypelniamFormularzDanymi()
	{
		await _adminManagement.CreateNameCategoryAsync("Romance");
		await _adminManagement.CreateDisplayOrderCategoryAsync("3");
	}

	[When(@"wybieram opcję Utwórz")]
	public async Task WhenWybieramOpcjeUtworz()
	{
		await _adminManagement.GoToCreateCategoryAsync();
	}

	[Then(@"nowa kategoria zostaje dodana")]
	public async Task ThenNowaKategoriaZostajeDodana()
	{
		await _adminLoginPo.FindTextAfterCreateProductAsync("Romance");
	}

	[When(@"wybieram istniejącą kategorię do edycji")]
	public async Task WhenWybieramIstniejacaKategorieDoEdycji()
	{
		await _adminManagement.GoToEditCategoryAsync();
	}

	[When(@"modyfikuję dane w formularzu")]
	public async Task WhenModyfikujeDaneWFormularzu()
	{
		await _adminManagement.EditNameCategoryAsync("Horror");
	}

	[When(@"wybieram opcję Edytuj")]
	public async Task WhenWybieramOpcjeEdytuj()
	{
		await _adminManagement.GoToCreateCategoryAsync();
	}

	[Then(@"zmodyfikowana kategoria zostaje zaktualizowana")]
	public async Task ThenZmodyfikowanaKategoriaZostajeZaktualizowana()
	{
		await _adminLoginPo.FindTextAfterCreateProductAsync("Horror");
	}

	[When(@"wybieram istniejącą kategorię do usunięcia")]
	public async Task WhenWybieramIstniejacaKategorieDoUsuniecia()
	{
		await _adminManagement.GoToDeleteCategoryAsync();
	}

	[When(@"klikam przycisk Usuń")]
	public async Task WhenKlikamPrzyciskUsun()
	{
		await _adminManagement.GoToDeleteInCategoryAsync();
	}

	[Then(@"wybrana kategoria zostaje usunięta")]
	public async Task ThenWybranaKategoriaZostajeUsunieta()
	{
		await _page.WaitForTimeoutAsync(2000);
		await _adminManagement.FindButtonAfterDeleteCategoryAsync();
	}




}
