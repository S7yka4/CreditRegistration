using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistration.DbCommon.Models
{
    [Table("tariff", Schema = DefaultDbConfiguration.DefaultSchemaName),Index(nameof(Id))]

    public class Tarrif
    {
        [Key, Column("id"), NotNull]
        public long? Id { get; set; }
        [Column("type"), NotNull]
        public string Type { get; set; }
        [Column("interest_rate"), NotNull]
        public string InterstRate { get; set; }

        public Tarrif() { }
    }
}
