using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SVDown.Model;
using SVDown.View;

namespace SVDown.Controller
{
    public interface IController
    {
        void setModel(IModel im);
        void setView(IView iv);
        void newTask(String url,String saveName,String path);
        void startDownload();
    }
}
