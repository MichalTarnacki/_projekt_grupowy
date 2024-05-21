﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchCruiseApp_API.Data;

public class Contract
{
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public Guid Id { get; set; }
      
      //[Range(0, 1)]
      public string Category { get; set; }
      
      [MaxLength(50)]
      public string Institution { get; set; }
      
      [MaxLength(200)]
      public string Description { get; set; }
  
      [MaxLength(50)]
      public string Location { get; set; }

      [MaxLength(50)] 
      public string Unit { get; set; }

      //public string File { get; set; }
}