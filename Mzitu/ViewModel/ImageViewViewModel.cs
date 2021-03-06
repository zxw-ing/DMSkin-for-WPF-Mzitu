﻿using Mzitu.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace Mzitu
{
    public class ImageViewViewModel : ModelObject
    {
        private static ImageViewViewModel _HomePageViewModel;

        public static ImageViewViewModel Initialization()
        {
            if (_HomePageViewModel == null)
            {
                _HomePageViewModel = new ImageViewViewModel();
            }
            return _HomePageViewModel;
        }

        public void LoadImage()
        {
            Image = "";
            API.ImagePage(Id,PageIndex, new Action<string, int>((imageitem, pageSize) =>
             {
                 App.DispatcherHelper.Invoke(new Action(() =>
                {
                    Image = imageitem;
                }));
             })
             , new Action<Exception>((ex) =>
             {
                 
             }));
        }

        private string image = "http://i.meizitu.net/pfiles/img/logo.png";
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }
        int pageIndex = 1;
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                pageIndex = value;
                OnPropertyChanged("PageIndex");
            }
        }


        private string id = "0";
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        internal void Next()
        {
            PageIndex++;
            LoadImage();
        }

        internal void Previou()
        {
            if (PageIndex > 1)
            {
                PageIndex--;
                LoadImage();
            }
        }
    }
}
