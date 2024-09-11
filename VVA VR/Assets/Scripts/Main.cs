using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using KLib.Network;

public class Main : MonoBehaviour
{
    private bool _listenerReady = false;

    //Sockets.KTcpClient _client;
    KTCPListener _listener = null;
    private bool _stopServer;
    private NetworkDiscoveryServer _discoveryServer;

    private string _address;
    private int _port = 4950;


    private void Start()
    {
        _address = NetworkUtils.FindServerAddress();

        _discoveryServer = gameObject.AddComponent<NetworkDiscoveryServer>();
        StartServer();
    }
    
    public void StartServer()
    {
        _stopServer = false;

        _listener = new KTCPListener();
        Debug.Log(_address);
        _listener.StartListener(_address, _port, false);

        StartCoroutine(TCPServer());
        _discoveryServer.StartReceiving("VVA VR", _address, _port);

        Debug.Log("started TCP listener on " + _address + ":" + _port);
    }
    

    public void StopServer()
    {
        _stopServer = true;
        if (_listener != null)
        {
            _listener.CloseListener();
            _listener = null;
        }

        _discoveryServer.StopReceiving();
        Debug.Log("stopped TCP listener");
    }

    void OnDestroy()
    {
        StopServer();
    }

    IEnumerator TCPServer()
    {
        while (!_stopServer)
        {
            if (_listener.Pending())
            {
                ProcessMessage();
            }
            yield return null;
        }
    }

    void ProcessMessage()
    {
        bool exit = false;

        //TestState receivedTestState = null;
        bool result = true;

        _listener.AcceptTcpClient();

        string input = _listener.ReadStringFromInputStream();
        var parts = input.Split(new char[] { ':' });
        string command = parts[0];
        string data = null;
        if (parts.Length > 1)
        {
            data = parts[1];
        }

        Debug.Log("Command received: " + command);

        switch (command)
        {
            case "Ping":
                _listener.SendAcknowledgement();
                //_scene.RemoteIPAddress = data;
                //_scene.Ping();
                break;

            default:
                _listener.SendAcknowledgement(false);
                break;
        }

        _listener.CloseTcpClient();

        //if (exit) _scene.Return();
    }

   /*     private TestState ReceiveTestState()
        {
            TestState state = null;
            var bytes = _listener.ReadByteArrayFromInputStream();
            if (bytes != null)
            {
                state = Message.FromProtoBuf<TestState>(bytes);
            }

            return state;
        }
   
        private SpeechPupilConfiguration ReceivePupilSettings()
        {
            SpeechPupilConfiguration settings = null;
            var bytes = _listener.ReadByteArrayFromInputStream();
            if (bytes != null)
            {
                settings = Message.FromProtoBuf<SpeechPupilConfiguration>(bytes);
            }

            return settings;
        }

        private void SendTestStateResponse(TestState response)
        {
            if (response != null)
            {
                _listener.WriteByteArray(SRI.Messages.Message.ToProtoBuf(response));
            }
            else
            {
                _listener.SendAcknowledgement(false);
            }
        }
    */


}
