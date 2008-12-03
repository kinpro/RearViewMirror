/*
 * RearViewMirror - Sumit Khanna 
 * http://penguindreams.org
 * 
 * License: GNU GPLv3 - Free to Distribute so long as any 
 *   modifications are released for free as well
 * 
 * Based on work by Andrew Kirillov found at the following address:
 * http://www.codeproject.com/KB/audio-video/Motion_Detection.aspx
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using MJPEGServer;
using motion;


namespace RearViewMirror
{

    public partial class SystemTray : Form
    {

        private StringCollection recentURLs;

        private const int RECENT_URL_LIMIT = 10;

        private ArrayList sources;

        private OptionsForm options;

        //Video Server variables

        private VideoServer videoServer;

        private ServerConnections connectionsWindow;

        private const string DONATE_URL = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=1282813";

        public SystemTray()
        {
            InitializeComponent();
            System.Windows.Forms.Application.EnableVisualStyles(); //XP style
            this.Resize += SystemTray_Resize;

            Updater.checkForUpdates();

            //Next Release
            //options = new OptionsForm(null);

            //load and start all video sources which were started previously
            VideoSource[] loadSources = Properties.Settings.Default.videoSources;
            sources = (loadSources != null) ? new ArrayList(loadSources) : new ArrayList();
            foreach(VideoSource i in sources) {
                if (i.SaveState == VideoSource.CameraState.Started)
                {
                    i.startCamera();
                }
            }

            //previous URLs for MJPEG streams
            recentURLs = Properties.Settings.Default.recentURLs;
            if (recentURLs == null) { recentURLs = new StringCollection(); }

            //video server
            videoServer = VideoServer.Instance;
            videoServer.Port = Properties.Settings.Default.serverPort;
            connectionsWindow = new ServerConnections(videoServer);

            //load previous server running state
            if (Properties.Settings.Default.serverRunning)
            {
                videoServer.startServer();
            }

            //load global stickey
            showAllToolStripMenuItem.Checked = Properties.Settings.Default.showAll;
            foreach (VideoSource s in sources)
            {
                s.setViewerGlobalStickey(showAllToolStripMenuItem.Checked);
            }

        }
            

        private void SystemTray_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        /// <summary>
        /// Single Mouse click on the tray icon shows all viewers
        /// </summary>
        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 0)
            {
               showAllToolStripMenuItem_Click(sender, e);
            }
        }

        /// <summary>
        /// Camera wants to be removed
        /// </summary>
        /// <param name="source">Video Source to remove</param>
        void r_RemoveSelected(object source)
        {
            VideoSource s = (VideoSource)source;            
            s.stopCamera();
            sources.Remove(source);
        }



        #region Video Device Selection SubMenu Events


        private bool isValidSourceName(String str)
        {
            //no duplicates
            foreach (VideoSource v in sources)
            {
                if (v.Name == str) { return false; }
            }

            //must be alphanumeric
            Regex regexAlphaNum = new Regex("[^a-zA-Z0-9]");
            return !regexAlphaNum.IsMatch(str);
        }

        private String showGetSourceNameBox()
        {
            while (true)
            {
                String strResponse = Microsoft.VisualBasic.Interaction.InputBox(
                        "What would you like to name this video source?", "RearViewMirror : Source Name", "", 100, 100);
                if (strResponse.Equals(""))
                {
                    //this is the worst way to determine if they clicked canceled
                    //I need to replace that crappy VisualBasic.Interaction box with
                    //a more useful widget
                    return null;
                }
                if (strResponse != null && !strResponse.Trim().Equals("") && isValidSourceName(strResponse))
                {
                    return strResponse;
                }
                else
                {
                    MessageBox.Show("Names must be unique and can only contain letters and numbers with no spaces", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureDeviceForm form = new CaptureDeviceForm();
            form.StartPosition = FormStartPosition.CenterScreen;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // create video source
                VideoCaptureDevice c = new VideoCaptureDevice();
                c.Source = form.Device;

                String sourceName = showGetSourceNameBox();
                if (sourceName != null) //user didn't cancel
                {
                    VideoSource r = new VideoSource(sourceName, c);
                    sources.Add(r);
                    r.RemoveSelected += new VideoSource.RemoveEventHandler(r_RemoveSelected);
                    sourcesToolStripMenuItem.DropDown.Items.Add(r.ContextMenu);
                    r.startCamera(); //start camera by default
                }
            }
        }

        private void mjpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            URLForm form = new URLForm();
            form.Description = "Enter URL of an updating JPEG from a web camera";

            //Load recent URLs
            String[] urls = new String[recentURLs.Count];
            recentURLs.CopyTo(urls, 0);
            form.URLs = urls;

            form.StartPosition = FormStartPosition.CenterScreen;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                //remove existing item (so it will be placed at top of list)
                if (recentURLs.Contains(form.URL))
                {
                    recentURLs.Remove(form.URL);
                }
                //update recent URLs
                if (recentURLs.Count == RECENT_URL_LIMIT)
                {
                    recentURLs.RemoveAt(RECENT_URL_LIMIT - 1);
                }
                recentURLs.Add(form.URL);

                //open the stream
                String sourceName = showGetSourceNameBox();
                if (sourceName != null) //user didn't select cancel
                {
                    MJPEGStream s = new MJPEGStream();
                    s.Source = form.URL;
                    VideoSource v = new VideoSource(sourceName, s);
                    sources.Add(v);
                    v.RemoveSelected += new VideoSource.RemoveEventHandler(r_RemoveSelected);
                    v.startCamera(); //start camera by default
                }                
            }
        }

        #endregion

        #region Main TrayIcon Menu Events


        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.ShowDialog();
        }



        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(DONATE_URL);
            Help.ShowHelp(this,DONATE_URL);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //save our settings
            Properties.Settings.Default.videoSources = (VideoSource[]) sources.ToArray(typeof(VideoSource));
            Properties.Settings.Default.serverPort = videoServer.Port;
            Properties.Settings.Default.recentURLs = recentURLs;
            Properties.Settings.Default.serverRunning = (videoServer.State == VideoServer.ServerState.STARTED);
            Properties.Settings.Default.showAll = showAllToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();

            //stop the server
            videoServer.stopServer();

            //stop the camera(s)
            foreach (VideoSource v in sources)
            {
                v.SaveState = v.CurrentState; //save the running state
                //this may cause lockups and may be unnescessary. 
                v.stopCamera();
            }

            Application.Exit();

        }


        private void trayContextMenu_Opening(object sender, CancelEventArgs e)
        {
            //refresh video sources
            sourcesToolStripMenuItem.DropDown.Items.Clear();
            if (sources.Count == 0)
            {
                ToolStripMenuItem blank = new ToolStripMenuItem("(none)");
                blank.Enabled = false;
                sourcesToolStripMenuItem.DropDown.Items.Add(blank);
            }

            foreach (VideoSource v in sources)
            {
                sourcesToolStripMenuItem.DropDown.Items.Add(v.ContextMenu);
                v.updateContextMenu();
            }

            //refresh server settings
            portToolStripMenuItem.Text = "Port: " + videoServer.Port;
            connectionsToolStripMenuItem.Text = "Connections: " + videoServer.ConnectedUsers.Length;
            if (videoServer.State == VideoServer.ServerState.STOPPED)
            {
                toggleServerToolStripMenuItem.Text = "Start Server";
                portToolStripMenuItem.Enabled = true;
                connectionsToolStripMenuItem.Enabled = false;
                cameraURLsToolStripMenuItem.Enabled = false;
            }
            else if (videoServer.State == VideoServer.ServerState.STARTED)
            {
                toggleServerToolStripMenuItem.Text = "Stop Server";
                portToolStripMenuItem.Enabled = false;
                connectionsToolStripMenuItem.Enabled = true;
                cameraURLsToolStripMenuItem.Enabled = true;
            }

        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAllToolStripMenuItem.Checked = !showAllToolStripMenuItem.Checked;
            foreach (VideoSource s in sources)
            {
                s.setViewerGlobalStickey(showAllToolStripMenuItem.Checked);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //next release
            //options.Show();
        }

        #endregion

        #region Server SubMenu Events

        private void toggleServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoServer.State == VideoServer.ServerState.STOPPED)
            {
                try
                {
                    videoServer.startServer();
                }
                catch (InvalidServerStateException se)
                {
                    MessageBox.Show(se.Message, "Could not Start Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (videoServer.State == VideoServer.ServerState.STARTED)
            {
                videoServer.stopServer();
            }
        }

        private void portToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string boxPort = videoServer.Port.ToString();
            bool invalid = true;

            while (invalid)
            {
                //TODO: Remove this and replace with a real C# Form / remove VB reference
                string strResponse = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter Server Port", "RearViewMirror : Server Port", boxPort, 100, 100);

                //empty string means cancel was clicked
                if (strResponse.Equals("")) { invalid = false; continue; }

                try
                {                    
                    videoServer.Port = (Convert.ToInt32(strResponse));
                    invalid = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Port Number", "Error: Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void connectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionsWindow.Show();
        }

        private void cameraURLsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Video Server URLs:\n\n";
            string myHostName = System.Net.Dns.GetHostName();
            foreach(VideoSource s in sources) {
                String url = "http://" + myHostName + ":" + videoServer.Port + "/" + s.Name;
                text += url + "\n";
            }
            MessageBox.Show(text, "Video Server URLs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion





    }
}