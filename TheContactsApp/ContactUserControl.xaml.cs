using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheContactsApp.Entities;

namespace TheContactsApp
{
    /// <summary>
    /// Interaction logic for ContactUserControl.xaml
    /// </summary>
    public partial class ContactUserControl : UserControl
    {
        public new string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Contact Contact
        {
            get { return (Contact)GetValue(contactProperty); }
            set { SetValue(contactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty contactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactUserControl), new PropertyMetadata(new Contact(), SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContactUserControl control && e.NewValue is Contact newContact)
            {
                control.Contact = newContact;
                /* control.ContactName = newContact.Name;
                 control.Email = newContact.Email;
                 control.PhoneNumber = newContact.PhoneNumber;*/
            }
        }

        public ContactUserControl()
        {
            InitializeComponent();
        }
    }
}
