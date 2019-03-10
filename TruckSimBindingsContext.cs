using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruckSimBindings {
	public class TruckSimBindingsContext : ApplicationContext {
		NotifyIcon notifyIcon = new NotifyIcon();
		Form1 configWindow = new Form1();

		public TruckSimBindingsContext() {
			MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
			MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

			notifyIcon.Text = "ControlScript";
			notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
			notifyIcon.Visible = true;
		}

		void ShowConfig(object sender, EventArgs e) {
			// If we are already showing the window meerly focus it.
			if (configWindow.Visible)
				configWindow.Focus();
			else
				configWindow.ShowDialog();
		}

		void Exit(object sender, EventArgs e) {
			// We must manually tidy up and remove the icon before we exit.
			// Otherwise it will be left behind until the user mouses over.
			notifyIcon.Visible = false;

			Application.Exit();
		}
	}
}
