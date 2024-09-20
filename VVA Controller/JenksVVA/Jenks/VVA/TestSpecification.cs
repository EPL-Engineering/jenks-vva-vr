using ProtoBuf;

namespace Jenks.VVA
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class TestSpecification
    {
        [ProtoMember(1, IsRequired = true)]
        public Scene scene = Scene.Black;

        [ProtoMember(2, IsRequired = true)]
        public MotionDirection direction = MotionDirection.RollTilt;

        [ProtoMember(3, IsRequired = true)]
        public float gain = 1;

        [ProtoMember(4, IsRequired = true)]
        public float duration_s = 30;

        public TestSpecification() { }

        public string ToLogString()
        {
            string log = "";
            log += $"Scene={scene}, ";
            log += $"Direction={direction}, ";
            log += $"Gain={gain}, ";
            log += $"Duration={duration_s}";

            return log;
        }
    }
}