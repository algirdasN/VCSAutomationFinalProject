﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class BaseLogin : BaseTest
    {
        public static User CurrentUser;

        [SetUp]
        public void Login()
        {
            driver.Url = "https://www.aic.lt";
            AcceptCookies();
           
            landingPage
                .ClickLoginModalButton()
                .EnterUsername(User.Default)
                .EnterPassword(User.Default)
                .ClickLoginButton()
                .AssertSuccessfulLogin(User.Default);
        }

        [TearDown]
        public void Logout()
        {
            landingPage
                .ClickLogoutButton()
                .AssertSuccessfulLogout();
        }
    }
}
