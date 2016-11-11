﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NegoShoeTracker.Library {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DataResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DataResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NegoShoeTracker.Library.DataResource", typeof(DataResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO [ReservationItem]
        ///           ([ItemName]
        ///           ,[QuantityOrdered]
        ///           ,[RemainingUnreserved])
        ///     VALUES
        ///           (&apos;{0}&apos;
        ///           ,{1}
        ///           ,{2}).
        /// </summary>
        internal static string SQL_AddReservationItem {
            get {
                return ResourceManager.GetString("SQL_AddReservationItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO [Reserver]
        ///           ([Name]
        ///           ,[QuantityReserved]
        ///           ,[ItemID])
        ///     VALUES
        ///           (&apos;{0}&apos;
        ///           ,{1}
        ///           ,{2}).
        /// </summary>
        internal static string SQL_AddReserver {
            get {
                return ResourceManager.GetString("SQL_AddReserver", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM [ShipmentItem] WHERE [RecordID] = {0}.
        /// </summary>
        internal static string SQL_DeleteShipmentItem {
            get {
                return ResourceManager.GetString("SQL_DeleteShipmentItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT [PurchaseItemID]
        ///      ,[PurchaseID]
        ///      ,[ItemName]
        ///      ,[Quantity]
        ///      ,[BoughtPrice]
        ///      ,[TargetPrice]
        ///      ,[SoldPrice]
        ///      ,[StatusID]
        ///      ,[Remarks]
        ///  FROM [PurchaseItem]
        ///  WHERE [PurchaseID] = {0}.
        /// </summary>
        internal static string SQL_GetAllPurchaseItem {
            get {
                return ResourceManager.GetString("SQL_GetAllPurchaseItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT s.[RecordID]
        ///      ,s.[SID]
        ///      ,s.[ItemName]
        ///      ,s.[MerchantID]
        ///      ,s.[Quantity]
        ///      ,s.[BoughtPrice]
        ///      ,s.[TargetPrice]
        ///      ,s.[SoldPrice]
        ///      ,s.[StatusID]
        ///      ,s.[CurrentExchangeRate]
        ///      ,s.[Notes]
        ///	  ,m.Name
        ///	  ,st.Status
        ///  FROM [ShipmentItem] s
        ///  INNER JOIN Merchant m ON m.MerchantID = s.SID
        ///  INNER JOIN ItemStatus st ON st.RecordID = s.StatusID
        ///  WHERE [SID] = {0}.
        /// </summary>
        internal static string SQL_GetAllShipmentItem {
            get {
                return ResourceManager.GetString("SQL_GetAllShipmentItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT s.[RecordID]
        ///      ,s.[SID]
        ///      ,s.[ItemName]
        ///      ,s.[MerchantID]
        ///      ,s.[Quantity]
        ///      ,s.[BoughtPrice]
        ///      ,s.[TargetPrice]
        ///      ,s.[SoldPrice]
        ///      ,s.[StatusID]
        ///      ,s.[CurrentExchangeRate]
        ///      ,s.[Notes]
        ///	  ,m.Name
        ///	  ,st.Status
        ///  FROM [ShipmentItem] s
        ///  INNER JOIN Merchant m ON m.MerchantID = s.SID
        ///  INNER JOIN ItemStatus st ON st.RecordID = s.StatusID
        ///  WHERE s.[RecordID] = {0}.
        /// </summary>
        internal static string SQL_GetOneShipmentItem {
            get {
                return ResourceManager.GetString("SQL_GetOneShipmentItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO [ShipmentItem]
        ///           ([SID]
        ///           ,[ItemName]
        ///           ,[MerchantID]
        ///           ,[Quantity]
        ///           ,[BoughtPrice]
        ///           ,[TargetPrice]
        ///           ,[SoldPrice]
        ///           ,[StatusID]
        ///           ,[CurrentExchangeRate]
        ///           ,[Notes])
        ///     VALUES
        ///           ({0}
        ///           ,&apos;{1}&apos;
        ///           ,{2}
        ///           ,{3}
        ///           ,{4}
        ///           ,{5}
        ///           ,{6}
        ///           ,{7}
        ///           ,{8}
        ///           ,&apos;{9}&apos;).
        /// </summary>
        internal static string SQL_SaveShipmentItem {
            get {
                return ResourceManager.GetString("SQL_SaveShipmentItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE [ReservationItem]
        ///   SET [RemainingUnreserved] = {0}
        /// WHERE ID = {1}.
        /// </summary>
        internal static string SQL_UpdateReservationCount {
            get {
                return ResourceManager.GetString("SQL_UpdateReservationCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE [ShipmentItem]
        ///   SET 
        ///      [ItemName] = &apos;{0}&apos;
        ///      ,[MerchantID] = {1}
        ///      ,[Quantity] = {2}
        ///      ,[BoughtPrice] = {3}
        ///      ,[TargetPrice] = {4}
        ///      ,[SoldPrice] = {5}
        ///      ,[StatusID] = {6}
        ///      ,[CurrentExchangeRate] = {7}
        ///      ,[Notes] = &apos;{8}&apos;
        /// WHERE [RecordID] = {9}.
        /// </summary>
        internal static string SQL_UpdateShipmentItem {
            get {
                return ResourceManager.GetString("SQL_UpdateShipmentItem", resourceCulture);
            }
        }
    }
}
