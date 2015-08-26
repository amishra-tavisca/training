using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace SelleniumDemo
{
    [TestClass]
    public class UnitTestLoginPage
    {    
        [TestMethod]
        public void TestIfOnlyUsernameIsEntered()
        {

            IWebDriver driver = new FirefoxDriver();           
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.Navigate().GoToUrl("http://localhost:49909/Account/Login.aspx");
            IWebElement UserId = driver.FindElement(By.Id("MainContent_LoginUserControl_UsernameTextbox"));
            UserId.SendKeys("abhi@gmail");
            UserId.SendKeys(Keys.Enter);
            IWebElement PasswordValidator = driver.FindElement(By.Id("MainContent_LoginUserControl_RequiredFieldValidator2"));
            string message=PasswordValidator.Text;
            Assert.AreEqual("Password Required.", message);
            driver.Quit();
        }

        [TestMethod]
        public void TestIfWrongIdOrPasswordEntered()
        {
            IWebDriver driver = new FirefoxDriver();           
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.Navigate().GoToUrl("http://localhost:49909/Account/Login.aspx");
            IWebElement UserId = driver.FindElement(By.Id("MainContent_LoginUserControl_UsernameTextbox"));
            IWebElement Password = driver.FindElement(By.Id("MainContent_LoginUserControl_PasswordTextbox"));
            UserId.SendKeys("abhi@gmail");
            Password.SendKeys("qwert");
            Password.SendKeys(Keys.Enter);          
            IWebElement PasswordValidator=driver.FindElement(By.TagName("body"));
            string str = PasswordValidator.Text;
            Assert.IsTrue(str.Contains("Wrong Id or Password"));
            driver.Quit();
        }

        [TestMethod]
        public void TestIfCorrectIdAndPasswordEntered()
        {

            IWebDriver driver = new FirefoxDriver();           
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.Navigate().GoToUrl("http://localhost:49909/Account/Login.aspx");           
            IWebElement UserId = driver.FindElement(By.Id("MainContent_LoginUserControl_UsernameTextbox"));
            IWebElement Password = driver.FindElement(By.Id("MainContent_LoginUserControl_PasswordTextbox"));
            UserId.SendKeys("abhi@gmail");
            Password.SendKeys("qwerty");
            Password.SendKeys(Keys.Enter);
            IWebElement PasswordValidator = driver.FindElement(By.TagName("body"));
            string str = PasswordValidator.Text;
            Assert.IsTrue(str.Contains("Abhishek Mishra"));
            driver.Quit();
        }

    }


    [TestClass]
    public class UnitTestAddEmployeePage
    {
        [TestMethod]
        public void TestIfAnyFieldLeftEmpty()
        { 
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.Navigate().GoToUrl("http://localhost:49909/HRAddEmployeeTabPage.aspx");
            IWebElement Title = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxTitle"));
            Title.SendKeys("Mr");
            Title.SendKeys(Keys.Enter);
            IWebElement FirstNameValidator = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_RequiredFieldValidator12"));
            string message = FirstNameValidator.Text;
            Assert.AreEqual("First Name Can't be Empty", message);
            driver.Quit();
        }

        [TestMethod]
        public void TestIfEmployeeAddedSuccessfully()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.Navigate().GoToUrl("http://localhost:49909/HRAddEmployeeTabPage.aspx");
            IWebElement Title = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxTitle"));
            IWebElement FirstName = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxFirstName"));
            IWebElement LastName = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxLastName"));
            IWebElement Email = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxEmail"));
            IWebElement Phone = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxPhone"));
            IWebElement Designation = driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxDesignation"));           
            Title.SendKeys("Mr");
            FirstName.SendKeys("Rajesh");
            LastName.SendKeys("Doobe");
            Email.SendKeys("rajesh@gmail");
            Phone.SendKeys("9873298723");
            Designation.SendKeys("developer");
            Designation.SendKeys(Keys.Enter);           
            IWebElement message = driver.FindElement(By.TagName("body"));
            string str = message.Text;
            Assert.IsTrue(str.Contains("Employee Added Successfully"));
            driver.Quit();
        }
    }

    [TestClass]
    public class UnitTestChangePasswordPage
    {
        [TestMethod]
        public void TestIfOnlyOldPasswordIsEntered()
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.Navigate().GoToUrl("http://localhost:49909/PasswordChange.aspx");
            IWebElement OldPassword = driver.FindElement(By.Id("FeaturedContent_TextBoxOldPassword"));
            OldPassword.SendKeys("qwerty");
            OldPassword.SendKeys(Keys.Enter);
            IWebElement PasswordValidator = driver.FindElement(By.Id("FeaturedContent_RequiredFieldValidator2"));
            string message = PasswordValidator.Text;
            Assert.AreEqual("Field cannot be empty", message);
            driver.Quit();
        }

        [TestMethod]
        public void TestIfPasswordSuccessfullyChanged()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            driver.Navigate().GoToUrl("http://localhost:49909/PasswordChange.aspx");
            IWebElement OldPassword = driver.FindElement(By.Id("FeaturedContent_TextBoxOldPassword"));
            IWebElement NewPassword = driver.FindElement(By.Id("FeaturedContent_TextBoxNewPassword"));
            IWebElement ConfirmNewPassword = driver.FindElement(By.Id("FeaturedContent_TextBoxConfirmPassword"));
            OldPassword.SendKeys("qwerty");
            NewPassword.SendKeys("abhi");
            ConfirmNewPassword.SendKeys("abhi");
            ConfirmNewPassword.SendKeys(Keys.Enter);
            IWebElement PasswordValidator = driver.FindElement(By.TagName("body"));
            string str = PasswordValidator.Text;
            Assert.IsTrue(str.Contains("Password successfully Changed !"));
            driver.Quit();
        }
    }

}
