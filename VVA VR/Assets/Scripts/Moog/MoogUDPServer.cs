using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class MoogUDPServer : MonoBehaviour
{
    Thread _readThread = null;

    UdpClient _client;
    private int _port = 61557;

    private Moog.JoystickDataPacket _packet = new Moog.JoystickDataPacket();

    public float RollTilt { get; private set; } = 0;
    public float X { get; private set; } = 0;

    public void StartReceiving()
    {
        _client = new UdpClient(_port);
        _client.Client.ReceiveTimeout = 1000;

        // create thread for reading UDP messages
        _readThread = new Thread(new ThreadStart(ReceiveData));
        _readThread.IsBackground = true;

        _readThread.Start();
        Debug.Log("Started Moog UDP server thread on port " + _port);
    }

    public void StopReceiving()
    {
        StopThread();
    }

    // Stop reading UDP messages
    private void StopThread()
    {
        if (_readThread != null &&_readThread.IsAlive)
        {
            _readThread.Abort();
            _client.Close();
            Debug.Log("Stopped Moog UDP thread");
        }
    }

    private void OnDestroy()
    {
        StopThread();
    }

    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                // receive bytes
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, _port);
                byte[] data = _client.Receive(ref anyIP);

                // Note the minus sign: NKI and Unity have opposite conventions
                RollTilt = BitConverter.ToSingle(data, 0);
                X = BitConverter.ToSingle(data, 4);
            }
            catch (Exception ex)
            {
                //Debug.Log(ex.Message);
            }
        }
    }

}