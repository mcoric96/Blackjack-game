using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackjack;
namespace OTTER
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            BGL.user.SetNewCard(545, 380);
        }

        private void btnNovaKarta_Click(object sender, EventArgs e)
        {
            

        }
    }
}
