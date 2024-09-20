using System;
using System.Collections.Generic;
using System.IO;

using KLib.Utilities;

namespace Jenks.VVA
{
    public class TestSettings
    {
        public List<ControlSpecification> controls = new List<ControlSpecification>();
        public List<TestSpecification> tests = new List<TestSpecification>();
        public DotProperties dotProperties = new DotProperties();
        public GratingProperties gratingProperties = new GratingProperties();
        public int filterLength = 5;

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
            controls.Add(
                new ControlSpecification
                {
                    scene = Scene.White,
                    frequencyHz = 0.03f
                });
            controls.Add(
                new ControlSpecification
                {
                    scene = Scene.Black,
                    frequencyHz = 0.1f
                });
            controls.Add(
                new ControlSpecification
                {
                    scene = Scene.Dots,
                    frequencyHz = 0.18f
                });

            tests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                });
            tests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                });

            tests.Add(
                new TestSpecification
                {
                    scene = Scene.Bars,
                });
        }
    }
}