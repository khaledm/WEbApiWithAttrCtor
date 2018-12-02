using System;
using System.Collections.Generic;
using System.Linq;

namespace WEbApiWithAttrCtor.Models
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        IEnumerable<T> GetBy(Func<T, bool> searchBy);
    }

    public class CourseRepository : IRepository<Course>
    {
        private static IList<Course> _courses;

        /// <summary>
        /// ctor
        /// </summary>
        public CourseRepository()
        {
            _courses = GenerateCourses();
        }

        private IList<Course> GenerateCourses()
        {
            return new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Title = "Advanced Course",
                    Instructor = "Mr Ploppy",
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Id = 1,
                            Title = "Mrs",
                            FirstName = "fname",
                            LastName = "lname",
                            Gender = "female",
                            EmailAddress = "e.mail@address.com",
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>
        public IList<Course> GetAll()
        {
            return _courses;
        }

        /// <summary>
        /// get by
        /// </summary>
        /// <param name="searchBy"></param>
        /// <returns></returns>
        public IEnumerable<Course> GetBy(Func<Course, bool> searchBy)
        {
            return _courses.Where(searchBy);
        }
    }
}