using ProtoBuf;

namespace Jenks.VVA
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class TestSpecification
    {
        [ProtoMember(1, IsRequired = true)]
        public Scene scene = Scene.Black;

        [ProtoMember(2, IsRequired = true)]
        public MotionSource motionSource = MotionSource.None;

        [ProtoMember(3, IsRequired = true)]
        public MotionDirection motionDirection = MotionDirection.RollTilt;

        [ProtoMember(4, IsRequired = true)]
        public float motionAmplitude = 20f;

        [ProtoMember(5, IsRequired = true)]
        public float motionVelocity = 1f;

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

            if (motionSource != MotionSource.None)
            {

            }

            log += $"Duration={duration_s}";

            return log;
        }
    }
}