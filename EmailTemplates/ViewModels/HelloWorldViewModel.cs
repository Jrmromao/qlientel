using System;
using System.Collections.Generic;
using System.Text;

namespace EmailTemplates.ViewModels
{
  public  class HelloWorldViewModel
    {
        public string ButtonLink { get; set; }

        public HelloWorldViewModel(string buttonLink)
        {
            ButtonLink = buttonLink;
        }
    }
}
