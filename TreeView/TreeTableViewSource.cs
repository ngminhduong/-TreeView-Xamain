using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using Foundation;


namespace TreeView {

  public class TreeTableViewSource : UITableViewSource {
    
    private IList<TreeItem> iShowList;

    private UITableView iTableView;

    public IList<TreeItem> Items { get; private set; }

    public Func<TreeItem, IList<TreeItem>> OnExpand;

    public Func<TreeItem, Boolean> OnSelect;

    public Func<TreeItem, Boolean> OnDeSelect;

    public Boolean IsChildSelect { get; set; }



    public TreeTableViewSource (UITableView table, IList<TreeItem> items) {
      Items = items;
      iShowList = items.ToList();
      iTableView = table;
    }


    public override nint NumberOfSections (UITableView tableView) {
      return 1;
    }

    public override nint RowsInSection (UITableView tableview, nint section) {
      return iShowList.Count;
    }


    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath) {
      var cell = (TreeItemCell)tableView.DequeueReusableCell("TREE_ITEMCELL_IDENTIFIER");
      cell.Initialize(iShowList[indexPath.Row]);
      cell.OnSelect = onSelect;
      cell.OnDeselect = OnDeSelect;
      return cell;
    }

    public override void RowSelected (UITableView tableView, NSIndexPath indexPath) {
      var item = iShowList[indexPath.Row];
      var insertTreeItemIndex = iShowList.IndexOf(item);
      var insertIndexPaths = new List<NSIndexPath>();
      var removeIndexPaths = new List<NSIndexPath>();
      if (item.IsExpand) {
        var childsItem = item.ShowedItems(false);
        for (int i = 0, count = childsItem.Count; i < count; i++) {
          insertTreeItemIndex++;
          iShowList.Remove(childsItem[i]);
          removeIndexPaths.Add(NSIndexPath.FromRowSection(insertTreeItemIndex, 0));
        }
        item.IsExpand = false;
      } else {
        IList<TreeItem> childs;
        if (item.IsHaveChildNode && OnExpand != null) {
          if (!item.IsLoaded) {
            childs = OnExpand(item);
            item.Childs = childs;
            item.IsLoaded = true;
          } else {
            childs = item.Childs;
          }
          for (int i = 0, count = childs.Count; i < count; i++) {
            insertTreeItemIndex++;
            iShowList.Insert(insertTreeItemIndex, childs[i]);
            childs[i].IsExpand = false;
            insertIndexPaths.Add(NSIndexPath.FromRowSection(insertTreeItemIndex, 0));
          }
          item.IsExpand = true;
        } else {

        }
      }
      if (insertIndexPaths.Count > 0) {
        tableView.InsertRows(insertIndexPaths.ToArray(), UITableViewRowAnimation.Bottom);
      }
      if (removeIndexPaths.Count > 0) {
        tableView.DeleteRows(removeIndexPaths.ToArray(), UITableViewRowAnimation.Top);
      }
    }

    private Boolean onSelect(TreeItem item) {
      var insertTreeItemIndex = iShowList.IndexOf(item);
      var reloadIndexPaths = new List<NSIndexPath>();
      if (OnSelect(item)) {
        if (IsChildSelect) {
          item.SelectAll();
          var childsItem = item.ShowedItems(false);
          for (int i = 0, count = childsItem.Count; i < count; i++) {
            insertTreeItemIndex++;
            reloadIndexPaths.Add(NSIndexPath.FromRowSection(insertTreeItemIndex, 0));
          }
          iTableView.ReloadRows(reloadIndexPaths.ToArray(), UITableViewRowAnimation.None);
        }
        return true;
      }
      return false;
    }

  }
}