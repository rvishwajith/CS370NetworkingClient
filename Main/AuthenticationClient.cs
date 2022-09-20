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

    /* Sustained Authentication Startup:
     * Used for cases where the user wants to remember their account and skip
     * the login process completely.
     * 1. Checks if the device has been authenticated by searching for
     * the local authentication key and corresponding username/email.
     * 2. If no authentication key could be found or the data is not properly
     * formatted, go through the normal authentication process.
     * 3. If it is formatted, validate the authentication with the server.
     * 4. If the validation fails, go through the normal authentication process.
     * 5. If properly validated, skip the login and go to the launch page. */
    public bool IsDeviceAuthenticated()
    {
        // Check device for username and auth key by searching files.
        // Validate with the server.
        return false;
    }

    /* Device Authentication Main Method:
     * This is the method for running the authentication process if the device 
     * is not already authenticated using sustained authentication. Called on
     * startup.
     */
    public void AuthenticateDevice()
    {
        Console.WriteLine("LOGIN OR REGISTER FOR ACCOUNT");
        string option = GetAuthenticationOption();

        if (option == "UPWD")
        {
            Console.WriteLine("\nLOGIN WITH USERNAME & PASSWORD");
            AuthenticateWithUsernameAndPassword();
        }
        else if (option == "EPWD")
        {
            Console.WriteLine("\nLOGIN WITH EMAIL & PASSWORD");
            AuthenticateWithEmailAndPassword();
        }
        else if (option == "QR")
        {
            Console.WriteLine("\nLOGIN WITH QR CODE");
            AuthenticateWithEmailAndPassword();
        }
        else if (option == "SIGNUP")
        {
            Console.WriteLine("\nREGISTER FOR NEW ACCOUNT");
            Register();
        }
        else { Console.WriteLine("\nINVALID SELECTION Exiting authentication loop."); }
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
        Console.Write("\nChoose one of the following options:" +
            "\n1. Username & Password" +
            "\n2. Email Address & Password" +
            "\n3. QR Code (Mobile App)" +
            "\n4. Register for a new account." +
            "\n\nEnter an option: ");

        string[] options = { "UPWD", "EPWD", "QR", "SIGNUP" };
        var option = int.Parse(Console.ReadLine() + "");
        return options[option - 1];
    }

    /* Part 2 of Authentication (Method 1 - Username):
     * 1. Let the user enter a username, username tag, and password.
     * 2. Validate the credentials locally. */
    public void AuthenticateWithUsernameAndPassword()
    {
        Console.WriteLine("\nStep 1: Username" +
            "\nRules:" +
            "\n2. 2 <= Length <= 32" +
            "\n1. Only letters and numbers" +
            "\nEnter your username:");
        var username = Console.ReadLine();

        Console.WriteLine("\nStep 2: Username Tag" +
            "\nRules:" +
            "\n1. 2 <= Length <= 6" +
            "\n2. Only letters and numbers." +
            "\nEnter your password: ");
        var userTag = Console.ReadLine();

        Console.WriteLine("\nStep 3: Password" +
            "\nRules:" +
            "\n1. 6 <= Length <= 64" +
            "\n2. At least 1 uppercase and 1 lowercase letter." +
            "\n3. At least 1 number." +
            "\nAt least 1 special character." +
            "\nEnter your password: ");
        var password = Console.ReadLine();

        var credentialData = "<UPWD," + username + "," + userTag + "," + password + ">";
        Console.WriteLine("\nFinal Request:\n" + credentialData);
    }

    /* Part 2 of Authentication (Method 1 - Username):
     * 1. Let the user enter an email address and password.
     * 2. Validate the credentials locally. */
    public void AuthenticateWithEmailAndPassword()
    {
        Console.WriteLine("\nStep 1: Email Address" +
            "\nRules:" +
            "\n1. Address <= 64 characters" +
            "\n2. Domain <= 255 characters" +
            "\nEnter your email address:");
        var email = Console.ReadLine();

        Console.WriteLine("\nStep 2: Password" +
            "\nRules:" +
            "\n1. 6 <= Length <= 64" +
            "\n2. At least 1 uppercase and 1 lowercase letter." +
            "\n3. At least 1 number." +
            "\nAt least 1 special character." +
            "\nEnter your password: ");
        var password = Console.ReadLine();

        var credentialData = "<EWPD," + email + "," + password + ">";
        Console.WriteLine("\nFinal Authentication Request:\n" + credentialData);
    }

    /* Part 1 of Account Creation:
     * 1. Have the user enter their email address.
     * 2. Have the user choose a password for their account.
     * 3. Have the user confirm their password.
     * 4. Validate their credentials. */
    public void Register()
    {
        Console.WriteLine("\nREGISTER FOR A NEW ACCOUNT");

        Console.WriteLine("\nStep 1: Email Address" +
            "\nRules:" +
            "\n1. Address <= 64 characters" +
            "\n2. Domain <= 255 characters" +
            "\nEnter your email address:");
        var email = Console.ReadLine();

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


