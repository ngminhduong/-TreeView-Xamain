# -TreeView-Xamain
![alt tag](https://lh3.googleusercontent.com/-D9z-oT4T31w/Vt5930kMzvI/AAAAAAAAEXk/YOL4g00VXnQ/s400-Ic42/Untitled.gif)
Allow to create dynamic tree in Xamarin-IOS
```C#
  public class FolderViewController : TreeViewController {

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
  }
```

Custom acction when select and deSelect row

```C#
    public override bool doOnDeSelect (TreeItem obj) {
      
    }

    public override bool doOnSelect (TreeItem obj) {
      
    }
```
