using Microsoft.VisualStudio.TestTools.UnitTesting;
using RA;
using System;

namespace uebungen
{
    [TestClass]
    public class uebung7_BasicAuth
    {
        [TestMethod]
        public void BasicAuthTest()
        {
            string credentials = EncodeCredentialsToBase64("postman", "password");

            new RestAssured()
                .Given()
                    .Header("Content-Type", "application/json")
                    .Header("Authorization", "Basic " + credentials)
                    .Debug()
                .When()
                    .Get("https://postman-echo.com/basic-auth")
                .Then()
                    .TestStatus("Status Code should be 200", c => c == 200)
                    .TestBody("Body should successful authentication", b => b.authenticated == true)
                    .Debug()
                    .AssertAll()
             ;
        }

        private string EncodeCredentialsToBase64(string username, string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username + ":" + password));
        }

    }
}
