﻿using System;
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
using System.Windows.Shapes;

namespace MailHw
{
    /// <summary>
    /// Логика взаимодействия для MailContent.xaml
    /// </summary>
    public partial class MailContent : Window
    {
        public MailContent(string text)
        {
            InitializeComponent();

            mailContent.Text = text;

        }
    }
}
