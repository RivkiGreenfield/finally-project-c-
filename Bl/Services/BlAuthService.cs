using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Models;
namespace Bl.Services
{
    // BL/Services/AuthService.cs
    public class BlAuthService
    {

        private readonly UserService _userRepository;
        private readonly ITokenService _tokenService;

        public BlAuthService(UserService userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public JwtToken Authenticate(string userName, string password)
        {
            User user = _userRepository.GetUserByName(userName).Result;
            if (user == null || !VerifyPassword(user, password))  // צריך לבדוק את הסיסמה בצורה מאובטחת
            {
                return null;
            }

            var token = _tokenService.CreateToken(user);
            return new JwtToken { Token = token };
        }
 
        private bool VerifyPassword(User user, string password)
        {
            // לדוג' השוואה בין סיסמה גולמית לסיסמה מאובטחת (השתמש בהצפנה)
            return user.Password.ToString() == password;
        }
    }
}
