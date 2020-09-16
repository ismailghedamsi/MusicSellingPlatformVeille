using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Client.Repositories
{
    interface IUserRepository
    {

        IEnumerable<User> GetStudents();
        User GetStudentByID(int userId);
        void InsertUser(User user);
        void DeleteStudent(int userID);
        void UpdateStudent(User student);
        void Save();
    }
}
