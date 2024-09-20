using System;
using UnityEngine;

using KLib.Jenks;

namespace TracingGame
{
    public class Vestibular
    {
        public bool active = false;
        //public string udpHost = "192.168.1.175";
        public int udpPort = 22123;
        public string udpHost = "127.0.0.1";
        //public int udpPort = 52247;
        public float maxRollSpeed = 5;
        public bool returnToHome = true;
        public float remainAtHome_s = 5;

        private JoystickDataPacket _joystickPacket;

        public Vestibular() { }

        public int NumBytes { get { return _joystickPacket.NumBytes; } }

        public void Initialize()
        {
            _joystickPacket = new JoystickDataPacket();
        }

        public byte[] GetPacketBytes(float joystickOutput, float encoderAngle, uint button)
        {
            joystickOutput *= Mathf.PI / 180f;
            encoderAngle *= Mathf.PI / 180f;
            return _joystickPacket.GetPacketBytes(joystickOutput, encoderAngle, button);
        }

    }
}