//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HumerResource.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addresses
    {
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Contry { get; set; }
        public string Postcode { get; set; }
        public int AgentsID { get; set; }
    
        public virtual Agents Agents { get; set; }
    }
}
