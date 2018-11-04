using System;
using BarcoSRestApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarcoSUnitTest
{
    [TestClass]
    public class TokenSerivceTester
    {
        private TokenService ts = new TokenService();
        [TestMethod]
        public void ValidatedTokenCheck()
        {
         Assert.AreEqual(true,ts.isTokenValidate("2ixLvqJVq-3GHlFmBikIVmNfBZE_mDX2S-hJniqvDZkKO2MG9UMJ1BYrsQZZaybtzkvQGcP5bEbRO2-UePIMKOrac4-WUi1M0blRUo9pPqX3caqtFiYBXgZ0agFSXlgAaP7P1_i10diN4ewER1sVgxZHqs4Q5fyBSWqxGK2cZyOlmraPweMRaY-RM8KG9D9G5fHSOKLgNUWUMkhqVGwrdkZVEaEceBWPEzqn4h-K47I"));   

        }
        [TestMethod]
        public void NonExistingTokenCheck()
        {
            Assert.AreEqual(false, ts.isTokenValidate("dtHhasdasdassaec"));

        }
        [TestMethod]
        public void NullTokenCheck()
        {
            Assert.AreEqual(false, ts.isTokenValidate(""));

        }

    }
}
