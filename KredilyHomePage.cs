using AventStack.ExtentReports;
using Chubb.DDC.TestAutomation.Extensions;
using Chubb.DDC.TestAutomation.Test_Util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chubb.SCI.Marketplace.Pages
{
    class KredilyHomePage : RegressionBasePage
    {
        #region Elements

        private IWebElement Popup => FindElement(By.XPath("//div[@class='modal-header']"));

        private IWebElement Button_Popup_Close => FindElement(By.XPath("//div[@class='modal-header']/button"));
        private IWebElement Button_WebClockInClockOut => FindElement(By.XPath("//button[@id='clockInBtn']"));
        private IWebElement Button_Tickets => FindElement(By.XPath("//span[contains(text(),'Tickets')]"));
        private IWebElement Button_TicketList => FindElement(By.XPath("//a[contains(text(),'Ticket List')]"));
        private IWebElement Button_AddNew => FindElement(By.XPath("//a[contains(text(),'Add New')]"));
        private IWebElement Txt_Subject => FindElement(By.XPath("//input[@name='subject']"));
        private IWebElement Txt_Description => FindElement(By.XPath("//textarea"));
        private IWebElement Txt_TagUser => FindElement(By.XPath("//input[@placeholder='Find and tag user(s)']"));
        private IWebElement Txt_TagUser_Sub => FindElement(By.XPath("//li[contains(text(),'Mahavir Vatalia (Asistant Manager, Vadodara)')]"));
        private IWebElement Lbl_TagUser => FindElement(By.XPath("//label[@for='tag_person']"));
        private IWebElement Drp_Category => FindElement(By.XPath("//label[@for='category']/../div/div/button[@title='Development']"));
        private IWebElement Drp_Category_QA => FindElement(By.XPath("//span[contains(text(),'QA')]"));
        private IWebElement Drp_SubCategory => FindElement(By.XPath("(//label[@for='category']/../div/div/button)[2]"));
        private IWebElement Drp_Priority => FindElement(By.XPath("(//label[@for='priority']/../div/div/button)[1]"));
        private IWebElement Drp_Priority_Medium => FindElement(By.XPath("(//span[contains(text(),'Medium')])"));
        private IWebElement Drp_Location => FindElement(By.XPath("(//label[@for='priority']/../div/div/button)[2]"));
        private IWebElement Drp_Location_Vadodara => FindElement(By.XPath("//span[contains(text(),'Vadodara')]"));
        private IWebElement Btn_Submit => FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement Lbl_ValidateTicket => FindElement(By.XPath("//div[contains(text(),'Showing')]"));
        private IWebElement Btn_Delete => FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement Btn_DeleteConfirm => FindElement(By.XPath("//button[contains(text(),'OK')]"));
        private IWebElement Lbl_Edit => FindElement(By.XPath("(//tbody/tr/td/span)[1]"));
        private IWebElement Button_Edit => FindElement(By.XPath("//button[contains(text(),'Edit')]"));
        private IWebElement Text_Subject => FindElement(By.XPath("//input[@name='subject']"));
        private IWebElement Drp_Category_Edit => FindElement(By.XPath("(//button[@data-toggle='dropdown'])[1]"));
        private IWebElement Drp_Category_Digital => FindElement(By.XPath("//span[contains(text(),'Digital Marketing')]"));
        private IWebElement Btn_Submit_Edit => FindElement(By.XPath("(//input[@value='Submit'])[1]"));
        private IWebElement Btn_CloseEdit => FindElement(By.XPath("(//button[contains(text(),'Close')])[1]"));
        private IWebElement Btn_NavigateTicket => FindElement(By.XPath("(//a[contains(text(),'Ticket')])[1]"));

        

        #endregion


        #region Methods

        //To check if the popup is displayed and if yes it will be closed
        public bool isPopupDisplayed(ExtentTest Test)
        {
            bool Breturn = false;
            Thread.Sleep(4000);

            if (Popup.Displayed)
            {
                Button_Popup_Close.Click();
                Thread.Sleep(5000);

                Test.Info("Popud that was displayed is closed now.");
            }



            return Breturn;
        }

        //To WebClock In and Clock Out
        public bool WebClockInClockOutFunctionality(ExtentTest Test)
        {
            bool Breturn = false;
            Thread.Sleep(2000);
            if (Button_WebClockInClockOut.Displayed)
            { 
                Button_WebClockInClockOut.Click();
                Test.Pass("Succesfully Clicked on Web Clock In Button");
                Thread.Sleep(2000);
            }
            else
            {
                Test.Fail("Unable to find Web Clock In Button");
            }
            //Web Clock Out Functionality will be enabled after 15 seconds
            
            Thread.Sleep(16000);
            if (Button_WebClockInClockOut.Displayed)
            {
                Button_WebClockInClockOut.Click();
                Test.Pass("Succesfully Clicked on Web Clock Out Button");
                Thread.Sleep(2000);
                Breturn = true;
            }
            else
            {
                Test.Fail("Unable to find Web Clock Clock Button");
            }
            return Breturn;
        }

        //To Create, Edit and Delete a Ticket
        public bool CreateEditDeleteTicket(ExtentTest Test)
        {
            bool Breturn = false;

            Thread.Sleep(2000);
            Button_Tickets.TryClick(Using.JS);
            Thread.Sleep(1000);
            Button_TicketList.TryClick(Using.JS);
            Thread.Sleep(5000);

            

            if (Button_AddNew.Displayed)
            {
                DynamicWait.waitTillElementisDisplayed(SmartDriver.Instance, By.XPath("//a[contains(text(),'Add New')]"), 10);
                Button_AddNew.TryClick(Using.JS);
                Thread.Sleep(6000);

                Test.Info("Beginning to add information to create the ticket.");

                Txt_Subject.SendKeys("Test");
                Txt_Description.TryClick(Using.JS);
                Txt_Description.SendKeys("Test");
                Thread.Sleep(1000);
                //Txt_TagUser.Click();
                //Txt_TagUser.SendKeys("as");
                //Txt_TagUser_Sub.Click();
                //Lbl_TagUser.Click();

                Drp_Category.TryClick(Using.JS);
                Drp_Category_QA.TryClick(Using.JS);


                Drp_Priority.TryClick(Using.JS);
                Drp_Priority_Medium.TryClick(Using.JS);

                Drp_Location.TryClick(Using.JS);
                Drp_Location_Vadodara.TryClick(Using.JS);

                Btn_Submit.TryClick(Using.JS);
                Test.Success("Succesfully Created a Ticket!");

                Thread.Sleep(5000);

                if (Lbl_ValidateTicket.Displayed)
                {
                    Breturn = true;
                    Test.Pass("Succesfully Validated the Created Ticket");
                }

                else
                {
                    Breturn = false;
                    Test.Fail("Created Ticket Not Found");
                }

                
                if (Lbl_Edit.Displayed)
                {
                    Test.Info("Beginning to add information to edit the ticket.");

                    Thread.Sleep(2000);
                    Lbl_Edit.TryClick(Using.JS);

                    Button_Edit.TryClick(Using.JS);
                    Thread.Sleep(3000);

                    Text_Subject.Clear();

                    Text_Subject.SendKeys("Test Edit");

                    Txt_Description.Clear();
                    Txt_Description.SendKeys("Test Edit");

                    Drp_Category_Edit.TryClick(Using.JS);

                    Drp_Category_Digital.TryClick(Using.JS);

                    Test.Success("Succesfully Edited the ticket");

                    Btn_CloseEdit.TryClick(Using.JS);

                    Thread.Sleep(3000);
                    Btn_NavigateTicket.TryClick(Using.JS);
                    //Btn_Submit_Edit.TryClick(Using.JS);

                    Thread.Sleep(3000);
                }


                Test.Info("Starting to delete the ticket.");

                if (Btn_Delete.Displayed)
                {
                    Btn_Delete.TryClick(Using.JS);
                    Thread.Sleep(2000);
                    Btn_DeleteConfirm.TryClick(Using.JS);
                    Thread.Sleep(3000);
                    Breturn = true;
                    Test.Success("Succesfully Deleted the Ticket");
                }
                else
                {
                    Breturn = false;

                    Test.Fail("Unable to Delete The Ticket.");
                }

                Breturn = true;
            }

            return Breturn;
        }


        #endregion

    }
}
