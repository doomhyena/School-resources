using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiftesThreades
{
    public partial class Form1 : Form
    {
        Lift lift;
        Thread prog_szal;
        Thread lift_szal;
        public Form1()
        {
            InitializeComponent();
            lift = new Lift(1);
            prog_szal = new Thread(prog_add);
            
            lift_szal = new Thread(mozgas);
            lblStatus.Text = lift.emelet+"";
            
        }

        public void prog_add()
        {Random rnd = new Random();
            while (true)
            {
                Thread.Sleep(3000);
                lift.program.Add(rnd.Next(1, 10));
                if (lift.program.Count > 1)
                {
                    //lblProg.Text = lift.program[0] + ", " + lift.program[1];
                    lblProg.Invoke(
                       (MethodInvoker)(
                       () => lblProg.Text = 
                       lift.program[0] + ", " + lift.program[1]));

                }
            }

        }

        public void mozgas()
        {
            while (true)
            {
                if (lift.program.Count > 0)
                {
                    if (lift.program[0] == lift.emelet)
                    {
                        lblInfo.Invoke(
                            (MethodInvoker)(
                            () => lblInfo.Text = "Már itt vagy..."));
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        lblInfo.Invoke(
                            (MethodInvoker)(
                            () => lblInfo.Text =
                            lift.emelet+". emeletről megy "+
                            lift.program[0]+". emeletre"));
                        Thread.Sleep(Math.Abs(lift.emelet-lift.program[0]) *3000);
                        lift.emelet = lift.program[0];
                        lblStatus.Invoke((MethodInvoker)(() => lblStatus.Text = lift.emelet+""));
                    }
                    lift.program.RemoveAt(0);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            prog_szal.Start();
            lift_szal.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            prog_szal.Abort();
            lift_szal.Abort();
        }
    }
}
