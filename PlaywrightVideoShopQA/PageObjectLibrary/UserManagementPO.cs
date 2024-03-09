using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightVideoShopQA.PageObjectLibrary
{
	public class UserManagementPO
	{
		private readonly IPage _page;
		private readonly string _connectionString;
		public UserManagementPO(IPage page)
		{
			_page = page;
		}
		public UserManagementPO(string connectionString)
		{
			_connectionString = connectionString;
		}
		public async Task CreateNewAccountAsync(string email, string name, string password, string confirmPassword, string phoneNumber, string street, string city, string state, string postalCode)
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
			
		}

		public async Task AddCardDataAsync(string email, string cardNumber, string date, string cvc, string holderName)
		{
			await _page.FillAsync("#email", email);
			await _page.FillAsync("#cardNumber", cardNumber);
			await _page.FillAsync("#cardExpiry", date);
			await _page.FillAsync("#cardCvc", cvc);
			await _page.FillAsync("#billingName", holderName);
		}
		public async Task GoToRegisterAsync()
		{
			await Task.Delay(1000);
			await _page.ClickAsync("//*[@id='register']");
			await Task.Delay(3000);
		}
		public async Task GoToRegister()
		{
			await Task.Delay(1000);
			await _page.ClickAsync("//*[@id='registerSubmit']");
			await Task.Delay(3000);
		}
		public async Task GoToProductAsync()
		{
			await _page.ClickAsync("//a[contains(@class, 'btn') and contains(text(), 'Szczegóły') and contains(@href, '/Customer/Home/Details?productId=')]");
		}
		public async Task EnterUserEmailAsync(string email)
		{
			await _page.FillAsync("#Input_Email", email);
		}

		public async Task EnterUserPasswordAsync(string password)
		{
			await _page.FillAsync("#Input_Password", password);
		}
		public async Task AddToCartAsync()
		{
			await _page.ClickAsync("//button[contains(text(), 'Dodaj do koszyka')]");
		}
		public async Task SendCountNumberAsync()
		{
			// Zakładając, że countNumberId to "#Count", a wartość to "2"
			await _page.FillAsync("#Count", "2");
		}
		public async Task ClickBasketAsync()
		{
			await _page.ClickAsync("//a[contains(@class, 'nav-link') and @href='/Customer/Cart']");
		}

		public async Task ClickSummaryAsync()
		{
			await _page.ClickAsync("//a[@href='/Customer/Cart/Summary'][contains(text(), 'Podsumowanie')]");
		}

		public async Task SubmitYourOrderAsync()
		{
			await _page.ClickAsync("//button[contains(text(), 'Złóż zamówienie')]");
		}

		public async Task PayByCardAsync()
		{
			await _page.ClickAsync("//div[contains(@class, 'SubmitButton-IconContainer')]");
		}

		public async Task FindFinishSummaryTextAsync()
		{
			await Task.Delay(5000);
			bool isOrderSuccess = await _page.IsVisibleAsync("//*[contains(text(), 'Zamówienie zostało pomyślnie złożone!')]");
			if (!isOrderSuccess)
			{
				throw new Exception("Order was not successfully placed.");
			}
		}


	}
}
