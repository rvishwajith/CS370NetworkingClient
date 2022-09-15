/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * For now, the client only does the following, to test both the TCP and UDP
 * connections:
 * 
 * 1. Await account credential input (username for now) to connect to the
 * server via TCP.
 * 
 * 2. Connect to the server and send the authentication credentials within the
 * time limit to not get auto disconnected.
 * 
 * 3. Recieve a TCP authentication result for either:
 * Approval (if the username/email exists and the password matches in the
 * server's database)
 * 
 * 4. If the authentication request is approved, wait for user input and send it
 * in as UDP data.
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class NetworkClient
{
    public NetworkClient()
    {
        Console.WriteLine("Created the networking client.");
    }

    /* Authentication Process:
     * 
     * - Create the TCPClient.
     * - Read in the login information (email or username and the password) as a
     * string array of authentication credentials.
     * - Validate the length and format of the credentials.
     * - Attempt to connect to the server and write the credentials to the
     * stream. If the connection fails, display an error message.
     * - Wait for a server response to validate the credentials.
     * - If validation fails, display the result and the number of remaining
     * attempts for this compiuter and/or the timeout, then re-prompt the user.
     * - If the device was successfully authenticated, request all of the user
     * data that the client has access to and begin sending UDP packets.
     */
    public void StartAuthentication()
    {
        var authenticationClient = new TcpClient();
        var serverIP = IPAddress.Parse(NetworkConstants.SERVER_IP_ADDRESS);

        authenticationClient.Connect(, TCPConstants.AUTHENTICATION_STARTING_PORT);
    }
}