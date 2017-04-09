using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using System.Threading;
using System.Windows.Automation;

namespace CalcTest02
{
    [TestClass]
    public class UnitTest1
    {
        private Application application;
        private Random rnd;
        //Helpers
        private Window GetWindow()
        {
            return application.GetWindow("Calculator");
        }
        private Button GetButton(string buttIdentifier)
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                var button = GetWindow().Get<Button>(SearchCriteria.ByAutomationId(buttIdentifier));
                if (button != null) return button;
            }
            return null;
        }
        private string ResultTextBox()
        {
            return GetWindow().Get<Label>(SearchCriteria.ByAutomationId("150")).AutomationElement.
                GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
        }

        private void TypeRandomNumber(out long number)
        {
            number = rnd.Next(0, Int16.MaxValue) + 1;
            var numStr = number.ToString();
            foreach (char ch in numStr)
            {
                GetButton("13" + ch).Click();
            }
        }

        [TestInitialize]
        public void TestInit()
        {
            rnd = new Random();
        }
        
        [TestMethod]
        public void TestAdd()
        {
            application = Application.Launch(@"C:\Windows\system32\calc.exe");
            Assert.IsNotNull(application);
            long number1, number2;
            TypeRandomNumber(out number1);
            GetButton("93").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), (number1 + number2).ToString());
            application.Close();
        }

        [TestMethod]
        public void TestSubstract()
        {
            application = Application.Launch(@"C:\Windows\system32\calc.exe");
            Assert.IsNotNull(application);
            long number1, number2;
            TypeRandomNumber(out number1);
            GetButton("94").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), (number1 - number2).ToString());
            application.Close();
        }

        [TestMethod]
        public void TestMultiply()
        {
            application = Application.Launch(@"C:\Windows\system32\calc.exe");
            Assert.IsNotNull(application);
            long number1, number2;
            TypeRandomNumber(out number1);
            GetButton("92").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), (number1 * number2).ToString());
            application.Close();
        }

        [TestMethod]
        public void TestDivide()
        {
            application = Application.Launch(@"C:\Windows\system32\calc.exe");
            Assert.IsNotNull(application);
            long number1, number2;
            TypeRandomNumber(out number1);
            GetButton("91").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), ((double)number1 / number2).ToString("G16"));
            application.Close();
        }

        [TestMethod]
        public void TestAllOperations()
        {
            application = Application.Launch(@"C:\Windows\system32\calc.exe");
            Assert.IsNotNull(application);
            long number1, number2;
            TypeRandomNumber(out number1);
            GetButton("93").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), (number1 + number2).ToString());
            GetButton("81").Click();
            TypeRandomNumber(out number1);
            GetButton("94").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), (number1 - number2).ToString());
            GetButton("81").Click();
            TypeRandomNumber(out number1);
            GetButton("92").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), (number1 * number2).ToString());
            GetButton("81").Click();
            TypeRandomNumber(out number1);
            GetButton("91").Click();
            TypeRandomNumber(out number2);
            GetButton("121").Click();
            Assert.AreEqual<string>(ResultTextBox(), ((double)number1 / number2).ToString("G16"));
            application.Close();
        }
    }
}
