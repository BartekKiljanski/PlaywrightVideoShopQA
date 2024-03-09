using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightVideoShopQA.PageObjectLibrary
{
	public class AdminManagement
	{

		private readonly string _connectionString;

		public AdminManagement(string connectionString)
		{
			_connectionString = connectionString;
		}
		private readonly IPage _page;
		private readonly string _adminName = "test@admin.pl"; // Powinno pochodzić z konfiguracji
		private readonly string _adminPassword = "Bartek.240397"; // Powinno pochodzić z konfiguracji

		public AdminManagement(IPage page)
		{
			_page = page;
		}
		//Przejście do zarządzania treścią:
		public async Task GoToContentManagementAsync()
		{
			await _page.ClickAsync("//a[contains(text(), 'ZARZĄDZANIE TREŚCIĄ')]");
		}

		//Tworzenie nowej kategorii:
		public async Task GoToCreateNewCategoryAsync()
		{
			await _page.ClickAsync("//a[@class='btn btn-primary']");
		}

		public async Task GoToCategoryItemAsync()
		{
			await _page.ClickAsync("//a[@class='dropdown-item' and text()='Kategoria']");
		}

		public async Task CreateNameCategoryAsync(string name)
		{
			await _page.FillAsync("#Name", name); // Założenie, że "Name" to ID pola input.
		}

		public async Task CreateDisplayOrderCategoryAsync(string order)
		{
			await _page.FillAsync("#DisplayOrder", order); // Założenie, że "DisplayOrder" to ID pola input.
		}

		public async Task GoToCreateCategoryAsync()
		{
			await _page.ClickAsync("//button[@class='btn btn-primary form-control']");
		}

		public async Task GoToEditCategoryAsync()
		{
			await _page.ClickAsync("(//div[@class='w-75 btn-group'][@role='group'])[3]/a[contains(@href, 'Edit')]");
		}

		public async Task EditNameCategoryAsync(string newName)
		{
			await _page.FillAsync("#Name", ""); // Czyszczenie pola przed wprowadzeniem nowej wartości.
			await _page.FillAsync("#Name", newName);
		}

		public async Task GoToDeleteCategoryAsync()
		{
			await _page.ClickAsync("(//a[contains(@href, 'Delete')])[3]");
		}

		public async Task GoToDeleteInCategoryAsync()
		{
			await _page.ClickAsync("//button[@type='submit' and contains(@class, 'btn-danger') and contains(text(), 'Usuń')]");
		}
		public async Task<bool> FindButtonAfterDeleteCategoryAsync()
		{
			bool isTextVisible = false;
			// Spróbuj znaleźć tekst kilka razy zanim zdecydujesz, że nie jest obecny.
			for (int i = 0; i < 5; i++) // Przykład: Sprawdź 5 razy z interwałem 1 sekundy.
			{
				isTextVisible = await _page.EvaluateAsync<bool>(@"() => {
            return document.body.innerText.includes('Horror');
        }");

				if (isTextVisible) break; // Jeśli tekst jest widoczny, przerwij pętlę.

				await Task.Delay(2000); // Odczekaj sekundę przed kolejnym sprawdzeniem.
			}

			if (isTextVisible)
			{
				throw new InvalidOperationException("Tekst 'Horror' jest nadal widoczny na stronie.");
			}

			return true;
		}
		public async Task<bool> FindButtonAfterDeleteCompanyAsync()
		{
			bool isTextVisible = false;
			// Spróbuj znaleźć tekst kilka razy zanim zdecydujesz, że nie jest obecny.
			for (int i = 0; i < 5; i++) // Przykład: Sprawdź 5 razy z interwałem 1 sekundy.
			{
				isTextVisible = await _page.EvaluateAsync<bool>(@"() => {
            return document.body.innerText.includes('EditFirmaPlay');
        }");

				if (isTextVisible) break; // Jeśli tekst jest widoczny, przerwij pętlę.

				await Task.Delay(2000); // Odczekaj sekundę przed kolejnym sprawdzeniem.
			}

			if (isTextVisible)
			{
				throw new InvalidOperationException("Tekst 'EditFirmaPlay' jest nadal widoczny na stronie.");
			}

			return true;
		}
		/// company 
		public async Task GoToCompanyItemAsync()
		{
			await _page.ClickAsync("//a[@class='dropdown-item' and text()='Firma']");
		}

		public async Task GoToCreateNewCompanyAsync()
		{
			await _page.ClickAsync("//a[@class='btn btn-primary']");
		}

		public async Task CreateNewCompanyAsync(string name, string phoneNumber, string street, string city, string state, string postalCode)
		{
			await _page.FillAsync("#Name", name);
			await Task.Delay(1000); // Oczekiwanie na wprowadzenie danych
			await _page.FillAsync("#PhoneNumber", phoneNumber);
			await Task.Delay(1000);
			await _page.FillAsync("#StreetAddress", street);
			await Task.Delay(1000);
			await _page.FillAsync("#City", city);
			await Task.Delay(1000);
			await _page.FillAsync("#State", state);
			await Task.Delay(1000);
			await _page.FillAsync("#PostalCode", postalCode);
			await Task.Delay(1000);
		}

		public async Task GoToCreateCompanyAsync()
		{
			await _page.ClickAsync("//button[text()='Utwórz']");
		}

		public async Task GoToEditCompanyAsync()
		{
			await _page.ClickAsync("//tr[td[contains(text(),'FirmaPlayWright')]]//a[contains(@href, '/admin/company/upsert')]");
		}

		public async Task EditCompanyAsync(string newName)
		{
			await _page.FillAsync("#Name", ""); // Czyszczenie pola przed wprowadzeniem nowej wartości
			await Task.Delay(1000);
			await _page.FillAsync("#Name", newName);
		}

		public async Task GoToDeleteCompanyAsync()
		{
			await _page.ClickAsync("//tr[td[contains(text(),'EditFirmaPlay')]]//a[contains(@onclick, 'Delete')]");
		}

		public async Task GoToAlertCompanyDeleteAsync()
		{
			await Task.Delay(2000); // Czekanie na pojawienie się alertu
			await _page.ClickAsync("//button[contains(@class, 'swal2-confirm') and normalize-space(text())='Tak, usun to!']");
		}
		//create user ADMIN
		public async Task GoToAccountItemAsync()
		{
			await _page.ClickAsync("//a[@class='dropdown-item' and text()='Utwórz Użytkownika']");
		}

		public async Task CreateNewAdminAccountAsync(string email, string name, string password, string confirmPassword, string phoneNumber, string street, string city, string state, string postalCode)
		{
			await _page.FillAsync("#Input_Email", email);
			await _page.FillAsync("#Input_Name", name);
			await _page.FillAsync("#Input_Password", password);
			await _page.FillAsync("#Input_ConfirmPassword", confirmPassword);
			await _page.FillAsync("#Input_PhoneNumber", phoneNumber);
			await _page.FillAsync("#Input_StreetAddress", street);
			await _page.FillAsync("#Input_City", city);
			await _page.FillAsync("#Input_State", state);
			await _page.FillAsync("#Input_PostalCode", postalCode);
			await _page.SelectOptionAsync("select#Input_Role", new[] { "Employee" });

			// Założenie, że przycisk rejestruje się po uzupełnieniu formularza
			//await _page.ClickAsync("#registerSubmit");
		}

		public async Task EnterAccountEmailAsync(string email)
		{
			await _page.FillAsync("#Input_Email", email);
		}

		public async Task EnterAccountPasswordAsync(string password)
		{
			await _page.FillAsync("#Input_Password", password);
		}

		public async Task GoToRegisterAccountAsync()
		{
			await _page.ClickAsync("#registerSubmit"); // Upewnij się, że selektor jest poprawny
		}

		public async Task FindLogoutButtonAfterLoggingAsync()
		{
			var isVisible = await _page.IsVisibleAsync("#logout"); // Upewnij się, że selektor jest poprawny
			if (!isVisible)
			{
				throw new Exception("Błąd - brak przycisku WYLOGUJ");
			}
		}
	}
}
