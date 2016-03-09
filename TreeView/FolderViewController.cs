using System;

using UIKit;
using System.Collections.Generic;


namespace TreeView {
  public partial class FolderViewController : TreeViewController {

    public FolderViewController(IList<TreeItem> items) : base(items) {
    //  IsChildSelect = true;
    }

    public override IList<TreeItem> doOnExpand (TreeItem obj) {
      
      var items = new TreeItem[] {
        new TreeItem() {
          Text = "A1",
          Level = obj.Level + 1,
          Icon = "Folder",
          SelectedIcon = "FolderSelected",
          HighlightedIcon = "FolderSelected",
          IsHaveChildNode = true,
          IsAllowSelect = true,
          Item = "String"
        },
        new TreeItem() {
          Text = "A1",
          Level = obj.Level + 1,
          Icon = "Folder",
          SelectedIcon = "FolderSelected",
          HighlightedIcon = "FolderSelected",
          IsHaveChildNode = true,
          IsAllowSelect = true,
          Item = "String"
        }
      };
      return items;
    }

    public override void ViewDidLoad () {
      base.ViewDidLoad();
      // Perform any additional setup after loading the view, typically from a nib.
    }

    public override void DidReceiveMemoryWarning () {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }
  }
}


