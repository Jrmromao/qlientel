﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmailTemplates.ViewModels
{
   public class EmailButtonViewModel
    {
        public string Text { get; set; }
        public string Url { get; set; }

        public EmailButtonViewModel(string text, string url)
        {
            Text = text;
            Url = url;
        }
    }
}
