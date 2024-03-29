/*
 * Paperless Rest Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NPaperless.Services.Converters;

namespace NPaperless.Services.DTOs
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SelectionDataRequest 
    {
        /// <summary>
        /// Gets or Sets Documents
        /// </summary>
        [Required]
        [DataMember(Name="documents", EmitDefaultValue=false)]
        public List<int> Documents { get; set; }

    }
}
