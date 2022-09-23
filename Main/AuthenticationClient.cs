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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

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
        Console.WriteLine("LOGIN OR REGISTER");
        string option = "UPWD"; // GetAuthenticationOption();

        if (option == "UPWD")
        {
            Console.WriteLine("\nLOGIN - USERNAME & PASSWORD");
            AuthenticateWithUsernameAndPassword();
        }
        else if (option == "EPWD")
        {
            Console.WriteLine("\nLOGIN - EMAIL & PASSWORD");
            AuthenticateWithEmailAndPassword();
        }
        else if (option == "QR")
        {
            Console.WriteLine("\nLOGIN - QR CODE");
            AuthenticateWithEmailAndPassword();
        }
        else if (option == "SIGNUP")
        {
            Console.WriteLine("\nREGISTER FOR ACCOUNT");
            Register();
        }
        else { Console.WriteLine("\nINVALID"); }
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
            "\n1. Login with Username & Password" +
            "\n2. Login with Email Address & Password" +
            "\n3. Login with QR Code (Mobile App)" +
            "\n4. Register for a New Account" +
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
        Console.Write("\nStep 1: Username" +
            "\n1. 2 <= Length <= 32" +
            "\n2. Only letters and numbers" +
            "\n\nEnter your username: ");
        var username = "eggsvibe#7676"; //Console.ReadLine();

        /*
        Console.Write("\nStep 2: Username Tag" +
            "\n1. 2 <= Length <= 6" +
            "\n2. Only letters and numbers." +
            "\n\nEnter your username tag: ");
        var userTag = Console.ReadLine();
        */

        Console.Write("\nStep 3: Password" +
            "\n1. 6 <= Length <= 64" +
            "\n2. At least 1 uppercase and 1 lowercase letter." +
            "\n\nEnter your password: ");
        var password = "LebronJames"; // Console.ReadLine();

        var credentials = "UPWD " + username + " " + password;
        SendCredentials(credentials.Trim());
    }

    /* Send the credentials for authentication to the server and wait for a
     * validation response. */
    public void SendCredentials(string credentials)
    {
        Thread thread = new Thread(() =>
        {
            var credentialsData = Encoding.UTF8.GetBytes(credentials);
            var client = new TcpClient();
            client.Connect("127.0.0.1", 23761);

            var stream = client.GetStream();
            stream.Write(credentialsData, 0, credentialsData.Length);
            Console.WriteLine("\nSent:\n" + credentials);

            int maximumDataSize = 256;

            try
            {
                while (true)
                {
                    byte[] data = new byte[maximumDataSize];
                    var dataLength = stream.Read(data, 0, data.Length);
                    while (dataLength != 0)
                    {
                        var trimmedData = new byte[dataLength];
                        Array.Copy(data, trimmedData, dataLength);

                        var recievedEvent = Encoding.UTF8.GetString(trimmedData);
                        Console.WriteLine("Recieved: " + recievedEvent);

                        if (recievedEvent.Equals("Email2FACode"))
                        {
                            Console.Write("Enter email 2FA code: ");
                            var inputCode = "Email2FACode " + Console.ReadLine()!;
                            Console.WriteLine("\nSending code: " + inputCode);
                            stream.Write(Encoding.UTF8.GetBytes(inputCode), 0, inputCode.Length);
                        }

                        dataLength = 0;
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Disconnected from server.");
            }
        });
        //thread.IsBackground = true;
        thread.Start();
    }

    /* Part 2 of Authentication (Method 2 - Email):
     * 1. Let the user enter an email address and password.
     * 2. Validate the credentials locally. */
    public void AuthenticateWithEmailAndPassword()
    {
        Console.Write("\nStep 1: Email Address" +
            "\n1. Address <= 64 characters" +
            "\n2. Domain <= 255 characters" +
            "\n\nEnter your email address: ");
        var email = Console.ReadLine();

        Console.Write("\nStep 2: Password" +
            "\n1. 6 <= Length <= 64" +
            "\n2. At least 1 uppercase and 1 lowercase letter." +
            "\n3. At least 1 number." +
            "\nAt least 1 special character." +
            "\n\nEnter your password: ");
        var password = Console.ReadLine();

        var credentialData = "<EWPD," + email + "," + password + ">";
        Console.WriteLine("\nFinal Authentication Request:\n" + credentialData);
    }

    /* Part 2 of Authentication (Method 3 - QR):
     * 1. Generate a QR code with the device information.
     * 2. Have the user scan it with the mobile app. */
    public void AuthenticateWithQRCode()
    {
        Console.Write("\nStep 1: Email Address" +
            "\n1. Address <= 64 characters" +
            "\n2. Domain <= 255 characters" +
            "\n\nEnter your email address: ");
        var email = Console.ReadLine();

        Console.Write("\nStep 2: Password" +
            "\n1. 6 <= Length <= 64" +
            "\n2. At least 1 uppercase and 1 lowercase letter." +
            "\n3. At least 1 number." +
            "\nAt least 1 special character." +
            "\n\nEnter your password: ");
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

        Console.Write("\nStep 1: Email Address" +
            "\n1. Address <= 64 characters" +
            "\n2. Domain <= 255 characters" +
            "\nEnter your email address: ");
        var email = Console.ReadLine();

        Console.Write("\nStep 2: Password" +
            "\n1. 6 <= Length <= 64" +
            "\n2. At least 1 uppercase and 1 lowercase letter." +
            "\n\nChoose a password: ");
        var password = Console.ReadLine();

        Console.Write("\nStep 3: Confirm Password" +
            "\n1. All step 2 requirements." +
            "\n2. Must match previous password (case-sensitive)" +
            "\n\nConfirm your password: ");
        var confirmationPassword = Console.ReadLine();
    }
}


