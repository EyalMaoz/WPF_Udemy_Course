using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public class LoginVM
    {
        private User m_user;

        public User User
        {
            get { return m_user; }
            set { m_user = value; }
        }
        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public LoginVM()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }
    }
}
