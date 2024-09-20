using ProtoBuf;

namespace Jenks.VVA
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ControlSpecification
    {
        [ProtoMember(1, IsRequired = true)]
        public Scene scene = Scene.Black;

        [ProtoMember(2, IsRequired = true)]
        public MotionDirection motionDirection = MotionDirection.RollTilt;

        [ProtoMember(3, IsRequired = true)]
        public float amplitudeDegrees = 20f;

        [ProtoMember(4, IsRequired = true)]
        public float frequencyHz = 1f;

        [ProtoMember(5, IsRequired = true)]
        public float gain = 1;

        [ProtoMember(6, IsRequired = true)]
        public float duration_s = 30;

        public ControlSpecification() { }

        public string ToLogString()
        {
            string log = "";
            log += $"Scene={scene}, ";
            log += $"Direction={motionDirection}, ";
            log += $"Amplitude={amplitudeDegrees}, ";
            log += $"Velocity={frequencyHz}, ";
            log += $"Duration={duration_s}";

            return log;
        }
    }
}