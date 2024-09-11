using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using KLib.Network;

public class Main : MonoBehaviour
{

    //a true/false variable for connection status
    private bool _listenerReady = false;

    //Sockets.KTcpClient _client;
    //private Sockets.KTcpListener _listener = null;
    private bool _stopServer;
    private UDPMulticastServer _udpServer;
    private int _port = 4950;

    public static string ServerAddress { private set; get; }

    private void Start()
    {
        //NetworkUtils.FindServerAddress();
    }

    /*
        public void StartServer()
        {
            _scene = scene;
            _stopServer = false;

            Use = true;

            _listener = new Sockets.KTcpListener();
            _listener.StartListener(_port, false);

            StartCoroutine(TCPServer());
            _udpServer.StartReceiving("SRI", _port);

            Debug.Log("started SRI TCP listener");
        }
    */

    public void StopServer()
    {
        _stopServer = true;
        //if (_listener != null)
        //{
        //    _listener.CloseListener();
        //    _listener = null;
        //}

        _udpServer.StopReceiving();
        Debug.Log("stopped SRI TCP listener");
    }

    void OnDestroy()
    {
        StopServer();
    }

    IEnumerator TCPServer()
    {
        while (!_stopServer)
        {
            //if (_listener.Pending())
            //{
            //    //ProcessMessage();
            //}
            yield return null;
        }
    }

    /*
        void ProcessMessage()
        {
            bool exit = false;

            TestState receivedTestState = null;
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
                case "DoNextTrial":
                    _listener.SendAcknowledgement();
                    _scene.DoNextTrial();
                    break;

                case "Disconnect":
                    _listener.SendAcknowledgement();
                    _scene.Disconnect();
                    break;

                case "EndTest":
                    _listener.SendAcknowledgement();
                    _scene.EndTest();
                    break;

                case "GetResources":
                    var resources = _scene.EnumerateResources();
                    _listener.WriteByteArray(Message.ToProtoBuf(resources));
                    break;

                case "GetSubjectInfo":
                    var subjInfo = _scene.GetSubjectInfo();
                    _listener.WriteByteArray(Message.ToProtoBuf(subjInfo));
                    break;

                case "Ping":
                    _listener.SendAcknowledgement();
                    _scene.RemoteIPAddress = data;
                    _scene.Ping();
                    break;

                case "Play":
                    _listener.SendAcknowledgement();
                    _scene.PlayItem(int.Parse(data));
                    break;

                case "Return":
                    _listener.SendAcknowledgement();
                    exit = true;
                    break;

                case "RandomList":
                    receivedTestState = ReceiveTestState();
                    receivedTestState = _scene.InitializeRandomList(false);
                    SendTestStateResponse(receivedTestState);
                    break;

                case "SetLevels":
                    receivedTestState = ReceiveTestState();
                    _listener.SendAcknowledgement();
                    _scene.SetLevels(receivedTestState.level, receivedTestState.snr);
                    break;

                case "SetList":
                    receivedTestState = ReceiveTestState();
                    receivedTestState = _scene.InitializeList(receivedTestState.listNum, false);
                    SendTestStateResponse(receivedTestState);
                    break;

                case "SetMaskerState":
                    _listener.SendAcknowledgement();
                    _scene.SetMaskerState(bool.Parse(data));
                    break;

                case "SetPupilSettings":
                    var pupilSettings = ReceivePupilSettings();
                    _listener.SendAcknowledgement();
                    _scene.SetPupilSettings(pupilSettings);
                    break;

                case "SetTest":
                    receivedTestState = ReceiveTestState();
                    receivedTestState = _scene.InitializeTest(receivedTestState.testName);
                    SendTestStateResponse(receivedTestState);
                    break;

                case "SetTestSNRVector":
                    receivedTestState = ReceiveTestState();
                    result = _scene.SetTestLevels(receivedTestState.level, receivedTestState.testSNRs);
                    _listener.SendAcknowledgement(result);
                    break;

                case "ShowMessage":
                    _listener.SendAcknowledgement();
                    _scene.ShowMessage(data);
                    break;

                case "StartTest":
                    _listener.SendAcknowledgement();
                    _scene.StartTest(int.Parse(data));
                    break;

                default:
                    _listener.SendAcknowledgement(false);
                    break;
            }

            _listener.CloseTcpClient();

            if (exit) _scene.Return();
        }

        private TestState ReceiveTestState()
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
