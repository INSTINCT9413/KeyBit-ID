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
// Account Operations Interface
//
#endregion
namespace KeyBit_ID.Interfaces
{
    public interface IAccountOperations
    {
        // get set key
        string key { get; set; }
        // get set dataLocation
        string dataLocation { get; set; }
        // GetAccountInfo
        void GetAccountInfo();
        void AccountBackup();
        void AccountRestore();
        void AccountDelete();
    }
}
