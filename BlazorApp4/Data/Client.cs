using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class Client
    {
        public ObjectId MyProperty { get; set; }
        [Required]
        [MaxLength(5)]
        public string Name { get; set; }
    }
}
