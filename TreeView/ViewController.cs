using System;

using UIKit;

namespace TreeView
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
      var items = new TreeItem[] {
        new TreeItem() {
          Text = "A",
          Level = 1,
          Icon = "Folder",
          SelectedIcon = "FolderSelected",
          HighlightedIcon = "FolderSelected",
          IsHaveChildNode = true,
          IsAllowSelect = true,
          Item = "String"
        },
        new TreeItem() {
          Text = "A",
          Level = 1,
          Icon = "Folder",
          SelectedIcon = "FolderSelected",
          HighlightedIcon = "FolderSelected",
          IsHaveChildNode = true,
          IsAllowSelect = true,
          Item = "String"
        }
      };
      var ctrl = new FolderViewController(items);
      NavigationController.PushViewController(ctrl, true);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

