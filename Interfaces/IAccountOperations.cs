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

    }
}
