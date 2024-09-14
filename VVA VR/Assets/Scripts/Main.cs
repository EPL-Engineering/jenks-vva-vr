﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using KLib;
using KLib.Network;

public class Main : MonoBehaviour
{
    public Camera camera;

    private bool _listenerReady = false;

    KTcpListener _listener = null;
    private bool _stopServer;
    private NetworkDiscoveryServer _discoveryServer;

    private string _address;
    private int _port = 4950;

    private void Start()
    {
        KLogger.Create(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Jenks", "Logs", "VVA-VR.txt"), 
            retainDays: 0.5f)
            .StartLogging();

        Debug.Log("App started");

        _address = NetworkUtils.FindServerAddress();

        _discoveryServer = gameObject.AddComponent<NetworkDiscoveryServer>();
        StartServer();
    }
    
    public void StartServer()
    {
        _stopServer = false;

        _listener = new KTcpListener();
        _listener.StartListener(_address, _port, false);

        StartCoroutine(TCPServer());
        _discoveryServer.StartReceiving("VVA VR", _address, _port);

        Debug.Log("Started TCP listener on " + _address + ":" + _port);
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
        Debug.Log("Stopped TCP listener");
    }

    void Return()
    {
        StopServer();
        Debug.Log("App closed");
#if !UNITY_EDITOR
        Application.Quit();
#endif
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
                break;

            case "Exit":
                _listener.SendAcknowledgement();
                exit = true;
                break;

            case "Test":
                _listener.SendAcknowledgement();
                StartCoroutine(RunTest(""));
                break;

            case "Abort":
                _listener.SendAcknowledgement();
                StartCoroutine(StopTest(""));
                break;

            default:
                _listener.SendAcknowledgement(false);
                break;
        }

        _listener.CloseTcpClient();

        if (exit) Return();
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
    IEnumerator RunTest(string command)
    {
        camera.backgroundColor = Color.white;

        yield break;
    }

    IEnumerator StopTest(string command)
    {
        camera.backgroundColor = Color.black;

        yield break;
    }

}
