using NUnit.Framework;
using VCSAutomationFinalProject.Databases;

namespace VCSAutomationFinalProject.Tests
{
    class ChangePassword : BaseTestWithLogin
    {
        [Test]
        public void ChangePasswordTest()
        {
            const string testPassword = "automation3000";
            ChangePasswordMethod(User.Default.Password, testPassword);
            
            landingPage
                .ClickLogoutButton()
                .AssertSuccessfulLogout();
            
            landingPage
                .ClickLoginModalButton()
                .EnterUsername(User.Default)
                .EnterPasswordString(testPassword)
                .ClickLoginButton()
                .AssertSuccessfulLogin(User.Default);
            
            ChangePasswordMethod(testPassword, User.Default.Password);
        }

        public void ChangePasswordMethod(string oldPassword, string newPassword)
        {
            changePasswordPage
                .GoToChangePasswordPage()
                .EnterOldPassword(oldPassword)
                .EnterNewPassword(newPassword)
                .ConfirmNewPassword(newPassword)
                .ClickSaveNewPasswordButton()
                .AssertPasswordChangeSuccess();
        }
    }
}
