// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FinanceAssessment
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField InvestmentField { get; set; }

		[Outlet]
		AppKit.NSTableColumn ProductColumn { get; set; }

		[Outlet]
		AppKit.NSTableView ProductTable { get; set; }

		[Outlet]
		AppKit.NSTableColumn ReturnColumn { get; set; }

		[Outlet]
		AppKit.NSTextField TermField { get; set; }

		[Action ("ClickedButton:")]
		partial void ClickedButton (Foundation.NSObject sender);

		[Action ("InvestmentFieldInput:")]
		partial void InvestmentFieldInput (Foundation.NSObject sender);

		[Action ("TermFieldInput:")]
		partial void TermFieldInput (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (InvestmentField != null) {
				InvestmentField.Dispose ();
				InvestmentField = null;
			}

			if (TermField != null) {
				TermField.Dispose ();
				TermField = null;
			}

			if (ProductTable != null) {
				ProductTable.Dispose ();
				ProductTable = null;
			}

			if (ProductColumn != null) {
				ProductColumn.Dispose ();
				ProductColumn = null;
			}

			if (ReturnColumn != null) {
				ReturnColumn.Dispose ();
				ReturnColumn = null;
			}

		}
	}
}
