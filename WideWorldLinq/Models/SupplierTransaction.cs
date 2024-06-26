﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WideWorldLinq.Models;

[Table("SupplierTransactions", Schema = "Purchasing")]
[Index("TransactionDate", "PaymentMethodId", Name = "FK_Purchasing_SupplierTransactions_PaymentMethodID")]
[Index("TransactionDate", "PurchaseOrderId", Name = "FK_Purchasing_SupplierTransactions_PurchaseOrderID")]
[Index("TransactionDate", "SupplierId", Name = "FK_Purchasing_SupplierTransactions_SupplierID")]
[Index("TransactionDate", "TransactionTypeId", Name = "FK_Purchasing_SupplierTransactions_TransactionTypeID")]
[Index("TransactionDate", "IsFinalized", Name = "IX_Purchasing_SupplierTransactions_IsFinalized")]
public partial class SupplierTransaction
{
    [Key]
    [Column("SupplierTransactionID")]
    public int SupplierTransactionId { get; set; }

    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [Column("TransactionTypeID")]
    public int TransactionTypeId { get; set; }

    [Column("PurchaseOrderID")]
    public int? PurchaseOrderId { get; set; }

    [Column("PaymentMethodID")]
    public int? PaymentMethodId { get; set; }

    [StringLength(20)]
    public string SupplierInvoiceNumber { get; set; }

    [Column(TypeName = "date")]
    public DateTime TransactionDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal AmountExcludingTax { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TaxAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TransactionAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal OutstandingBalance { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FinalizationDate { get; set; }

    public bool? IsFinalized { get; set; }

    public int LastEditedBy { get; set; }

    public DateTime LastEditedWhen { get; set; }

    [ForeignKey("LastEditedBy")]
    [InverseProperty("SupplierTransactions")]
    public virtual Person LastEditedByNavigation { get; set; }

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("SupplierTransactions")]
    public virtual PaymentMethod PaymentMethod { get; set; }

    [ForeignKey("PurchaseOrderId")]
    [InverseProperty("SupplierTransactions")]
    public virtual PurchaseOrder PurchaseOrder { get; set; }

    [ForeignKey("SupplierId")]
    [InverseProperty("SupplierTransactions")]
    public virtual Supplier Supplier { get; set; }

    [ForeignKey("TransactionTypeId")]
    [InverseProperty("SupplierTransactions")]
    public virtual TransactionType TransactionType { get; set; }
}