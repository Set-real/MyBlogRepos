﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Model.ViewModels
{
    public class MainViewModel
    {
        public RegisterViewModel RegisterView { get; set; }

        public LoginViewModel LoginView { get; set; }


        public MainViewModel()
        {
            RegisterView = new RegisterViewModel();
            LoginView = new LoginViewModel();
        }
    }
}
