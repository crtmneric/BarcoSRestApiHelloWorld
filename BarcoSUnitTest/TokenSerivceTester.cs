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
         Assert.AreEqual(true,ts.isTokenValidate("_dZPKnIF9yrocT_4_GyOIeYbjX1p8FdV4A5HAL-0cGFFnbhSzz9SU-8NxoAWspY9zX1ZJzMQDhE74LxJn75L9tVoUH5tM1tT7qG3QtFWj1hDwxdrnJJwXIq_DossY3UAeXg4NV8Bf9Mh2hiWWAzBDPWJSHW3Y9yOuYRoT-Z3LZ-ZL5EFfncU_xdAJ2u8QOZaxjSc40tj7AYvZoDlOgAqRyafFKOXViGuefWUc77pb3o"));   

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
