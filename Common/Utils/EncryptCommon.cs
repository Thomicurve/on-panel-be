
public class EncryptCommon
{
    
    public static string HashPassword(string password)
    {
        // Genera un hash seguro de la contraseña con una sal aleatoria
        return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
    }

    public static bool VerifyPassword(string enteredPassword, string hashedPassword)
    {
        // Verifica si la contraseña ingresada coincide con el hash almacenado
        return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
    }
}

