using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;


namespace BullseyeProject
{
    static class Program
    {
        //Timer fields to AutoLogout
        public static Timer IdleTimer = new Timer();
        const int MinuteMicroseconds = 600000; //For 5s set to 5000
        static Login login = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Apply auto logout timer
            LeaveIdleMessageFilter limf = new LeaveIdleMessageFilter();
            Application.AddMessageFilter(limf);
            Application.Idle += new EventHandler(Application_Idle);
            IdleTimer.Interval = MinuteMicroseconds;
            IdleTimer.Tick += TimeDone;
            IdleTimer.Start();
            login = new Login();


            Application.Run(login);


            Application.Idle -= new EventHandler(Application_Idle);
        }

        //Restart the clock every time
        static private void Application_Idle(Object sender, EventArgs e)
        {
            if (!IdleTimer.Enabled)
                IdleTimer.Start();
        }

        //When the timer reach the proper amount of time, the function triggers the current form to close, except the Login page
        static private void TimeDone(object sender, EventArgs e)
        {

            //IdleTimer.Stop();

            Form currentForm = Form.ActiveForm;
            if (currentForm != null)
            {
                if (currentForm.Name != "Login")
                {
                    currentForm.Close();

                    MessageBox.Show("The system has being idle for 10 minutes. The current user will be logoff");
                }
            }


        }
    }


    //Detect any movement whitin the application
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class LeaveIdleMessageFilter : IMessageFilter
    {
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int WM_NCLBUTTONUP = 0x00A2;
        const int WM_NCRBUTTONDOWN = 0x00A4;
        const int WM_NCRBUTTONUP = 0x00A5;
        const int WM_NCMBUTTONDOWN = 0x00A7;
        const int WM_NCMBUTTONUP = 0x00A8;
        const int WM_NCXBUTTONDOWN = 0x00AB;
        const int WM_NCXBUTTONUP = 0x00AC;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_MBUTTONDOWN = 0x0207;
        const int WM_MBUTTONUP = 0x0208;
        const int WM_XBUTTONDOWN = 0x020B;
        const int WM_XBUTTONUP = 0x020C;

        // The Messages array must be sorted due to use of Array.BinarySearch
        static int[] Messages = new int[] {WM_NCLBUTTONDOWN,
            WM_NCLBUTTONUP, WM_NCRBUTTONDOWN, WM_NCRBUTTONUP, WM_NCMBUTTONDOWN,
            WM_NCMBUTTONUP, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, WM_KEYDOWN, WM_KEYUP,
            WM_LBUTTONDOWN, WM_LBUTTONUP, WM_RBUTTONDOWN, WM_RBUTTONUP,
            WM_MBUTTONDOWN, WM_MBUTTONUP, WM_XBUTTONDOWN, WM_XBUTTONUP};

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)  // mouse move is high volume
                return false;
            if (!Program.IdleTimer.Enabled)     // idling?
                return false;           // No
            if (Array.BinarySearch(Messages, m.Msg) >= 0)
                Program.IdleTimer.Stop();
            return false;
        }
    }

}
