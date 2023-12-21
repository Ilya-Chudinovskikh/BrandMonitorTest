using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BrandMonitorTest.Models.Entities
{
    /// <summary>
    /// Описание таблицы
    /// </summary>
    [Table("MainTable")]
    public class TaskEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Текущее время
        /// </summary>
        [Column("Time")]
        public TimeOnly Time { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [Column("Status")]
        public Enums.TaskStatusType Status { get; set; }

        public TaskEntity()
        {
            Id = Guid.NewGuid();
            Time = TimeOnly.FromDateTime(DateTime.Now);
            Status = Enums.TaskStatusType.Created;
        }
    }
}
