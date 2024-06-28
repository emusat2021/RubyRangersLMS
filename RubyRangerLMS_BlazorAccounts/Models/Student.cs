﻿namespace RubyRangerLMS_BlazorAccounts.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid CourseId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}