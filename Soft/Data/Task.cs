﻿namespace Soft.Data
{
    public class Task
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TeamSize { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
