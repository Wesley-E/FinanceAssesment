using System;
using AppKit;

namespace FinanceAssessment.Models.Controls
{
    public class ProductTableDelegate : NSTableViewDelegate
    {
        #region Constants
        private const string CellIdentifier = "ProdCell";
        #endregion

        #region Private Variables
        private ProductTableDataSource DataSource;
        private ViewController Controller;
        #endregion

        #region Constructors
        public ProductTableDelegate(ViewController controller, ProductTableDataSource dataSource)
        {
            DataSource = dataSource;
            Controller = controller;
        }
        #endregion

        #region Override Methods

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint nint)
        {
            var view = (NSTextField) tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            view.StringValue = tableColumn.Title switch
            {
                "Product" => DataSource.Products[(int) nint].ProductName,
                "Interest" => DataSource.Products[(int) nint].Interest,
                "Return" => DataSource.Products[(int) nint].InvestmentReturn,
                _ => view.StringValue
            };
            return view;
        }
        #endregion
    }
}