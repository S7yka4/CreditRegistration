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
    [Table("loan_order",Schema = DefaultDbConfiguration.DefaultSchemaName),Index(nameof(OrderId),nameof(UserId))]
    public class LoanOrder
    {
        [Key, Column("id"), NotNull]
        public long? Id { get; set; }
        [Column("order_id"), NotNull]
        public string OrderId { get; set; }
        [Column("user_id"), NotNull]
        public long UserId { get; set; }
        [Column("tariff_id"), NotNull]
        public long TarrifId { get; set; }
        [Column("credit_rating"), NotNull]
        public double CreditRating { get; set; }
        [Column("status"), NotNull]
        public string Status { get; set; }
        
        DateTime timeInsert;
        DateTime timeUpdate;
        [Column("time_insert"), NotNull]
        public DateTime TimeInsert
        {
            get
            {
                return timeInsert;
            }
            set
            {
                timeInsert = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }

        }
        [Column("time_update"), NotNull]
        public DateTime TimeUpdate 
        {
            get
            {
                return timeUpdate;
            }
            set
            {
                timeUpdate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
        }

        public LoanOrder() { }
    }

    public static  class LoanOrderStatus
    {
        public static string InProgress = "IN_PROGRESS";
        public static string Refused = "REFUSED";
        public static string Approved = "APPROVED";
    }

}
