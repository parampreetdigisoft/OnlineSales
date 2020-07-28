﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class OnlineSalesEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=OnlineSalesEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property C_login() As DbSet(Of C_login)
    Public Overridable Property Affiliates() As DbSet(Of Affiliate)
    Public Overridable Property AffiliateLinks() As DbSet(Of AffiliateLink)
    Public Overridable Property AffiliateLists() As DbSet(Of AffiliateList)
    Public Overridable Property AffiliatePrograms() As DbSet(Of AffiliateProgram)
    Public Overridable Property AffiliateProgramNews() As DbSet(Of AffiliateProgramNew)
    Public Overridable Property BuildaLinks() As DbSet(Of BuildaLink)
    Public Overridable Property CaptureEmails() As DbSet(Of CaptureEmail)
    Public Overridable Property CartSetups() As DbSet(Of CartSetup)
    Public Overridable Property CatalogImages() As DbSet(Of CatalogImage)
    Public Overridable Property CatalogItems() As DbSet(Of CatalogItem)
    Public Overridable Property CatalogLevel1() As DbSet(Of CatalogLevel1)
    Public Overridable Property CatalogLevel1_2s() As DbSet(Of CatalogLevel1_2s)
    Public Overridable Property CatalogLevel2() As DbSet(Of CatalogLevel2)
    Public Overridable Property CatalogLevel3() As DbSet(Of CatalogLevel3)
    Public Overridable Property Categories() As DbSet(Of Category)
    Public Overridable Property ColorPalettes() As DbSet(Of ColorPalette)
    Public Overridable Property ColorPaletteNews() As DbSet(Of ColorPaletteNew)
    Public Overridable Property Contacts() As DbSet(Of Contact)
    Public Overridable Property Countries() As DbSet(Of Country)
    Public Overridable Property Coupons() As DbSet(Of Coupon)
    Public Overridable Property Customers() As DbSet(Of Customer)
    Public Overridable Property CustomerSelectPlans() As DbSet(Of CustomerSelectPlan)
    Public Overridable Property Downloads() As DbSet(Of Download)
    Public Overridable Property EzShips() As DbSet(Of EzShip)
    Public Overridable Property FedexShippings() As DbSet(Of FedexShipping)
    Public Overridable Property GetResponse_CustomerCampaign() As DbSet(Of GetResponse_CustomerCampaign)
    Public Overridable Property HelpMessages() As DbSet(Of HelpMessage)
    Public Overridable Property ItemOptions() As DbSet(Of ItemOption)
    Public Overridable Property ItemOptionGroups() As DbSet(Of ItemOptionGroup)
    Public Overridable Property ItemOptionGroups1() As DbSet(Of ItemOptionGroup1)
    Public Overridable Property ItemOptionNews() As DbSet(Of ItemOptionNew)
    Public Overridable Property ItemOptions1() As DbSet(Of ItemOption1)
    Public Overridable Property ItemSubOptions() As DbSet(Of ItemSubOption)
    Public Overridable Property ItemSubOptions1() As DbSet(Of ItemSubOption1)
    Public Overridable Property ItemUpsells() As DbSet(Of ItemUpsell)
    Public Overridable Property ItemUpsellGroups() As DbSet(Of ItemUpsellGroup)
    Public Overridable Property ItemUpsells1() As DbSet(Of ItemUpsell1)
    Public Overridable Property Languages() As DbSet(Of Language)
    Public Overridable Property Languages1() As DbSet(Of Language1)
    Public Overridable Property MasterAccounts() As DbSet(Of MasterAccount)
    Public Overridable Property OrderDetails() As DbSet(Of OrderDetail)
    Public Overridable Property OrderDetailOptions() As DbSet(Of OrderDetailOption)
    Public Overridable Property OrderHeaders() As DbSet(Of OrderHeader)
    Public Overridable Property OrderSubOptions() As DbSet(Of OrderSubOption)
    Public Overridable Property OurAffiliates() As DbSet(Of OurAffiliate)
    Public Overridable Property OurCustomers() As DbSet(Of OurCustomer)
    Public Overridable Property OurCustPayments() As DbSet(Of OurCustPayment)
    Public Overridable Property PaypalIntegrations() As DbSet(Of PaypalIntegration)
    Public Overridable Property PaypalPaymentHistories() As DbSet(Of PaypalPaymentHistory)
    Public Overridable Property QuantityDiscounts() As DbSet(Of QuantityDiscount)
    Public Overridable Property QuickBookCustomers() As DbSet(Of QuickBookCustomer)
    Public Overridable Property QuickbooksConnectionHistories() As DbSet(Of QuickbooksConnectionHistory)
    Public Overridable Property QuickBooksCustomerAccountInformations() As DbSet(Of QuickBooksCustomerAccountInformation)
    Public Overridable Property SecurityObjects() As DbSet(Of SecurityObject)
    Public Overridable Property Sessions() As DbSet(Of Session)
    Public Overridable Property SingleCoupons() As DbSet(Of SingleCoupon)
    Public Overridable Property SplitTests() As DbSet(Of SplitTest)
    Public Overridable Property SplitTestCaptures() As DbSet(Of SplitTestCapture)
    Public Overridable Property SplitTestLinks() As DbSet(Of SplitTestLink)
    Public Overridable Property StateCodes() As DbSet(Of StateCode)
    Public Overridable Property sysdiagrams() As DbSet(Of sysdiagram)
    Public Overridable Property TaxStates() As DbSet(Of TaxState)
    Public Overridable Property UserSecurities() As DbSet(Of UserSecurity)
    Public Overridable Property USPSShippings() As DbSet(Of USPSShipping)
    Public Overridable Property Visitors() As DbSet(Of Visitor)
    Public Overridable Property VisitorActions() As DbSet(Of VisitorAction)
    Public Overridable Property VisitorTrackings() As DbSet(Of VisitorTracking)
    Public Overridable Property ColorPaletteOlds() As DbSet(Of ColorPaletteOld)
    Public Overridable Property CountryCodesCompletes() As DbSet(Of CountryCodesComplete)
    Public Overridable Property Currencies() As DbSet(Of Currency)
    Public Overridable Property Licenses() As DbSet(Of License)
    Public Overridable Property LicenseTracks() As DbSet(Of LicenseTrack)
    Public Overridable Property MacAddresses() As DbSet(Of MacAddress)
    Public Overridable Property OrderDetailOLDs() As DbSet(Of OrderDetailOLD)
    Public Overridable Property UpsShippnngCodes() As DbSet(Of UpsShippnngCode)
    Public Overridable Property UpsSignups() As DbSet(Of UpsSignup)
    Public Overridable Property CatalogItemByAPIkeys() As DbSet(Of CatalogItemByAPIkey)
    Public Overridable Property qryActiveCoupons() As DbSet(Of qryActiveCoupon)
    Public Overridable Property qryAffiliateLinks() As DbSet(Of qryAffiliateLink)
    Public Overridable Property qryBasicCatalogItems() As DbSet(Of qryBasicCatalogItem)
    Public Overridable Property qryBasicCatalogMaints() As DbSet(Of qryBasicCatalogMaint)
    Public Overridable Property qryCartSetups() As DbSet(Of qryCartSetup)
    Public Overridable Property qryCartSetupNews() As DbSet(Of qryCartSetupNew)
    Public Overridable Property qryCatalogItems() As DbSet(Of qryCatalogItem)
    Public Overridable Property qryCatalogItemByAPIkeys() As DbSet(Of qryCatalogItemByAPIkey)
    Public Overridable Property qryCatalogItemList_Level1() As DbSet(Of qryCatalogItemList_Level1)
    Public Overridable Property qryCatalogItemList_Level2() As DbSet(Of qryCatalogItemList_Level2)
    Public Overridable Property qryCatalogItemList_level3() As DbSet(Of qryCatalogItemList_level3)
    Public Overridable Property qryCatalogItemListWide_Level3() As DbSet(Of qryCatalogItemListWide_Level3)
    Public Overridable Property qryCompleteCatalogs() As DbSet(Of qryCompleteCatalog)
    Public Overridable Property qryCompleteOrders() As DbSet(Of qryCompleteOrder)
    Public Overridable Property qryCompleteOrderWithDetails() As DbSet(Of qryCompleteOrderWithDetail)
    Public Overridable Property qryCompleteOrderWithDetails1() As DbSet(Of qryCompleteOrderWithDetail1)
    Public Overridable Property qryForSaveThisOrders() As DbSet(Of qryForSaveThisOrder)
    Public Overridable Property qryLogins() As DbSet(Of qryLogin)
    Public Overridable Property qryNewCartSetups() As DbSet(Of qryNewCartSetup)
    Public Overridable Property qryOrderDetails() As DbSet(Of qryOrderDetail)
    Public Overridable Property qryOrderDetailOnlyWithOptions() As DbSet(Of qryOrderDetailOnlyWithOption)
    Public Overridable Property qryOrderDetailOptionTotals() As DbSet(Of qryOrderDetailOptionTotal)
    Public Overridable Property qryOrderDetailWithOptionsOLDs() As DbSet(Of qryOrderDetailWithOptionsOLD)
    Public Overridable Property qryOrderOptions() As DbSet(Of qryOrderOption)
    Public Overridable Property qryOrderSubOptions() As DbSet(Of qryOrderSubOption)
    Public Overridable Property qryOrderTotals() As DbSet(Of qryOrderTotal)
    Public Overridable Property qryQbOrdersToProcesses() As DbSet(Of qryQbOrdersToProcess)
    Public Overridable Property qryTaxStatew_Name() As DbSet(Of qryTaxStatew_Name)

End Class
