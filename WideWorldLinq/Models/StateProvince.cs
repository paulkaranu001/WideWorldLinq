﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WideWorldLinq.Models;

[Table("StateProvinces", Schema = "Application")]
[Index("CountryId", Name = "FK_Application_StateProvinces_CountryID")]
[Index("SalesTerritory", Name = "IX_Application_StateProvinces_SalesTerritory")]
[Index("StateProvinceName", Name = "UQ_Application_StateProvinces_StateProvinceName", IsUnique = true)]
public partial class StateProvince
{
    [Key]
    [Column("StateProvinceID")]
    public int StateProvinceId { get; set; }

    [Required]
    [StringLength(5)]
    public string StateProvinceCode { get; set; }

    [Required]
    [StringLength(50)]
    public string StateProvinceName { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [Required]
    [StringLength(50)]
    public string SalesTerritory { get; set; }

    public long? LatestRecordedPopulation { get; set; }

    public int LastEditedBy { get; set; }

    [InverseProperty("StateProvince")]
    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    [ForeignKey("CountryId")]
    [InverseProperty("StateProvinces")]
    public virtual Country Country { get; set; }

    [ForeignKey("LastEditedBy")]
    [InverseProperty("StateProvinces")]
    public virtual Person LastEditedByNavigation { get; set; }
}