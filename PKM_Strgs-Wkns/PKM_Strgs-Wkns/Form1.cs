using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PKM_Strgs_Wkns
{
    /*
     *  By : Angel A. Robles
     *  march/1/2016
     */ 

    public partial class Form1 : Form
    {
       PKM_StWk PokeSW = new PKM_StWk();
       int type_number;
        string [] typess_ = new string[18] { "Normal", "Fire", "Water",  "Electric","Grass","Ice", "Fighting", "Poison", "Ground","Flying","Psychic","Bug", "Rock","Ghost", "Dragon", "Dark", "Steel", "Fairy" };

        bool chek;
        List<int> dualtypes = new List<int>();
        public Form1()
        {
			
           // type_number = 0;
            InitializeComponent();
        } 
        
        private void check_dualtype_CheckedChanged(object sender, EventArgs e)
        {
            if (check_dualtype.Checked)
            {
                chek = true;
            }
            else
            {
                chek = false;
            }
        }

        private void btn_fire_Click(object sender, EventArgs e)
        {
            type_number = 1;
            GetStrWk();
           
        }

        private void btn_normal_Click(object sender, EventArgs e)
        {
            type_number = 0;
            GetStrWk();
        }
               
        private void btn_water_Click(object sender, EventArgs e)
        {
            type_number = 2;
            GetStrWk();

        }

        private void btn_grass_Click(object sender, EventArgs e)
        {
            type_number = 4;
            GetStrWk();

        }

        private void btn_electr_Click(object sender, EventArgs e)
        {
            type_number = 3;
            GetStrWk();

        }

        private void btn_rock_Click(object sender, EventArgs e)
        {
            type_number = 12;
            GetStrWk();
        }

        private void btn_bug_Click(object sender, EventArgs e)
        {
            type_number = 11;
            GetStrWk();

        }

        private void btn_ice_Click(object sender, EventArgs e)
        {
            type_number = 5;
            GetStrWk();

        }

        private void btn_fight_Click(object sender, EventArgs e)
        {
            type_number = 6;
            GetStrWk();

        }

        private void btn_flying_Click(object sender, EventArgs e)
        {
            type_number = 9;
            GetStrWk();
        }

        private void btn_psychic_Click(object sender, EventArgs e)
        {
            type_number = 10;
            GetStrWk();

        }

        private void btn_dark_Click(object sender, EventArgs e)
        {
            type_number = 15;
            GetStrWk();

        }

        private void btn_steel_Click(object sender, EventArgs e)
        {
            type_number = 16;
            GetStrWk();

        }

        private void btn_ghost_Click(object sender, EventArgs e)
        {
            type_number = 13;
            GetStrWk();

        }

        private void btn_dragon_Click(object sender, EventArgs e)
        {
            type_number = 14;
            GetStrWk();

        }

        private void btn_poison_Click(object sender, EventArgs e)
        {
            type_number = 7;
            GetStrWk();

        }

        private void btn_ground_Click(object sender, EventArgs e)
        {
            type_number = 8;
            GetStrWk();

        }

        private void btn_fairy_Click(object sender, EventArgs e)
        {
            type_number = 17;
            GetStrWk();

        } 
        
        private void GetStrWk()
        {
            PokeSW.Init(type_number,chek);
            if (!chek)
            {
                label1.Text = typess_[type_number];
                PokeSW.WeakAgainst();
                PokeSW.AttackAgainst();
            }
            else
            {
                dualtypes.Add(type_number);
                                
                if (dualtypes.Count == 2 && dualtypes.ElementAt(0) != dualtypes.ElementAt(1))
                {
                    label1.Text = typess_[dualtypes.ElementAt(0)] + "/" + typess_[dualtypes.ElementAt(1)];
                    PokeSW.DualType(dualtypes);
                    dualtypes.Clear();
                }
            }

            // set the result to labels
            StringBuilder sbd = new StringBuilder();
            foreach (string type in PokeSW.SendWeak())
            {
                sbd.Append(type).Append("\n");
            }
            lbl_weak.Text = sbd.ToString();

            sbd.Clear();

            foreach (string type in PokeSW.SendStrong())
            {
                sbd.Append(type).Append("\n");
            }
             lbl_strong.Text = sbd.ToString();

             sbd.Clear();

            foreach (string type in PokeSW.SendNotVery())
            {
                sbd.Append(type).Append("\n");
            }
             lbl_notvery.Text = sbd.ToString();
            
            sbd.Clear();

            foreach (string type in PokeSW.SendNoEffect())
            {
                sbd.Append(type).Append("\n");
            }
             lbl_noeffect.Text = sbd.ToString();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by: \n Angel A. Robles\n\t2016");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to use: \n\n Select a type and this will display the type effectiveness under the buttons. \n\n Dual Types: \n Checkmark the 'dual type' button and select both types.");
        }
    }
}
