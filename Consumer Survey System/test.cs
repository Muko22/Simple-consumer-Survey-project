using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumer_Survey_System
{
    public partial class test : UserControl
    {
        private static test _instance;
        public static test Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new test();
                return _instance;
            }
        }
        public test()
        {
            InitializeComponent();
        }
    }
}
