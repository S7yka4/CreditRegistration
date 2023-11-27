using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CreditRegistration.DbCommon.Models
{
    [Table("tariff", Schema = DefaultDbConfiguration.DefaultSchemaName), Index(nameof(Id))]

    public class Tarrif
    {
        [Key, Column("id"), NotNull]
        public long? Id { get; set; }
        [Column("type"), NotNull, MaxLength(40)]
        public string Type { get; set; }
        [Column("interest_rate"), NotNull, MaxLength(10)]
        public string InterstRate { get; set; }

        public Tarrif() { }
    }
}
