namespace UserRegisteration.HashPassword
{
    public interface IHashPass
    {
        void createHashPassword(string password, out byte[] passswordHash, out byte[] passwordSlot);

        bool verifyPassword(string password, byte[] passwordHash, byte[] passwordSlot);
    }
}
