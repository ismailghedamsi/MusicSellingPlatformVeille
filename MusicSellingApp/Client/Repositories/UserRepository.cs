﻿
using MusicSellingApp.Shared.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MusicSellingApp.Client.Repositories
{
  
    public class UserRepository : IUserRepository
    {

        public void DeleteStudent(int userID)
        {
            throw new NotImplementedException();
        }

        public User GetStudentByID(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User user)
        {
            //context.Add(user);
           // context.SaveChangesAsync();
        }

        public void Save()
        {
     
        }

        public void UpdateStudent(User student)
        {
            throw new NotImplementedException();
        }
    }
}