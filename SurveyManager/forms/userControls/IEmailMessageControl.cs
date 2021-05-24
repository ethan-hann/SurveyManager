using CefSharp.WinForms;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.forms.userControls
{
    public interface IEmailMessageControl
    {
        public ChromiumWebBrowser Browser { get; internal set; }

        public MimeMessage MessageDetails { get; internal set; }

        public int UniqueHash { get; internal set; }
    }
}
