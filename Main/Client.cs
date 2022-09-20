/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the overall managing class for the client side of the game which is
 * called from the runner class. This class manages all of the other runtime
 * classes, such as the networking and authentication systems.
 * 
 * This class currently manages input for user credentials as well, however this
 * will be different when porting to Unity, because that will be triggered from
 * Unity's UI event system instead.
 */

using System;

public class Client
{
    NetworkClient netClient;
    AuthenticationClient authClient;

    /* Create all the necessary clients immediately on startup. */
    public Client()
    {
        netClient = new NetworkClient();
        authClient = new AuthenticationClient();
    }

    /* Substitute for Start() in a Unity script. Does the following on startup:
     * 1. Checks the user's authentication status.
     * 2. If they have not been authenticated yet or the cached credentials fail
     * the server validation process, then start the authentication or
     * registration process.
     * 3. If they are authenticated already, check for any necessary updates to
     * the game.
     * 4. If the user is authenticated already and the game version is up to date
     * and stable, allow the user to launch the game. */
    public void Start()
    {
        if (!authClient.IsDeviceAuthenticated()) { authClient.Authenticate(); }
        Console.WriteLine("Finished running.");
    }
}