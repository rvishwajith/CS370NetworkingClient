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
 * Approval (if the username exists in the server's database)
 * 
 * 4. If the authentication request is approved, wait for user input and send it
 * in as UDP data.
 */

using System;
using System.Net.Sockets;
using System.Threading;

public class NetworkingClient
{
    public NetworkingClient()
    {

    }

    public void Start()
    {

    }

    public void Authenticate()
    {
        // 1. Read in username as credentials.
        // 1. Create TCPClient and connect to the server.
        // 2. Send authentication credentials.
        // 3. Await server response.
        // 4. 
    }
}