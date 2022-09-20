/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This class is used to check the device's authentication status upon startup
 * as well as run other account managament steps such as signing in and
 * registering for a new account if necessary.
 * 
 * This class currently manages input for user credentials as well, however this
 * will be different when porting to Unity, because that will be triggered from
 * Unity's UI event system instead.
 */

using System;

public class AuthenticationClient
{
    public AuthenticationClient() { }

    /* Checks if the device has already been authenticated for cases where the
     * user wants to remember their account (usually personal computers). The
     * user's account password should not be stored, instead a device-specific
     * password should be stored locally. */
    public bool IsDeviceAuthenticated() { return false; }

    /* Begins the authentication or signup process for a device running
     * the desktop client. */
    public void Authenticate()
    {
        string option = GetAuthenticationOption();
        if (option == "UPWD" || option == "EPWD")
        {
            AuthenticateWithEmailAndPassword(option.ToLower());
        }
        else if (option == "Register")
        {
            Register();
        }
    }

    /* Part 1 of Authentication:
     * 1. Let the user choose the login method they want. Options are:
     *    Username & Password
     *    Email & Password
     *    QR Code
     *    Register for an Account
     * 2. For options 1 - 3: proceed to Part 2 of Authentication.
     * 3. For option 4: Proceed to Part 1 of Account Creation. */
    public string GetAuthenticationOption()
    {
        Console.Write("LOGIN & REGISTRATION" +
            "\n1. Username & Password" +
            "\n2. Email Address & Password" +
            "\n3. QR Code (Mobile App)" +
            "\n4. Register for a new account." +
            "\nEnter an option: ");

        string[] options = { "UPWD", "EPWD", "QR", "REGISTER" };
        var option = int.Parse(Console.ReadLine());
        return options[option - 1];
    }

    /* Part 2 of Authentication (Method 1 - Username):
     * 1. Let the user enter the appropriate credentials for their preferred
     * login method.
     * 2. Validate the credentials locally.
     * 3. Proceed to Part 3.
     */
    public void AuthenticateWithEmailAndPassword()
    {
        string authType = option == "UPWD" ? "username" : "email address";
        Console.WriteLine("\nLOGIN WITH " + authType.ToUpper() + " & PASSWORD");

        Console.Write("Enter your " + authType + ": ");
        var credential = Console.ReadLine();

        Console.Write("Enter your password: ");
        var password = Console.ReadLine();

        var requestOutput = "<" + option + ", " + credential + ", " + password + ">";
        Console.WriteLine("\nFinal Request:\n" + requestOutput);
    }

    /* Part 2 of Authentication (Method 2 - Email):
     * 1. Let the user enter the appropriate credentials for their preferred
     * login method.
     * 2. Validate the credentials locally.
     * 3. Proceed to Part 3.
     */
    public void AuthenticateWithEmailAndPassword()
    {
        string authType = option == "UPWD" ? "username" : "email address";
        Console.WriteLine("\nLOGIN WITH " + authType.ToUpper() + " & PASSWORD");

        Console.Write("Enter your " + authType + ": ");
        var credential = Console.ReadLine();

        Console.Write("Enter your password: ");
        var password = Console.ReadLine();

        var requestOutput = "<" + option + ", " + credential + ", " + password + ">";
        Console.WriteLine("\nFinal Request:\n" + requestOutput);
    }

    /* Part 1 of Account Creation:
     * 1. Have the user enter their email address.
     * 2. Have the user choose a password for their account.
     * 3. Have the user confirm their password. */
    public void Register()
    {
        Console.WriteLine("\nREGISTER FOR A NEW ACCOUNT");

        Console.Write("\nStep 1: Email Address" +
            "\nRules:" +
            "\n1. Address <= 64 characters" +
            "\n2. Domain <= 255 characters" +
            "\nEnter your email address:");
        var emailAddress = Console.ReadLine();

        Console.WriteLine("\nStep 2: Password" +
            "\nRules:" +
            "\n1. 6 <= Length <= 64" +
            "\n2. At least 1 uppercase and 1 lowercase letter." +
            "\n3. At least 1 number." +
            "\nAt least 1 special character." +
            "\nChoose a password: ");
        var password = Console.ReadLine();

        Console.WriteLine("\nStep 3: Confirm Password" +
            "\n1. All step 2 requirements." +
            "\n2. Must match previous password (case-sensitive)" +
            "\nConfirm your password: ");
        var confirmationPassword = Console.ReadLine();
    }
}


