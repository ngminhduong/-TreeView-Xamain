// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TreeView
{
	[Register ("TreeItemCell")]
	partial class TreeItemCell
	{
		[Outlet]
		UIKit.UIButton Button { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint LeftMarginConstraint { get; set; }

		[Outlet]
		UIKit.UILabel Title { get; set; }

		[Action ("OnClick:")]
		partial void OnClick (NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Button != null) {
				Button.Dispose ();
				Button = null;
			}

			if (LeftMarginConstraint != null) {
				LeftMarginConstraint.Dispose ();
				LeftMarginConstraint = null;
			}

			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}
		}
	}
}
