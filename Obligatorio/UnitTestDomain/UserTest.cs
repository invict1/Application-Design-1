﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System;

namespace UnitTestDomain
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestCreateAdministratorWithoutParameters()
        {
            Administrator administrator = new Administrator();
            Assert.IsNotNull(administrator);
        }

        [TestMethod]
        public void TestCreateAdministratorWithParameters()
        {
            DateTime registrationDate = DateTime.Now;
            Administrator administrator = new Administrator("admin","admin","Pablo","Pereira",registrationDate);
            Assert.IsNotNull(administrator);
        }

    }
}
