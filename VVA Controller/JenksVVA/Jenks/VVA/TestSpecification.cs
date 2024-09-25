using ProtoBuf;

namespace Jenks.VVA
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class TestSpecification
    {
        [ProtoMember(1, IsRequired = true)]
        public Scene scene = Scene.Black;

        [ProtoMember(2, IsRequired = true)]
        public MotionSource motionSource = MotionSource.Internal;

        [ProtoMember(3, IsRequired = true)]
        public MotionDirection motionDirection = MotionDirection.RollTilt;

        [ProtoMember(4, IsRequired = true)]
        public float amplitude_degrees = 20f;

        [ProtoMember(5, IsRequired = true)]
        public float frequency_Hz = 1f;

        [ProtoMember(6, IsRequired = true)]
        public float gain = 1;

        [ProtoMember(7, IsRequired = true)]
        public float duration_s = 30;

        public TestSpecification() { }

        public string ToLogString()
        {
            string log = "";
            log += $"Scene={scene}, ";
            log += $"MotionSource={motionSource}, ";

            if (motionSource == MotionSource.Internal)
            {
                log += $"Direction={motionDirection}, ";
                log += $"Amplitude={amplitude_degrees}, ";
                log += $"Frequency={frequency_Hz}, ";
            }

            log += $"Gain={gain}, ";
            log += $"Duration={duration_s}";

            return log;
        }
    }
}