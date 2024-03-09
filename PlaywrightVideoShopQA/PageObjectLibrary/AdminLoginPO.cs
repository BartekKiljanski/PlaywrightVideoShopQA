using Dynamitey.Internal.Optimization;
using Microsoft.Playwright;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using PlaywrightVideoShopQA.Hooks;



namespace PlaywrightVideoShopQA.PageObjectLibrary
{
	public class AdminLoginPO
	{
		private readonly string _connectionString;

		public AdminLoginPO(string connectionString)
		{
			_connectionString = connectionString;
		}
		private readonly IPage _page;
		private readonly string _adminName = "test@admin.pl"; // Powinno pochodzi� z konfiguracji
		private readonly string _adminPassword = "Bartek.240397"; // Powinno pochodzi� z konfiguracji

		public AdminLoginPO(IPage page)
		{
			_page = page;
		}

		public async Task GoToApp()
		{
			await _page.GotoAsync("https://localhost:7246");
		}

		public async Task GoToLoginAsync()
		{
			await _page.ClickAsync("//*[@id='login']");
		}

		public async Task EnterEmail()
		{
			await _page.FillAsync("#Input_Email", _adminName);

		}
		public async Task EnterPassword()
		{

			await _page.FillAsync("#Input_Password", _adminPassword);
		}
		public async Task GoToLoginSubmit()
		{
			await _page.ClickAsync("#login-submit");
		}

		public async Task<bool> FindLogoutButtonAfterLogging()
		{
			return await _page.IsVisibleAsync("#logout");
		}
		

		public async Task GoToContentManagementAsync()
		{
			await _page.ClickAsync("text=ZARZ�DZANIE TRE�CI�");
		}

		public async Task GoToProductItemAsync()
		{
			await _page.ClickAsync("//a[@class='dropdown-item' and text()='Produkt']");
		}

		public async Task GoToCreateNewProductAsync()
		{
			await _page.ClickAsync("//a[@class='btn btn-primary']");
		}
		public async Task EnterTextIntoTinyMCEAsync(string frameSelector, string text)
		{
			// Pobierz uchwyt do iframe edytora TinyMCE
			var frameElementHandle = await _page.WaitForSelectorAsync(frameSelector);
			var frame = await frameElementHandle.ContentFrameAsync();

			// Pobierz uchwyt do elementu body w edytorze TinyMCE
			var bodyElement = await frame.QuerySelectorAsync("body");

			// Wyczy�� istniej�cy tekst i wprowad� nowy tekst
			await bodyElement.EvaluateAsync(@"(element, text) => { element.innerHTML = ''; element.appendChild(document.createTextNode(text)); }", text);
		}

		public async Task CreateNewProductAsync()
		{
			await _page.FillAsync("#Product_Title", "TitleTest");
			await EnterTextIntoTinyMCEAsync("#Product_Description_ifr", "DescriptionTest");

			await _page.FillAsync("#Product_ISBN", "C1");
			await _page.FillAsync("#Product_Author", "AuthorTest");
			await _page.FillAsync("#Product_ListPrice", "10");
			await _page.FillAsync("#Product_Price", "11");
			await _page.FillAsync("#Product_Price50", "11");
			await _page.FillAsync("#Product_Price100", "12");
			await _page.WaitForTimeoutAsync(2000);
			await _page.WaitForSelectorAsync("#Product_CategoryId");

			// Wybierz opcj� "Action" z listy rozwijanej
			await _page.SelectOptionAsync("#Product_CategoryId", "Action");
			await _page.WaitForTimeoutAsync(2000); // Poczekaj 2 sekundy
		}
		public async Task VerifyTitleElementAsync()
		{
			try
			{
				// Poczekaj na pojawienie si� elementu z tekstem "TitleTest" w kolumnie "Title"
				var titleElement = await _page.WaitForSelectorAsync($"//td[contains(text(), 'TitleTest')]");

				// Sprawd�, czy znaleziono element z tekstem "TitleTest"
				if (titleElement != null)
				{
					// Pobierz tekst z elementu i potwierd�, czy jest to oczekiwany tekst
					var titleText = await titleElement.TextContentAsync();
					if (titleText == "TitleTest")
					{
						Console.WriteLine("Znaleziono element z tekstem 'TitleTest'.");
					}
					else
					{
						Console.WriteLine("Tekst w znalezionym elemencie nie jest 'TitleTest'.");
					}
				}
				else
				{
					Console.WriteLine("Nie znaleziono elementu z tekstem 'TitleTest'.");
				}
			}
			catch (PlaywrightException ex)
			{
				Console.WriteLine($"Wyst�pi� b��d podczas weryfikacji elementu: {ex.Message}");
			}
		}

		public async Task GoToCreateProductAsync()
		{
			await _page.ClickAsync("//button[text()='Utw�rz']");
		}
		public async Task<bool> FindButtonAfterCreateProductAsync()
		{
			// U�ycie Locator z XPath do znalezienia elementu
			var element = _page.Locator("xpath=//td[contains(@class, 'sorting_1') and text()='TitleTest']");

			// Sprawdzenie, czy element jest widoczny
			bool isVisible = await element.IsVisibleAsync();
			return isVisible;
		}
		public async Task<bool> FindButtonAfterDeleteProductAsync()
		{
			bool isTextVisible = false;
			// Spr�buj znale�� tekst kilka razy zanim zdecydujesz, �e nie jest obecny.
			for (int i = 0; i < 5; i++) // Przyk�ad: Sprawd� 5 razy z interwa�em 1 sekundy.
			{
				isTextVisible = await _page.EvaluateAsync<bool>(@"() => {
            return document.body.innerText.includes('TitleTestEdit');
        }");

				if (isTextVisible) break; // Je�li tekst jest widoczny, przerwij p�tl�.

				await Task.Delay(2000); // Odczekaj sekund� przed kolejnym sprawdzeniem.
			}

			if (isTextVisible)
			{
				throw new InvalidOperationException("Tekst 'TitleTestEdit' jest nadal widoczny na stronie.");
			}

			return true; 
		}

		
		public async Task FindTextAfterCreateProductAsync(string expectedText)
		{
			await _page.WaitForTimeoutAsync(3000);
			var textExists = await _page.IsVisibleAsync($"//td[contains(text(), '{expectedText}')]");
			if (!textExists)
			{
				// Obs�uga b��du, gdy tekst nie jest widoczny
				throw new Exception($"B��d - brak tekstu '{expectedText}'");
			}
		}
		public async Task FindTextAfterDeleteProductAsync(string expectedText)
		{
			var textExists = await _page.IsVisibleAsync($"//td[contains(text(), '{expectedText}')]");
			if (textExists)
			{
				// Obs�uga b��du, gdy tekst nie jest widoczny
				throw new Exception($"B��d -  tekst jest dalej '{expectedText}'");
			}
		}

		public async Task GoToEditProductAsync()
		{
			try
			{
				// Poczekaj na pojawienie si� przycisku edycji dla wiersza zawieraj�cego tekst "TitleTest"
				var editButton = await _page.WaitForSelectorAsync($"//td[text()='TitleTest']/parent::tr//a[contains(@class, 'btn-primary') and contains(@href, 'upsert')]");

				if (editButton != null)
				{
					// Kliknij przycisk edycji
					await editButton.ClickAsync();
					Console.WriteLine("Przej�cie do edycji produktu zako�czone sukcesem.");
				}
				else
				{
					Console.WriteLine("Nie mo�na znale�� przycisku edycji dla produktu o nazwie 'TitleTest'.");
				}
			}
			catch (PlaywrightException ex)
			{
				Console.WriteLine($"Wyst�pi� b��d podczas przechodzenia do edycji produktu: {ex.Message}");
			}
		}



		public async Task GoToEditTitleProductAsync()
		{
			await _page.FillAsync("#Product_Title", "TitleTestEdit");
		}

		public async Task SaveEditProductAsync()
		{
			await _page.ClickAsync("//button[@class='btn btn-primary form-control']");
		}

		public async Task GoToDeleteProductAsync()
		{
			try
			{
				// Poczekaj na pojawienie si� przycisku usuwania dla wiersza zawieraj�cego tekst "TitleTestEdit"
				var deleteButton = await _page.WaitForSelectorAsync($"//td[text()='TitleTestEdit']/parent::tr//a[contains(@class, 'btn-danger') and contains(@onclick, 'Delete')]");

				if (deleteButton != null)
				{
					// Kliknij przycisk usuwania
					await deleteButton.ClickAsync();
					Console.WriteLine("Przej�cie do usuwania produktu zako�czone sukcesem.");
				}
				else
				{
					Console.WriteLine("Nie mo�na znale�� przycisku usuwania dla produktu o nazwie 'TitleTestEdit'.");
				}
			}
			catch (PlaywrightException ex)
			{
				Console.WriteLine($"Wyst�pi� b��d podczas przechodzenia do usuwania produktu: {ex.Message}");
			}
		}


		public async Task GoToAlertDeleteAsync()
		{
			await _page.ClickAsync("//button[contains(@class, 'swal2-confirm') and normalize-space(text())='Tak, usu� to!']");
		}
		
		

	
	}
}
