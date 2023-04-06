﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BOilerplate.ViewModel
{
    public abstract class ViewModelBase:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
