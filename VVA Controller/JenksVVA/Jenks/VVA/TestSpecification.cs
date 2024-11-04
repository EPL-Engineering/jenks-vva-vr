
namespace Jenks.VVA
{
    public class TestSpecification
    {
        public Scene baselineScene = Scene.Black;
        public float baselineDuration_s = 30;
        public MotionSource motionSource = MotionSource.Internal;
        public MotionDirection motionDirection = MotionDirection.RollTilt;
        public float amplitude_degrees = 20f;
        public float gain = 1;
        public float frequency_Hz = 1f;
        public float duration_s = 30;

        public TestSpecification() { }

        public string ToLogString()
        {
            string log = "";
            log += $"BaselineScene={baselineScene}, ";
            log += $"BaselineDuration={baselineDuration_s}, ";
            log += $"MotionSource={motionSource}, ";

            if (motionSource == MotionSource.Internal)
            {
                log += $"Direction={motionDirection}, ";
                log += $"Amplitude={amplitude_degrees}, ";
                log += $"Gain={gain}, ";
                log += $"Frequency={frequency_Hz}, ";
            }
            else
            {
                log += $"Gain={gain}, ";
            }

            log += $"Duration={duration_s}";

            return log;
        }
    }
}