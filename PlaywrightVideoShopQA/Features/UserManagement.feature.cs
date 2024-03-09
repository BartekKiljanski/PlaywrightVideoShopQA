﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PlaywrightVideoShopQA.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Założenie konta przez użytkownika")]
    public partial class ZalozenieKontaPrzezUzytkownikaFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "UserManagement.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pl"), "Features", "Założenie konta przez użytkownika", "  Jako administrator systemu\r\n  Chcę móc tworzyć nowe kategorie\r\n  Aby móc organi" +
                    "zować kategorii w sklepie", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pomyślne dodanie zarejestrowanie użytkownika")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        public void PomyslneDodanieZarejestrowanieUzytkownika()
        {
            string[] tagsOfScenario = new string[] {
                    "smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pomyślne dodanie zarejestrowanie użytkownika", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 13
    testRunner.Given("przechodzę na stronę aplikacji", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Zakładając, że ");
#line hidden
#line 14
    testRunner.When("wybieram zakładkę Zarejestruj", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Kiedy ");
#line hidden
#line 15
    testRunner.And("Uzupełniam formularz danymi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 16
    testRunner.And("Wybieram opcję Rejestruj", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 17
    testRunner.Then("jesteśmy zalogowani", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pomyślne zamówienie filmu przez użytkownika")]
        public void PomyslneZamowienieFilmuPrzezUzytkownika()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pomyślne zamówienie filmu przez użytkownika", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
    testRunner.Given("otwieram stronę logowania do panelu administracyjnego", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Zakładając, że ");
#line hidden
#line 23
     testRunner.When("wybieram opcję Zaloguj", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Kiedy ");
#line hidden
#line 24
    testRunner.And("wpisuję email użytkownika", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 25
    testRunner.And("wpisuję hasło użytkownika", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 26
    testRunner.And("zatwierdzam formularz logowania", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 27
    testRunner.Then("jestem zalogowany do systemu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
#line 28
    testRunner.And("wybieram szczegóły wybranego filmu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 29
    testRunner.And("wybieram ilość produktów", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 30
    testRunner.And("dodaje do koszyka", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 31
    testRunner.Then("przechodzę do koszyka", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
#line 32
    testRunner.And("wybieram podsumowanie", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 33
    testRunner.And("składam zamówienie", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 34
    testRunner.And("podaje danę do karty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 35
    testRunner.And("wybieram opcję Zapłać", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "I ");
#line hidden
#line 36
    testRunner.Then("Zamówienie zostanie pomyślnie złożone", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Wtedy ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
