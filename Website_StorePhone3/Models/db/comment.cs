//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website_StorePhone3.Models.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class comment
    {
        public comment()
        {
            this.comment1 = new HashSet<comment>();
        }
    
        public int id { get; set; }
        public Nullable<int> userId { get; set; }
        public int productId { get; set; }
        [Required(ErrorMessage = "Enter FullName")]
        [Display(Name = "FullName")]
        public string fullname { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter Content")]
        [Display(Name = "Content")]
        public string content { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
        public Nullable<int> reply { get; set; }
        public Nullable<int> parent { get; set; }
    
        public virtual ICollection<comment> comment1 { get; set; }
        public virtual comment comment2 { get; set; }
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
