using System;

using UIKit;
using System.Linq.Expressions;
using Foundation;
using System.Collections.Generic;
using CoreGraphics;
using System.Threading.Tasks;
using System.Collections;

namespace TreeView
{
	public partial class TreeViewController : UIViewController
	{

		public UITableView TableView { get; private set;}

    public IList<TreeItem> Items { get; set; }

    public TreeTableViewSource Source { get; private set; }


    public Boolean IsChildSelect {
      get {
        return Source.IsChildSelect;
      }
      set {
        Source.IsChildSelect = value;
      }
    }

    public TreeViewController(IList<TreeItem> items) {
      Items = items;

      TableView = new UITableView (CGRect.Empty, UITableViewStyle.Plain) {
        TranslatesAutoresizingMaskIntoConstraints = false
      };
      Source = new TreeTableViewSource(TableView, Items);
			TableView.RegisterNibForCellReuse(UINib.FromName ("TreeItemCell", NSBundle.MainBundle), "TREE_ITEMCELL_IDENTIFIER");
			View.AddSubview (TableView);
			NSDictionary views = new NSDictionary ("tableView", TableView);
			View.AddConstraints(NSLayoutConstraint.FromVisualFormat ("H:|-0-[tableView]-0-|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views));
			View.AddConstraints(NSLayoutConstraint.FromVisualFormat ("V:|-0-[tableView]-0-|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, views));
		}

    public IList<TreeItem> OnExpand (TreeItem obj) {
      return doOnExpand(obj);
    }

    public virtual IList<TreeItem> doOnExpand (TreeItem obj) {
      return new List<TreeItem>();
    }


    public Boolean OnSelect (TreeItem obj) {
      return doOnSelect(obj);
    }

    public virtual Boolean doOnSelect (TreeItem obj) {
      return true;
    }


    public Boolean OnDeSelect (TreeItem obj) {
      return doOnDeSelect(obj);
    }

    public virtual Boolean doOnDeSelect (TreeItem obj) {
      return true;
    }


    public IList<TreeItem> SelectedItems () {
      return null;
    }


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

      Source.OnExpand = OnExpand;
      Source.OnSelect = OnSelect;
      Source.OnDeSelect = OnDeSelect;
      TableView.Source = Source;
      TableView.ReloadData();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


