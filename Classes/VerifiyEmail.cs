#region Header Block
//  About this Program
//  
//  Programmer:     Jacob Brookhouse
//  Class:          CITP 280 - 70591
//  Application:    KeyBit ID - Password Manager
//  Description:    KeyBit ID is a password manager that allows a user to save sensitive
//                  information, such as passwords and account information.
//
#endregion
#region About this file
//
// This class contains one method and with that method it checks
// a string to see if it has the characters required to be a valid email
// and returns it if the string is a valid email.
//
#endregion
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KeyBit_ID.Classes
{
    class VerifyEmail
    {
        public VerifyEmail()
        {

        }
        // Method that accepts a string and reutrns a bool
        public static bool IsValidEmail(string email)
        {
            // if the string contains any white space then not valid
            if (string.IsNullOrWhiteSpace(email))
                // return false
                return false;

            // try catch
            try
            {
                // Normalize the string with regex
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    // return match of domain
                    return match.Groups[1].Value + domainName;
                }
            }
            // regex timeout exception
            catch (RegexMatchTimeoutException)
            {
                // return false
                return false;
            }
            // arg exception
            catch (ArgumentException)
            {
                // return false
                return false;
            }
            // try catch
            try
            {
                // return regex match 
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            // regex timeout exception
            catch (RegexMatchTimeoutException)
            {
                // return false
                return false;
            }
        }
    }
}
