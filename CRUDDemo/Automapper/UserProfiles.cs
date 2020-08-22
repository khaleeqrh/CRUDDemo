using AutoMapper;
using CRUDDemo.Models;
using CRUDDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDDemo.Automapper
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserVM>().ReverseMap();
            //CreateMap<User, UserVM>();
        }
    }
}
