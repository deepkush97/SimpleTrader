using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

        /// <summary>
        /// Get an account for a user's credentials.
        /// </summary>
        /// <param name="username">The login username.</param>
        /// <param name="password">The login password</param>
        /// <returns>The account for the user.</returns>
        /// <exception cref="UserNotFoundException">Throws if the user does not exists.</exception>
        /// <exception cref="InvalidPasswordException">Throws if the password in invalid.</exception>
        /// <exception cref="UserNotFoundException">Throws if the login fails.</exception>
        Task<Account> Login(string username, string password);
    }
}
