﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void TestCreateGridWithoutParameters()
        {
            Grid grid = new Grid();
            Assert.IsNotNull(grid);
        }
        
        public void TestCreateGridWithParameters(Designer designer, Client client, int height ,int width)
        {
            Grid grid = new Grid();
            Assert.IsNotNull(grid);
        }

    }
}
