using System;
using System.Collections.Generic;
using AppKit;

namespace FinanceAssessment.Models.Controls
{
    public class ProductTableDataSource : NSTableViewDataSource
    {
        #region Public Variables
        public List<Product> Products = new List<Product>();
        #endregion

        #region Constructors
        public ProductTableDataSource()
        {
        }
        #endregion

        #region Override Methods

        public override nint GetRowCount(NSTableView tableView)
        {
            return Products.Count;
        }
        
        #endregion
    }
}