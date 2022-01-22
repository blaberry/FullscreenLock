using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System;

namespace FullscreenLock
{
    public partial class Settings : Form
    {
        public Settings(FullscreenLock mainForm)
        {
            InitializeComponent();

            #region Whitelist
            InitWhiteListDataGrid();
            #endregion

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save all
            #region Whitelist
            Program.Settings_File.Instance.asWhitelist.Clear();
            foreach (DataGridViewRow row in dataGridViewWhitelist.Rows)
            {
                object oValue = row.Cells[0].Value;
                if (oValue != null)
                    Program.Settings_File.Instance.asWhitelist.Add(oValue.ToString());
            }
            #endregion

            Program.Settings_File.SaveLocal();
        }

        #region Whitelist methods
        public void InitWhiteListDataGrid()
        {
            foreach (string sProgramName in Program.Settings_File.Instance.asWhitelist)
                dataGridViewWhitelist.Rows.Add(sProgramName);
        }
        #endregion


        public class SettingsFile
        {
            public string LocalFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FullScreenLock.xml");
            
            private SettingsContent _settings = null;
            public SettingsContent Instance 
            {
                get {
                    if (_settings == null)
                        _settings = new SettingsContent();

                    return _settings;
                }

                private set { _settings = value; }
            }



            public SettingsFile()
            {
                LoadLocal();
            }

            public bool LoadLocal()
            {
                bool bRtn = true;
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SettingsContent));
                    SettingsContent localLoaded;
                    using (FileStream fs = new FileStream(LocalFile, FileMode.Open))
                        localLoaded = (SettingsContent) serializer.Deserialize(fs);

                    if (localLoaded == null)
                        throw new Exception();

                    _settings = localLoaded;


                } catch (Exception)
                {
                    bRtn = false;
                }

                return bRtn;
            }

            public bool SaveLocal()
            {
                bool bRtn = true;
                try
                {
                    if (File.Exists(LocalFile))
                        File.Delete(LocalFile);

                    XmlSerializer serializer = new XmlSerializer(typeof(SettingsContent));
                    using (FileStream fs = new FileStream(LocalFile, FileMode.Create))
                        serializer.Serialize(fs, Instance);
                }
                catch (Exception)
                {
                    bRtn = false;
                }

                return bRtn;
            }

            #region XML construct
            [XmlRoot("Settings")]
            public class SettingsContent
            {
                [XmlArray("Whitelist")]
                public List<string> asWhitelist { get; set; } = new List<string>();
            }
            #endregion
        }
    }
}
