﻿using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Domain.Entities;


public class Contract : Entity
{
      [StringLength(1024)]
      public string Category { get; init; } = null!;
      
      [MaxLength(1024)]
      public string InstitutionName { get; init; } = null!;
      
      [MaxLength(1024)] 
      public string InstitutionUnit { get; init; } = null!;
      
      [MaxLength(1024)]
      public string InstitutionLocalization { get; init; } = null!;
      
      [MaxLength(1024)]
      public string Description { get; init; } = null!;

      private string? _scanName;
      
      [MaxLength(1024)]  
      public string ScanName
      {
            get => _scanName ?? throw new InvalidOperationException("ScanName has not been set.");
            set
            {
                  if (_scanName is not null)
                        throw new InvalidOperationException("ScanName can only be set once.");
                  _scanName = value;
            }
      }

      private byte[]? _scanContent;

      public byte[] ScanContent
      {
            get => _scanContent ?? throw new InvalidOperationException("ScanContent has not been set.");
            set
            {
                  if (_scanContent is not null)
                        throw new InvalidOperationException("ScanContent can only be set once.");
                  _scanContent = value;
            }
      }

      public List<FormAContract> FormAContracts { get; init; } = [];
      
      
      public override bool Equals(object? other)
      {
            if (other is not Contract otherContract)
                  return false;
          
            return otherContract.Category == Category &&
                   otherContract.InstitutionName == InstitutionName &&
                   otherContract.InstitutionUnit == InstitutionUnit &&
                   otherContract.InstitutionLocalization == InstitutionLocalization &&
                   otherContract.Description == Description &&
                   otherContract.ScanName == ScanName &&
                   otherContract.ScanContent.SequenceEqual(ScanContent);
      }

      public override int GetHashCode()
      {
            return Category.GetHashCode() +
                   InstitutionName.GetHashCode() +
                   InstitutionUnit.GetHashCode() +
                   InstitutionLocalization.GetHashCode() +
                   Description.GetHashCode() +
                   ScanName.GetHashCode() +
                   ScanContent.GetHashCode();
      }
}
