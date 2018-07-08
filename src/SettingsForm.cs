using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleExternalCheatCSGO.Settings;

namespace SimpleExternalCSGOCheat
{
    public partial class SettingsForm : Form
    {
        // LETS HAVE A COOL SETTINGS MENU!
        // heres the catch: you get aids by looking at it because its so fucking gay

        public SettingsForm()
        {
            InitializeComponent();
            Text = RandomString(32);
            comboBox1.SelectedIndex = 1;
            comboBox3.SelectedIndex = 0;
        }

        //doesnt work?? idk -- yes i know timer is disabled
        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = RandomString(32);
            label1.Text = SaintwareNext(label1.Text);
        }

        private string SaintwareNext(string current)
        {
            //hey dont judge me cunt :(

            switch(current)
            {
                case "saintware":
                    return "3aintware";
                case "3aintware":
                    return "s4intware";
                case "s4intware":
                    return "sa/ntware"; // honestly idk what to replace "i" with here
                case "sa/ntware":
                    return "sai#tware";
                case "sai#tware":
                    return "sain7ware";
                case "sain7ware":
                    return "saint^^are"; // its a flipped W? i guess?
                case "saint^^are":
                    return "saintw4re"; // reusing a character lol
                case "saintw4re":
                    return "saintwa2e";
                case "saintwa2e":
                    return "saintwar5";
                case "saintwar5":
                    return "saintware"; // end of loop
            }
            return "fuck off nigga"; // it should never get to this part but u get an error if this aint here
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefgijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        // FILTHY HACK FOR MOVING WINDOW YADA YADA
        // totally not pasted from stack overflow 100000% !!!!111oneone

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "FOV (" + trackBar1.Value + ")";
            WeaponConfig.flAimbotFov = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Smooth (" + trackBar2.Value + ")";
            WeaponConfig.flAimbotSmooth = trackBar2.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                WeaponConfig.bAimbotEnabled = true;
            else
                WeaponConfig.bAimbotEnabled = !true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                Config.bGlowEnabled = true;
            else
                Config.bGlowEnabled = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                Config.bGlowEnemy = true;
            else
                Config.bGlowEnemy = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
                Config.bGlowAlly = true;
            else
                Config.bGlowAlly = false;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            Config.bClanTagChangerEnabled = checkBox10.Checked; //oh lol
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            Config.MiscEnabled = checkBox9.Checked; //why didnt i do this before
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            WeaponConfig.bRCS = checkBox8.Checked;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Vertical (" + trackBar4.Value + ")";
            WeaponConfig.Vertical = trackBar4.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Horizontal (" + trackBar3.Value + ")";
            WeaponConfig.Horizontal = trackBar3.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.iClanTagChanger = comboBox1.SelectedIndex;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Config.bBhopEnabled = checkBox7.Checked;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            Config.bAutoAccept = checkBox11.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            WeaponConfig.bTargetOnGroundCheck = checkBox2.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            WeaponConfig.bVisibleCheck = checkBox3.Checked;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(50,50,50);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(100,100,100);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    Config.iGlowType = GlowType.Health;
                    break;
                case 1:
                    Config.iGlowType = GlowType.Color;
                    break;
                case 2:
                    Config.iGlowType = GlowType.Vis_Color;
                    break;
            }
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = (sender as Panel).BackColor;
            cd.FullOpen = true;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                switch ((sender as Panel).Name)
                {
                    case "panel9":
                        Config.bGlowEnemyColor = new SimpleExternalCheatCSGO.Structs.Color(cd.Color.R,cd.Color.G,cd.Color.B);
                        panel9.BackColor = cd.Color;
                        break;
                    case "panel8":
                        Config.bGlowAllyColor = new SimpleExternalCheatCSGO.Structs.Color(cd.Color.R, cd.Color.G, cd.Color.B);
                        panel8.BackColor = cd.Color;
                        break;
                    case "panel7":
                        Config.bGlowEnemyVisibleColor = new SimpleExternalCheatCSGO.Structs.Color(cd.Color.R, cd.Color.G, cd.Color.B);
                        panel7.BackColor = cd.Color;
                        break;
                    case "panel6":
                        Config.bGlowAllyVisibleColor = new SimpleExternalCheatCSGO.Structs.Color(cd.Color.R, cd.Color.G, cd.Color.B);
                        panel6.BackColor = cd.Color;
                        break;
                }
            }
            cd.Dispose();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            Config.bGlowWeapons = checkBox13.Checked;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            Config.bGlowBomb = checkBox12.Checked;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            Config.bInnerGlow = checkBox14.Checked;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            Config.bFullRender = checkBox15.Checked;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            Config.bShowRanks = checkBox16.Checked;
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            Config.bTriggerbotEnabled = checkBox17.Checked;
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            Config.bTriggerbotCheckWall = checkBox18.Checked;
        }
    }
}
