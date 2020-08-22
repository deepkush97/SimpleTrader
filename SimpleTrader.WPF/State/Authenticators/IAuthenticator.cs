using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        event Action StateChanged;
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

        /// <summary>
        /// Login to the application
        /// </summary>
        /// <param name="username">The login username.</param>
        /// <param name="password">The login password.</param>
        /// <exception cref="UserNotFoundException">Throws if the user does not exists.</exception>
        /// <exception cref="InvalidPasswordException">Throws if the password in invalid.</exception>
        /// <exception cref="UserNotFoundException">Throws if the login fails.</exception>

        Task Login(string username, string password);
        void Logout();
    }
}
