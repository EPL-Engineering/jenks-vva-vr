using System;
using System.Collections.Generic;
using System.IO;

using KLib.Utilities;

namespace Jenks.VVA
{
    public class TestSettings
    {
        public List<TestSpecification> controls = new List<TestSpecification>();
        public List<TestSpecification> tests = new List<TestSpecification>();
        public DotProperties dotProperties = new DotProperties();
        public WallProperties wallProperties = new WallProperties();
        public int filterLength = 5;

        public static TestSettings Restore()
        {
            TestSettings settings = null;
            if (File.Exists(FileLocation))
            {
                settings = KLib.KFile.XmlDeserialize<TestSettings>(FileLocation);
            }
            else
            {
                settings = new TestSettings();
                settings.Initialize();
            }
            return settings;
        }

        public void Save()
        {
            KLib.KFile.XmlSerialize(this, FileLocation);
        }

        private static string FileLocation
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Jenks", "VVA Controller Tests.xml");
            }
        }

        private void Initialize()
        {
            controls.Add(
                new TestSpecification
                {
                    scene = Scene.White,
                    motionSource = MotionSource.Internal,
                    amplitude_degrees = 0,
                });
            controls.Add(
                new TestSpecification
                {
                    scene = Scene.Dots,
                    motionSource = MotionSource.Internal,
                    frequency_Hz = 0.18f
                });
            controls.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                    motionSource = MotionSource.Internal,
                    frequency_Hz = 0.18f
                });

            tests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                    motionSource = MotionSource.UDP,
                    gain = 4.4848f,
                });
            tests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                    motionSource = MotionSource.UDP,
                    gain = 0.4226f,
                });

            tests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                    motionSource = MotionSource.UDP,
                    gain = 0.1304f,
                });
        }
    }
}