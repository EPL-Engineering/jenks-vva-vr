using System;
using System.Drawing;
using System.IO;

using KLib.Utilities;

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
                settings = FileIO.XmlDeserialize<AppSettings>(FileLocation);
            }
            else
            {
                settings = new AppSettings();
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
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Jenks", "VVA Controller Settings.xml");
            }
        }

    }
}
