using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeView
{
	public class TreeItem
	{

		public Boolean IsLoaded { get; set; }

		public Boolean IsExpand { get; set; }

		public Boolean IsSelected { get;set; }

		public Boolean IsHaveChildNode { get; set; }

    public Boolean IsAllowSelect { get; set; }

    public Object Item { get;set; }

    public IList<TreeItem> Childs { get;set; }

		public String Text { get;set; }

		public String Icon { get; set; }

		public String SelectedIcon { get; set; }

		public String HighlightedIcon { get; set; }

		public int ChildCount { get; set; }

		public int Level { get; set; }

		public TreeItem() {
      Childs = new List<TreeItem>();
		}

    public IList<TreeItem> ShowedItems(bool selectCurrent) {
      var result = new List<TreeItem>();
      if (selectCurrent) {
        result.Add(this);
      }
      if (IsExpand) {
        for (int i = 0, count = Childs.Count; i < count; i++) {
          result.AddRange(Childs[i].ShowedItems(true));
        }
      }
      return result;
    }

    public void SelectAll () {
      IsSelected = true;
      for (int i = 0, count = Childs.Count; i < count; i++) {
        Childs[i].SelectAll();
      }
    }

    public IList<TreeItem> SelectedItems() {
      var result = new List<TreeItem>();
      for (int i = 0, count = Childs.Count; i < count; i++) {
        result.AddRange(Childs[i].SelectedItems());
      }
      if (IsSelected) {
        result.Add(this);
      }
      return result;
    }

	}
}

