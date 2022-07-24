﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SUNetwork.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SELCUKDBEntities1 : DbContext
    {
        public SELCUKDBEntities1()
            : base("name=SELCUKDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ACTIVATION> ACTIVATION { get; set; }
        public virtual DbSet<ACTIVITY> ACTIVITY { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<COMMENT> COMMENT { get; set; }
        public virtual DbSet<FAVORITE> FAVORITE { get; set; }
        public virtual DbSet<GROUP_ACTIVITY> GROUP_ACTIVITY { get; set; }
        public virtual DbSet<MESSAGES> MESSAGES { get; set; }
        public virtual DbSet<PARAMETER> PARAMETER { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<USERS_ACTIVITY> USERS_ACTIVITY { get; set; }
        public virtual DbSet<USERS_FRENDSHIP> USERS_FRENDSHIP { get; set; }
        public virtual DbSet<USERS_GROUP> USERS_GROUP { get; set; }
        public virtual DbSet<USERS_GROUP_MEMBERS> USERS_GROUP_MEMBERS { get; set; }
    
        public virtual ObjectResult<SP_ACTIVITY_LIST_Result> SP_ACTIVITY_LIST(Nullable<int> kAYIT_SAYISI)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ACTIVITY_LIST_Result>("SP_ACTIVITY_LIST", kAYIT_SAYISIParameter);
        }
    
        public virtual ObjectResult<SP_USERS_LOGIN_Result> SP_USERS_LOGIN(string eMAIL, string pASSWORD)
        {
            var eMAILParameter = eMAIL != null ?
                new ObjectParameter("EMAIL", eMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var pASSWORDParameter = pASSWORD != null ?
                new ObjectParameter("PASSWORD", pASSWORD) :
                new ObjectParameter("PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_USERS_LOGIN_Result>("SP_USERS_LOGIN", eMAILParameter, pASSWORDParameter);
        }
    
        public virtual ObjectResult<SP_SEARCH_PROFILE_Result> SP_SEARCH_PROFILE(string nAME, string uSER_ID)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEARCH_PROFILE_Result>("SP_SEARCH_PROFILE", nAMEParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_SEARCH_USER_PROFILE_Result> SP_SEARCH_USER_PROFILE(string nAME, string uSER_ID)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEARCH_USER_PROFILE_Result>("SP_SEARCH_USER_PROFILE", nAMEParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_GET_FRIEND_REQUEST_COUNT(string uSER_ID)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_GET_FRIEND_REQUEST_COUNT", uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_GET_FRIENDS_Result> SP_GET_FRIENDS(string uSER_ID, string sTATUS_CODE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_FRIENDS_Result>("SP_GET_FRIENDS", uSER_IDParameter, sTATUS_CODEParameter);
        }
    
        public virtual int SP_FRIENDSHIP_ACTION(string uSER_ID, string mAIN_USER_ID, string sTATUS_CODE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var mAIN_USER_IDParameter = mAIN_USER_ID != null ?
                new ObjectParameter("MAIN_USER_ID", mAIN_USER_ID) :
                new ObjectParameter("MAIN_USER_ID", typeof(string));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_FRIENDSHIP_ACTION", uSER_IDParameter, mAIN_USER_IDParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<SP_GET_FOLLOWERS_Result> SP_GET_FOLLOWERS(string uSER_ID, Nullable<int> fOLLOWER_TYPE, string sTATUS_CODE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var fOLLOWER_TYPEParameter = fOLLOWER_TYPE.HasValue ?
                new ObjectParameter("FOLLOWER_TYPE", fOLLOWER_TYPE) :
                new ObjectParameter("FOLLOWER_TYPE", typeof(int));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_FOLLOWERS_Result>("SP_GET_FOLLOWERS", uSER_IDParameter, fOLLOWER_TYPEParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<SP_SEARCH_PROFILE_FOR_GROUP_Result> SP_SEARCH_PROFILE_FOR_GROUP(string nAME, string sURNAME, string dEPARTMAN, Nullable<long> gROUP_ID, string aLL_MEMBER_FLAG)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var sURNAMEParameter = sURNAME != null ?
                new ObjectParameter("SURNAME", sURNAME) :
                new ObjectParameter("SURNAME", typeof(string));
    
            var dEPARTMANParameter = dEPARTMAN != null ?
                new ObjectParameter("DEPARTMAN", dEPARTMAN) :
                new ObjectParameter("DEPARTMAN", typeof(string));
    
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            var aLL_MEMBER_FLAGParameter = aLL_MEMBER_FLAG != null ?
                new ObjectParameter("ALL_MEMBER_FLAG", aLL_MEMBER_FLAG) :
                new ObjectParameter("ALL_MEMBER_FLAG", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEARCH_PROFILE_FOR_GROUP_Result>("SP_SEARCH_PROFILE_FOR_GROUP", nAMEParameter, sURNAMEParameter, dEPARTMANParameter, gROUP_IDParameter, aLL_MEMBER_FLAGParameter);
        }
    
        public virtual ObjectResult<SP_GET_ALL_ACTIONS_Result> SP_GET_ALL_ACTIONS(string uSER_ID)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_ALL_ACTIONS_Result>("SP_GET_ALL_ACTIONS", uSER_IDParameter);
        }
    
        public virtual int SP_MESSAGE_LIST(Nullable<int> kAYIT_SAYISI, string mAIN_USER_ID, string uSER_ID2)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var mAIN_USER_IDParameter = mAIN_USER_ID != null ?
                new ObjectParameter("MAIN_USER_ID", mAIN_USER_ID) :
                new ObjectParameter("MAIN_USER_ID", typeof(string));
    
            var uSER_ID2Parameter = uSER_ID2 != null ?
                new ObjectParameter("USER_ID2", uSER_ID2) :
                new ObjectParameter("USER_ID2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_MESSAGE_LIST", kAYIT_SAYISIParameter, mAIN_USER_IDParameter, uSER_ID2Parameter);
        }
    
        public virtual int SP_MESSAGES_LIST(Nullable<int> kAYIT_SAYISI, string mAIN_USER_ID, string uSER_ID2)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var mAIN_USER_IDParameter = mAIN_USER_ID != null ?
                new ObjectParameter("MAIN_USER_ID", mAIN_USER_ID) :
                new ObjectParameter("MAIN_USER_ID", typeof(string));
    
            var uSER_ID2Parameter = uSER_ID2 != null ?
                new ObjectParameter("USER_ID2", uSER_ID2) :
                new ObjectParameter("USER_ID2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_MESSAGES_LIST", kAYIT_SAYISIParameter, mAIN_USER_IDParameter, uSER_ID2Parameter);
        }
    
        public virtual int SP_MESSAGE_LIST1(Nullable<int> kAYIT_SAYISI, string mAIN_USER_ID, string uSER_ID2)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var mAIN_USER_IDParameter = mAIN_USER_ID != null ?
                new ObjectParameter("MAIN_USER_ID", mAIN_USER_ID) :
                new ObjectParameter("MAIN_USER_ID", typeof(string));
    
            var uSER_ID2Parameter = uSER_ID2 != null ?
                new ObjectParameter("USER_ID2", uSER_ID2) :
                new ObjectParameter("USER_ID2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_MESSAGE_LIST1", kAYIT_SAYISIParameter, mAIN_USER_IDParameter, uSER_ID2Parameter);
        }
    
        public virtual ObjectResult<SP_USERS_MESSAGE_LIST_Result> SP_USERS_MESSAGE_LIST(Nullable<int> kAYIT_SAYISI, string mAIN_USER_ID, string uSER_ID2)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var mAIN_USER_IDParameter = mAIN_USER_ID != null ?
                new ObjectParameter("MAIN_USER_ID", mAIN_USER_ID) :
                new ObjectParameter("MAIN_USER_ID", typeof(string));
    
            var uSER_ID2Parameter = uSER_ID2 != null ?
                new ObjectParameter("USER_ID2", uSER_ID2) :
                new ObjectParameter("USER_ID2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_USERS_MESSAGE_LIST_Result>("SP_USERS_MESSAGE_LIST", kAYIT_SAYISIParameter, mAIN_USER_IDParameter, uSER_ID2Parameter);
        }
    
        public virtual int SP_USERS_MESSAGE_ALL(Nullable<int> kAYIT_SAYISI, string mAIN_USER_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var mAIN_USER_IDParameter = mAIN_USER_ID != null ?
                new ObjectParameter("MAIN_USER_ID", mAIN_USER_ID) :
                new ObjectParameter("MAIN_USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_USERS_MESSAGE_ALL", kAYIT_SAYISIParameter, mAIN_USER_IDParameter);
        }
    
        public virtual ObjectResult<SP_MESSAGE_ALL_Result> SP_MESSAGE_ALL(string mAIN_USER_ID)
        {
            var mAIN_USER_IDParameter = mAIN_USER_ID != null ?
                new ObjectParameter("MAIN_USER_ID", mAIN_USER_ID) :
                new ObjectParameter("MAIN_USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_MESSAGE_ALL_Result>("SP_MESSAGE_ALL", mAIN_USER_IDParameter);
        }
    
        public virtual ObjectResult<SP_DETAIL_SEARCH_USER_PROFILE_Result> SP_DETAIL_SEARCH_USER_PROFILE(string nAME, string jOB, string uSER_ID)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var jOBParameter = jOB != null ?
                new ObjectParameter("JOB", jOB) :
                new ObjectParameter("JOB", typeof(string));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_DETAIL_SEARCH_USER_PROFILE_Result>("SP_DETAIL_SEARCH_USER_PROFILE", nAMEParameter, jOBParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_DETAILS_SEARCH_USER_PROFILE_Result> SP_DETAILS_SEARCH_USER_PROFILE(string nAME, string jOB, string uSER_ID)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var jOBParameter = jOB != null ?
                new ObjectParameter("JOB", jOB) :
                new ObjectParameter("JOB", typeof(string));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_DETAILS_SEARCH_USER_PROFILE_Result>("SP_DETAILS_SEARCH_USER_PROFILE", nAMEParameter, jOBParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_DETAIL_SEARCH_USER_PROFILE1_Result> SP_DETAIL_SEARCH_USER_PROFILE1(string nAME, string jOB, string uSER_ID)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var jOBParameter = jOB != null ?
                new ObjectParameter("JOB", jOB) :
                new ObjectParameter("JOB", typeof(string));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_DETAIL_SEARCH_USER_PROFILE1_Result>("SP_DETAIL_SEARCH_USER_PROFILE1", nAMEParameter, jOBParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_SEARCH_DETAIL_USER_PROFILE_Result> SP_SEARCH_DETAIL_USER_PROFILE(string nAME, string jOB, string uSER_ID)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var jOBParameter = jOB != null ?
                new ObjectParameter("JOB", jOB) :
                new ObjectParameter("JOB", typeof(string));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEARCH_DETAIL_USER_PROFILE_Result>("SP_SEARCH_DETAIL_USER_PROFILE", nAMEParameter, jOBParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_SEARCH_USER_PROFILE_FOR_GROUP_Result> SP_SEARCH_USER_PROFILE_FOR_GROUP(string dEPARTMENT_CODE, string uSER_ID, Nullable<long> gROUP_ID)
        {
            var dEPARTMENT_CODEParameter = dEPARTMENT_CODE != null ?
                new ObjectParameter("DEPARTMENT_CODE", dEPARTMENT_CODE) :
                new ObjectParameter("DEPARTMENT_CODE", typeof(string));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEARCH_USER_PROFILE_FOR_GROUP_Result>("SP_SEARCH_USER_PROFILE_FOR_GROUP", dEPARTMENT_CODEParameter, uSER_IDParameter, gROUP_IDParameter);
        }
    
        public virtual int SP_MEMBER_ACTION(string uSER_ID, Nullable<long> gROUP_ID, string sTATUS_CODE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_MEMBER_ACTION", uSER_IDParameter, gROUP_IDParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<SP_GET_MEMBERS_Result> SP_GET_MEMBERS(Nullable<long> gROUP_ID, string sTATUS_CODE)
        {
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_MEMBERS_Result>("SP_GET_MEMBERS", gROUP_IDParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<SP_GROUP_INVITATION_Result> SP_GROUP_INVITATION(Nullable<long> gROUP_ID, string sTATUS_CODE)
        {
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GROUP_INVITATION_Result>("SP_GROUP_INVITATION", gROUP_IDParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_GET_GROUP_INVITATION_COUNT(Nullable<long> gROUP_ID)
        {
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_GET_GROUP_INVITATION_COUNT", gROUP_IDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_GET_INVITATION_COUNT(string uSER_ID)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_GET_INVITATION_COUNT", uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_GET_ACTIONS_Result> SP_GET_ACTIONS(string uSER_ID)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_ACTIONS_Result>("SP_GET_ACTIONS", uSER_IDParameter);
        }
    
        public virtual int SP_GROUP_ACTIVITY_LIST(Nullable<int> kAYIT_SAYISI, Nullable<long> gROUP_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GROUP_ACTIVITY_LIST", kAYIT_SAYISIParameter, gROUP_IDParameter);
        }
    
        public virtual ObjectResult<SP_GET_GROUP_Result> SP_GET_GROUP(string uSER_ID, Nullable<int> tYPE, string sTATUS_CODE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var tYPEParameter = tYPE.HasValue ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(int));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_GROUP_Result>("SP_GET_GROUP", uSER_IDParameter, tYPEParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<SP_GET_GROUPS_Result> SP_GET_GROUPS(string uSER_ID, Nullable<int> tYPE, string sTATUS_CODE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var tYPEParameter = tYPE.HasValue ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(int));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_GROUPS_Result>("SP_GET_GROUPS", uSER_IDParameter, tYPEParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<SP_GET_GROUPS_AND_MYGROUPS_Result> SP_GET_GROUPS_AND_MYGROUPS(string uSER_ID, Nullable<int> tYPE, string sTATUS_CODE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var tYPEParameter = tYPE.HasValue ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(int));
    
            var sTATUS_CODEParameter = sTATUS_CODE != null ?
                new ObjectParameter("STATUS_CODE", sTATUS_CODE) :
                new ObjectParameter("STATUS_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_GROUPS_AND_MYGROUPS_Result>("SP_GET_GROUPS_AND_MYGROUPS", uSER_IDParameter, tYPEParameter, sTATUS_CODEParameter);
        }
    
        public virtual ObjectResult<SP_GET_GROUPS1_Result> SP_GET_GROUPS1(string uSER_ID, Nullable<int> tYPE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var tYPEParameter = tYPE.HasValue ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_GROUPS1_Result>("SP_GET_GROUPS1", uSER_IDParameter, tYPEParameter);
        }
    
        public virtual ObjectResult<SP_ALL_GROUPS_Result> SP_ALL_GROUPS(string uSER_ID, Nullable<int> tYPE)
        {
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            var tYPEParameter = tYPE.HasValue ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ALL_GROUPS_Result>("SP_ALL_GROUPS", uSER_IDParameter, tYPEParameter);
        }
    
        public virtual ObjectResult<SP_GET_GROUP_ACTIVITY_LIST_Result> SP_GET_GROUP_ACTIVITY_LIST(Nullable<int> kAYIT_SAYISI, Nullable<long> gROUP_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var gROUP_IDParameter = gROUP_ID.HasValue ?
                new ObjectParameter("GROUP_ID", gROUP_ID) :
                new ObjectParameter("GROUP_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_GROUP_ACTIVITY_LIST_Result>("SP_GET_GROUP_ACTIVITY_LIST", kAYIT_SAYISIParameter, gROUP_IDParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int SP_GET_USER_ACTIVITY(Nullable<int> kAYIT_SAYISI, string uSER_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GET_USER_ACTIVITY", kAYIT_SAYISIParameter, uSER_IDParameter);
        }
    
        public virtual int SP_GET_USER_ACTIVITY1(Nullable<int> kAYIT_SAYISI, string uSER_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GET_USER_ACTIVITY1", kAYIT_SAYISIParameter, uSER_IDParameter);
        }
    
        public virtual int SP_USER_ACTIVITY_LIST(Nullable<int> kAYIT_SAYISI, string uSER_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_USER_ACTIVITY_LIST", kAYIT_SAYISIParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_GET_ALL_USER_ACTIVITY_Result> SP_GET_ALL_USER_ACTIVITY(Nullable<int> kAYIT_SAYISI, string uSER_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_ALL_USER_ACTIVITY_Result>("SP_GET_ALL_USER_ACTIVITY", kAYIT_SAYISIParameter, uSER_IDParameter);
        }
    
        public virtual int SP_GET_USER_ACTIVITY_LIST(Nullable<int> kAYIT_SAYISI, string uSER_ID)
        {
            var kAYIT_SAYISIParameter = kAYIT_SAYISI.HasValue ?
                new ObjectParameter("KAYIT_SAYISI", kAYIT_SAYISI) :
                new ObjectParameter("KAYIT_SAYISI", typeof(int));
    
            var uSER_IDParameter = uSER_ID != null ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GET_USER_ACTIVITY_LIST", kAYIT_SAYISIParameter, uSER_IDParameter);
        }
    
        public virtual ObjectResult<SP_GET_ALL_GROUPS_Result> SP_GET_ALL_GROUPS(Nullable<int> tYPE)
        {
            var tYPEParameter = tYPE.HasValue ?
                new ObjectParameter("TYPE", tYPE) :
                new ObjectParameter("TYPE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GET_ALL_GROUPS_Result>("SP_GET_ALL_GROUPS", tYPEParameter);
        }
    }
}
