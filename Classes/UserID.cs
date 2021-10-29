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
// This class contains the logic to get and set the UserID account variables throughout the application
//
#endregion
namespace KeyBit_ID.Classes
{
    class UserID
    {
        //variables that store input when user enters info when creating or logging into their account
        public static int ID { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static string MasterPassword { get; set; }

        //Method that returns the above vairables as a single string
        public static string UserInfo
        {
            get
            {
                return $"{ID} {FirstName} {LastName} {Email} {Password} {MasterPassword}";
            }
        }

    }
}
