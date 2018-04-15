using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantis_tests
{
    public class AuthTestBase : TestBase
    {
        [OneTimeSetUp]
        public void Login()
        {
            app.Auth.Login(new AccountData()
            {
                Name = "administrator",
                Password = "111111"
            });
        }
    }
}
