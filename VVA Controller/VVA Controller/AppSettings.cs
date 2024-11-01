using System;
using System.Drawing;
using System.IO;

using KLib;

namespace VVA_Controller
{
    public class AppSettings
    {
        public Point controllerLocation = new Point(-1, -1);
        public Point vrLocation = new Point(-1, -1);

        public static AppSettings Restore()
        {
            AppSettings settings = null;
            if (File.Exists(FileLocation))
            {
                settings = KFile.XmlDeserialize<AppSettings>(FileLocation);
            }
            else
            {
                settings = new AppSettings();
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
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Jenks", "VVA Controller State.xml");
            }
        }

    }
}
