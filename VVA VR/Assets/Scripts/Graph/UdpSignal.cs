using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UdpSignal : MonoBehaviour
{
    public int port;
    private IPEndPoint sender;
    private UdpClient client;
    private Thread networkThread;

    private byte[] receivedData;
    private string dataString;
    private string[] data;
    public float[] signalData = new float[3];

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

    }

    private void FixedUpdate()
    {
        ReceiveData();
    }

    public void ReceiveData()
    {
        if (client.Available > 0)
        {
            receivedData = client.Receive(ref sender);
            dataString = Encoding.ASCII.GetString(receivedData);
            Debug.Log("Recieved data: " + Encoding.ASCII.GetString(receivedData));
            data = dataString.Split('$');

            int i = 0;
            print(data[0]);
            foreach (string d in data)
            {

                //if( i == 0)
                //{ 
                //    print(d);
                //}
                signalData[i] = float.Parse(d);
                i++;
            }
        }
    }
}