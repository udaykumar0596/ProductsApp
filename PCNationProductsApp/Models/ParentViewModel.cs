using System.Collections.Generic;

namespace PCNationProductsApp.Models
{
    public class ParentViewModel
    {
        //<summary>
        /// Gets or sets Customers.
        ///</summary>
        public List<ProductViewModel> Products { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
    }
}
