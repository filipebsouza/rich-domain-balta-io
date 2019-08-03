using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudent(string document)
        {
            return student => student.Document != null && student.Document.Number == document;
        }
    }
}