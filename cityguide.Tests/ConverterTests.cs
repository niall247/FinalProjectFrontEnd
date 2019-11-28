using Microsoft.VisualStudio.TestTools.UnitTesting;
using cityguide;
using cityguide.Data;
using cityguide.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using cityguide.Domain;
using System.Linq;
using System;
using cityguide.Converters;
namespace cityguide.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestInitialize]

        public void SetUp()
        {
            MockForms.Init();
            

        }

        [TestMethod]
        public void TestBooleanConverterFalse()
        {

            BooleanConverter booleanConverter = new BooleanConverter();
           string a = (string)booleanConverter.Convert(false, typeof(Boolean),null,default);
            Assert.AreEqual(a, "No");

        }


        [TestMethod]
        public void TestBooleanConverterTrue()
        {

            BooleanConverter booleanConverter = new BooleanConverter();
            string a = (string)booleanConverter.Convert(true, typeof(Boolean), null, default);
            Assert.AreEqual(a, "Yes");

        }

            
     

    }
}
