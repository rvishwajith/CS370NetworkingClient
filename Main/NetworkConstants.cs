/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This file contains all of the constants classes used for the client side of
 * the games' networking, such as the IP address and port numbers of the server.
 */

using System;

/*
 * The IP address for the server is set to the localhost IP address (127.0.0.1),
 * however this will change to an IP parsed from a public Github-hosted file in
 * the future.
 */
static class NetworkConstants
{
    public static string SERVER_IP_ADDRESS = "127.0.0.1";
}

/*
 * The port ranges for TCP ports serve different functions. The current TCP port
 * ranges are:
 * Authentication: 25600 to 25699. (100 ports)
 * Voice Chat: 25700 to 25899. (200 ports)
 * Text Messages: 25900 to 25999 (100 ports)
 * 
 * Additional port ranges will likely be added for important game events like
 * client sync/rollback, abilities, and player deaths.
 * 
 * These port ranges are temporary and are likely to change. In the future, the
 * client will read up-to-date port numbers from a public Github-hosted file.
 * 
 * The client will use a maximum of 3 TCP threads (voice chat, text chat, and
 * rollback) at any given time, so limiting the number of threads for the client
 * is not a concern.
 */
static class TCPConstants
{
    public static int AUTHENTICATION_STARTING_PORT = 25600;
    public static int AUTHENTICATION_PORT_RANGE = 100;

    public static int VOICE_CHAT_STARTING_PORT = 25700;
    public static int VOICE_CHAT_PORT_RANGE = 200;

    public static int TEXT_MESSAGE_STARTING_PORT = 25900;
    public static int TEXT_MESSAGE_PORT_RANGE = 100;
}

/*
 * The UDP ports will be assigned on each launch by the server before entering
 * a game session.
 * 
 * The temporary UDP port numbers are:
 * 25600 to 26000 (400 ports)
 * 
 * The client will only use 2 UDP ports, one to send information to the server
 * and one to recieve fast game event information from the server. This may
 * change in the future.
 */
static class UDPConstants
{
    public static int STARTING_PORT = 25600;
    public static int PORT_RANGE = 400;
}