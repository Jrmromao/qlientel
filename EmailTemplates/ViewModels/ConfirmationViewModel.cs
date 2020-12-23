using System;
using System.Collections.Generic;
using System.Text;

namespace EmailTemplates.ViewModels
{
   public class ConfirmationViewModel
    {

     
            public string Text { get; set; }
            public string Url { get; set; }

            public ConfirmationViewModel(string text, string url)
            {
                Text = text;
                Url = url;
            }

    }
}
