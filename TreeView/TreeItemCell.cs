using System;

using Foundation;
using UIKit;

namespace TreeView
{
	public partial class TreeItemCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("TreeItemCell");
		public static readonly UINib Nib;
    private TreeItem iItem;
    public Func<TreeItem, Boolean> OnSelect;
    public Func<TreeItem, Boolean> OnDeselect;

		static TreeItemCell ()
		{
			Nib = UINib.FromName ("TreeItemCell", NSBundle.MainBundle);
		}

		public TreeItemCell (IntPtr handle) : base (handle)
		{
		}

    partial void OnClick (NSObject sender) {
      if (iItem.IsSelected) {
        if (OnDeselect(iItem)) {
          iItem.IsSelected = false;
          Button.Selected = false;
        }
      } else {
        if (OnSelect(iItem)) {
          iItem.IsSelected = true;
          Button.Selected = true;
        }
      }
    }

    public void Initialize (TreeItem item)
    {
      Button.SetImage(UIImage.FromBundle(item.Icon), UIControlState.Normal);
      Button.SetImage(UIImage.FromBundle(item.SelectedIcon), UIControlState.Selected);
      Button.SetImage(UIImage.FromBundle(item.HighlightedIcon), UIControlState.Highlighted);
      Button.Selected = item.IsSelected;
      Title.Text = item.Text;
      LeftMarginConstraint.Constant = (item.Level -1) * 20;
      iItem = item;

      Button.Enabled = item.IsAllowSelect;
    }

  }
}
