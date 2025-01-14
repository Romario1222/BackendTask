﻿using System.ComponentModel.DataAnnotations;
namespace BackendTask;

public class UserManager
{
    private UserDatabaseRepository _userDatabaseRepository = new UserDatabaseRepository();
    private List<ValidationResult>? IsValidated(ValidatedUserDto user)
    {
        var context = new ValidationContext(user);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(user, context, results, true))
        {

            foreach (var error in results)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            Console.WriteLine();
            return results;
        }
        else
        {
            return null;
        }
    }
   
    public string AddUser(ValidatedUserDto user)
    {
        var currUser = user;
        currUser.id = CreateId();
        if (currUser.id == 0)
        {
            return "Cannot create id, maybe all ids are already taken";
        }
        else
        {
            currUser.updated_at = DateTime.Now;
            currUser.created_at = DateTime.Now;
            var results = IsValidated(currUser);
            if (results == null)
            {
                Console.WriteLine(currUser.id);
                return _userDatabaseRepository.CreateUser(currUser);
            }
            else
            {
                string ErrorString = "";
                foreach (var error in results)
                {
                    ErrorString += error.ErrorMessage + System.Environment.NewLine;
                }
                return ErrorString;
            }
        }
       
        
    }
    public string DeleteUser(int id)
    {
        var getedUser = _userDatabaseRepository.GetUserById(id);
        if (getedUser == null)
        {
            return "No user with such id!";
        }
        else
        {
            return _userDatabaseRepository.DeleteUser(id);
        }
    }
    public string UpdateUser(ValidatedUserDto user)
    {
        var curruser = user;
        var getedUser = _userDatabaseRepository.GetUserById(curruser.id);
        if (getedUser == null)
        {
            return "No user with such id!";
        }
        else
        {
            curruser.created_at = getedUser.created_at;
            curruser.updated_at = DateTime.Now;
            var results = IsValidated(curruser);
            if (results == null)
            {
                Console.WriteLine(curruser.id);
                return _userDatabaseRepository.UpdateUser(curruser);
            }
            else
            {
                string ErrorString = "";
                foreach (var error in results)
                {
                    ErrorString += error.ErrorMessage + System.Environment.NewLine;

                }
                return ErrorString;
            }
        }
           
       
    }
    public ValidatedUserDto GetUser(int id)
    {

        return _userDatabaseRepository.GetUserById(id);
    }
    public ValidatedUserDto GetUser(string username)
    {
        
        return _userDatabaseRepository.GetUserByName(username);
        
       
    }
    private int CreateId()
    {
        int c = 0;
        Random rnd = new Random();
        var buffer = new byte[sizeof(int)];
        rnd.NextBytes(buffer);
        var id= Math.Abs(BitConverter.ToInt32(buffer, 0));
        while(_userDatabaseRepository.GetUserById(id)!=null)
        {
            
            var buffer1 = new byte[sizeof(int)];
            rnd.NextBytes(buffer1);
            id = Math.Abs(BitConverter.ToInt32(buffer1, 0));
            if (c > 10000)
            {
                return 0;
            }
            c++;
        }
        return id;
    }
    public string IsUserName(string userName)
    {
        
        bool flag = false;
        foreach (var item in "\"';<>?/{}[]@#$%^&*()-+=_ ")
        {
            if (userName.Contains(item))
            {
                flag = true;
            }
        }
        if (userName.ToLower() != "admin" && flag == false && userName.Length>=5 && userName.Length<=50)
        {
            return "";
        }
        else
        {
            if ((userName.Length < 5 || userName.Length > 50))
            {
                if(flag==true)
                {
                    return "Invalid username length!" + System.Environment.NewLine + "Invalid username: " + userName;
                }
                else
                {
                    return "Invalid username length!";
                }
            }
            else
            {
                return "Invalid username: " + userName;
            }
        }

      
    }
    public string IsId(int id)
    {

        if (id > 0)
        {
            return "";
        }
        else
        {
            return  "Invalid user id!";
        }

    }
 }
