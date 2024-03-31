﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WideWorldLinq.Models;

[Table("StockItemStockGroups", Schema = "Warehouse")]
[Index("StockGroupId", "StockItemId", Name = "UQ_StockItemStockGroups_StockGroupID_Lookup", IsUnique = true)]
[Index("StockItemId", "StockGroupId", Name = "UQ_StockItemStockGroups_StockItemID_Lookup", IsUnique = true)]
public partial class StockItemStockGroup
{
    [Key]
    [Column("StockItemStockGroupID")]
    public int StockItemStockGroupId { get; set; }

    [Column("StockItemID")]
    public int StockItemId { get; set; }

    [Column("StockGroupID")]
    public int StockGroupId { get; set; }

    public int LastEditedBy { get; set; }

    public DateTime LastEditedWhen { get; set; }

    [ForeignKey("LastEditedBy")]
    [InverseProperty("StockItemStockGroups")]
    public virtual Person LastEditedByNavigation { get; set; }

    [ForeignKey("StockGroupId")]
    [InverseProperty("StockItemStockGroups")]
    public virtual StockGroup StockGroup { get; set; }

    [ForeignKey("StockItemId")]
    [InverseProperty("StockItemStockGroups")]
    public virtual StockItem StockItem { get; set; }
}