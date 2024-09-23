using System;


namespace Moog
{
    enum JoystickMsgId
    {
        jmiDataPacket = 0,      ///< Joystick --> Netburner
        jmiCommandPacket = 1,   ///< Netburner --> Joystick
        jmiEndMarker            ///< End marker - not a valid value!
    }

    public class JoystickHeader
    {
        public const uint CJoystickSync = 0xba1dface;
        public const uint CJoystickVersion = 1;

        public uint sync;
        public uint version;
        public uint msgType;
        public uint seqNumber;
    }

    public class JoystickDataPacket : JoystickHeader
    {
        public float joystickOutput;
        public float encoderAngle;
        public uint button;
        public uint resUint;

        private byte[] _byteArray;

        public int NumBytes { get { return _byteArray.Length; } }

        public JoystickDataPacket()
        {
            sync = CJoystickSync;
            version = CJoystickVersion;
            msgType = (uint) JoystickMsgId.jmiDataPacket;

            resUint = 0;

            seqNumber = 0;
            InitByteArray();
        }

        public byte[] GetPacketBytes(float joystickOutputIn, float encoderAngleIn, uint buttonIn)
        {
            this.joystickOutput = joystickOutputIn;
            this.encoderAngle = encoderAngleIn;
            this.button = buttonIn;
            seqNumber++;

            byte[] tmp = BitConverter.GetBytes(seqNumber);
            for (int k = 0; k < 4; k++) _byteArray[k + 12] = tmp[3 - k];
            tmp = BitConverter.GetBytes(joystickOutput);
            for (int k = 0; k < 4; k++) _byteArray[k + 16] = tmp[3 - k];
            tmp = BitConverter.GetBytes(encoderAngle);
            for (int k = 0; k < 4; k++) _byteArray[k + 20] = tmp[3 - k];
            tmp = BitConverter.GetBytes(button);
            for (int k = 0; k < 4; k++) _byteArray[k + 24] = tmp[3 - k];


            return _byteArray;
        }

        private void InitByteArray()
        {
            _byteArray = new byte[32];
            byte[] tmp = BitConverter.GetBytes(sync);
            for (int k = 0; k < 4; k++) _byteArray[k] = tmp[3 - k];
            tmp = BitConverter.GetBytes(version);
            for (int k = 0; k < 4; k++) _byteArray[k + 4] = tmp[3 - k];
            tmp = BitConverter.GetBytes(msgType);
            for (int k = 0; k < 4; k++) _byteArray[k + 8] = tmp[3 - k];
            tmp = BitConverter.GetBytes(seqNumber);
            for (int k = 0; k < 4; k++) _byteArray[k + 12] = tmp[3 - k];

            tmp = BitConverter.GetBytes(joystickOutput);
            for (int k = 0; k < 4; k++) _byteArray[k + 16] = tmp[3 - k];
            tmp = BitConverter.GetBytes(encoderAngle);
            for (int k = 0; k < 4; k++) _byteArray[k + 20] = tmp[3 - k];
            tmp = BitConverter.GetBytes(button);
            for (int k = 0; k < 4; k++) _byteArray[k + 24] = tmp[3 - k];
            tmp = BitConverter.GetBytes(resUint);
            for (int k = 0; k < 4; k++) _byteArray[k + 28] = tmp[3 - k];
        }
    }
}