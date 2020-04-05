using Chubb.DDC.SCI.CommonFunction;
using Chubb.DDC.SCI.Pages;
using Chubb.DDC.TestAutomation.Extensions;
using Chubb.DDC.TestAutomation.Test_Util;
using Chubb.DDC.TestAutomation.Test_Util.RegressionBaseClass;
using Chubb.SCI.Marketplace.CommonFunction;
using Chubb.SCI.Marketplace.Data;
using Chubb.SCI.Marketplace.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chubb.SCI.Marketplace.RegressionSuite
{
    [TestFixture]
    public class Kredily : RegressionBaseClass
    {
        

        [Test]
        [TestCaseSource(typeof(TestDataLOB), "BOPLOBData")]
        public void Kredily_Task(string TC, SCIMPData data)
        {
            Boolean Breturn = false;
           
            String path = InitializeTestDataFile.InitTestLOBData("BOP");
            
            
            try
            {
                LoginPage loginPage = new LoginPage();
                KredilyHomePage homePage = new KredilyHomePage();
                
                String username = ConfigurationManager.AppSettings["Username_Kredily"];
                String password = ConfigurationManager.AppSettings["Password_Kredily"];

                loginPage.EnterUsernamePasswordKredily(username,password);
                Test.Info("Entering UserName as :: " + username.Bold());
                Test.Success("Succesfully Logged In!");


                Breturn = homePage.isPopupDisplayed(Test);
                Assert.IsTrue(Breturn, "Failed to handle Popup");
                Test.Pass("Successfully Handled Popup");



                Breturn = homePage.WebClockInClockOutFunctionality(Test);
                Assert.IsTrue(Breturn, "Failed to check Clock In/Clock Out Functionality");
                Test.Pass("Successfully Clocked In and Clocked Out!");

            }
            catch (WebDriverException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }


        [Test]
        [TestCaseSource(typeof(TestDataLOB), "BOPLOBData")]
        public void Kredily_Task2(string TC, SCIMPData data)
        {
            Boolean Breturn = false;

            String path = InitializeTestDataFile.InitTestLOBData("BOP");


            try
            {
                LoginPage loginPage = new LoginPage();
                KredilyHomePage homePage = new KredilyHomePage();

                String username = ConfigurationManager.AppSettings["Username_Project2"];
                String password = ConfigurationManager.AppSettings["Password_Project2"];


                Breturn = loginPage.LoginProject2(username, password);
                Test.Info("Entering UserName as :: " + username.Bold());
                Test.Success("Succesfully Logged In!");


                Breturn = homePage.CreateEditDeleteTicket(Test);
                Assert.IsTrue(Breturn, "Failed to Validate Create/Edit/Delete Functionality");
                Test.Pass("Successfully Validated Create/Edit/Delete Functionality!");

            }
            catch (WebDriverException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }


    }
}
