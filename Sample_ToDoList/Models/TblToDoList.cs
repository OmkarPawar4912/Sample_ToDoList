using System;
using System.Collections.Generic;

namespace Sample_ToDoList.Models
{
    public partial class TblToDoList
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Status { get; set; }
    }
}
