using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSellingApp.Client.Repositories
{
    interface IUserRepository
    {

        IEnumerable<Artist> GetStudents();
        Artist GetStudentByID(int userId);
        void InsertUser(Artist user);
        void DeleteStudent(int userID);
        void UpdateStudent(Artist student);
        void Save();
    }
}
