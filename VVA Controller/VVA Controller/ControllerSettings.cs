using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using KLib;

namespace Jenks.VVA
{
    public class ControllerSettings
    {
        public List<Scene> baselineScenes;
        public List<MotionSource> motionSources;
        public List<MotionDirection> motionDirections;
        public List<LinkedParams> linkedParams;


        public float defaultAmplitude_degrees = 20;
        public float defaultBaselineDuration_s = 30;
        public DotProperties dotProperties = new DotProperties();
        public WallProperties wallProperties = new WallProperties();
        public int filterLength = 5;

        public static ControllerSettings Restore()
        {
            ControllerSettings settings = null;
            if (File.Exists(FileLocation))
            {
                settings = KFile.XmlDeserialize<ControllerSettings>(FileLocation);
            }
            else
            {
                settings = new ControllerSettings();
                settings.Initialize();
            }
            return settings;
        }

        public void Save()
        {
            KFile.XmlSerialize(this, FileLocation);
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
            baselineScenes = new List<Scene>(Enum.GetValues(typeof(Scene)).Cast<Scene>().ToList());
            motionSources = new List<MotionSource> { MotionSource.Internal };
            motionDirections = new List<MotionDirection> { MotionDirection.RollTilt };

            linkedParams = new List<LinkedParams>();
            linkedParams.Add(
                new LinkedParams
                {
                    frequency_Hz = 0.03f,
                    gain = 4.4848f,
                    duration_s = 30
                }
            );
            linkedParams.Add(
                new LinkedParams
                {
                    frequency_Hz = 0.10f,
                    gain = 0.4226f,
                    duration_s = 30
                }
            );
            linkedParams.Add(
                new LinkedParams
                {
                    frequency_Hz = 0.18f,
                    gain = 0.1304f,
                    duration_s = 30,
                    isActive = true
                }
            );
        }
    }
}