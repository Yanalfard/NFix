﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models.Regular
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NFixEntities : DbContext
    {
        public NFixEntities()
            : base("name=NFixEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblAd> TblAd { get; set; }
        public virtual DbSet<TblBlog> TblBlog { get; set; }
        public virtual DbSet<TblBlogCommentRel> TblBlogCommentRel { get; set; }
        public virtual DbSet<TblBlogKeywordRel> TblBlogKeywordRel { get; set; }
        public virtual DbSet<TblCatagory> TblCatagory { get; set; }
        public virtual DbSet<TblClient> TblClient { get; set; }
        public virtual DbSet<TblClientProductRel> TblClientProductRel { get; set; }
        public virtual DbSet<TblComment> TblComment { get; set; }
        public virtual DbSet<TblDeal> TblDeal { get; set; }
        public virtual DbSet<TblDealPropertyRel> TblDealPropertyRel { get; set; }
        public virtual DbSet<TblDiscount> TblDiscount { get; set; }
        public virtual DbSet<TblImage> TblImage { get; set; }
        public virtual DbSet<TblKeyword> TblKeyword { get; set; }
        public virtual DbSet<TblLog> TblLog { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProductCommentRel> TblProductCommentRel { get; set; }
        public virtual DbSet<TblProductImageRel> TblProductImageRel { get; set; }
        public virtual DbSet<TblProductKeywordRel> TblProductKeywordRel { get; set; }
        public virtual DbSet<TblProductPropertyRel> TblProductPropertyRel { get; set; }
        public virtual DbSet<TblProperty> TblProperty { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblTuotorVideoRel> TblTuotorVideoRel { get; set; }
        public virtual DbSet<TblTutor> TblTutor { get; set; }
        public virtual DbSet<TblUserPass> TblUserPass { get; set; }
        public virtual DbSet<TblVideo> TblVideo { get; set; }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
