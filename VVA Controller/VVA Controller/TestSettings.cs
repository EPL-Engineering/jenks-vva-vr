using System;
using System.Collections.Generic;
using System.IO;

using KLib.Utilities;

namespace Jenks.VVA
{
    public class TestSettings
    {
        public List<TestSpecification> controlTests = new List<TestSpecification>();
        public List<TestSpecification> visionTests = new List<TestSpecification>();
        public List<TestSpecification> chairTests = new List<TestSpecification>();
        public DotProperties dotProperties = new DotProperties();
        public GratingProperties gratingProperties = new GratingProperties();

        public static TestSettings Restore()
        {
            TestSettings settings = null;
            if (File.Exists(FileLocation))
            {
                settings = FileIO.XmlDeserialize<TestSettings>(FileLocation);
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
            FileIO.XmlSerialize(this, FileLocation);
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
            controlTests.Add(
                new TestSpecification
                {
                    scene = Scene.White,
                    motionSource = MotionSource.None
                });
            controlTests.Add(
                new TestSpecification
                {
                    scene = Scene.Black,
                    motionSource = MotionSource.None
                });
            controlTests.Add(
                new TestSpecification
                {
                    scene = Scene.Dots,
                    motionSource = MotionSource.None
                });

            visionTests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                    motionSource = MotionSource.Vision,
                    motionVelocity = 1
                });
            visionTests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                    motionSource = MotionSource.Vision,
                    motionVelocity = 2
                });

            chairTests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                    motionSource = MotionSource.Chair
                });
        }
    }
}