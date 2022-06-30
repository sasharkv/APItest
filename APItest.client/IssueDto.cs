﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APItest.client
    // DTO is siilar to the Model in the API
{
    internal class IssueDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }

    public enum Priority
    {
        Low, Medium, High
    }

    public enum IssueType
    {
        Feature, Bug, Documentation
    }
}
