using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class networkHost : MonoBehaviour
{
    //public string ip;
    public IPAddress hostaddress;

    public int port;
    public IPEndPoint sender;
    public UdpClient client;
    public Thread networkThread;

    public byte[] receivedData;
    public string dataString;

    public string[] data;

    bool hasClient = false;
    bool clientErrCalled = false;

    void Start()
    {
        try
        {
            client = new UdpClient(port);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }

        networkThread = new Thread(ReceiveData);
        networkThread.Start();
        receivedData = new byte[0];

        sender = new IPEndPoint(IPAddress.Any, 0);
    }

    void Update()
    {
        ReceiveData();
        if (!hasClient)
        {
            if (clientErrCalled == false)
            {
                Debug.Log("No client available. Waiting for client.");
                clientErrCalled = true;
            }
        }
        else
        {
            clientErrCalled = false;
            try
            {
                print(data[1]);
                print(data[2]);
                print(data[3]);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    public void ReceiveData()
    {
        if (client.Available > 0)
        {
            hasClient = true;
            receivedData = client.Receive(ref sender);
            dataString = Encoding.ASCII.GetString(receivedData);
            Debug.Log("Recieved data: " + Encoding.ASCII.GetString(receivedData));
            data = dataString.Split('$');
        } else {
            hasClient = false;
        }
    }
}