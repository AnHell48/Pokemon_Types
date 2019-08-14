using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKM_Strgs_Wkns
{
    /*
     *  By : Angel A. Robles
     *       march/1/2016
     */
    class PKM_StWk
    {
        #region Types
        //int normal_,fire_,water_,grass_,electric_,rock_,ground_,fighting_,
        //ice_,flying_,poison_,psychic_,ghost_,dark_,bug_,dragon_,steel_,fairy_;
        #endregion
        string titi;
        string[] types_;
        int no_effective, normal_effective, super_effective;
        double not_very_effective;
        bool ischeck;
        int type_;
        int[,] weak_strgh_chart;
        List<string> weak_list;
        List<string> notvery_list;
        List<string> noeff_list;
        List<string> strong_list;

        public void Init(int type_numb, bool chk)
        {
            #region Types
            //normal_ = 0;
            //fire_ = 1;
            //water_ = 2;
            //grass_ = 3;
            //electric_ = 4;
            //rock_ = 5;
            //ground_ = 6;
            //fighting_ = 7;
            //ice_ = 8;
            //flying_ = 9;
            //poison_ = 10;
            //psychic_ = 11;
            //ghost_ = 12;
            //dark_ = 13;
            //bug_ = 14;
            //dragon_ = 15;
            //steel_ = 16;
            //fairy_ = 17;
            #endregion
            types_ = new string[18] { "Normal", "Fire", "Water",  "Electric","Grass","Ice", "Fighting", "Poison", "Ground","Flying","Psychic","Bug", "Rock","Ghost", "Dragon", "Dark", "Steel", "Fairy" };
            weak_list = new List<string>();
            notvery_list = new List<string>();
            noeff_list = new List<string>();
            strong_list = new List<string>();
            no_effective = 0;
            not_very_effective = 0.5;
            normal_effective = 1;
            not_very_effective = 2;

            ischeck = chk;
            type_ = type_numb;
            Str_WkChart();            
        }

        private void Str_WkChart()
        {
            // 1 = normal eft | 0 = not effect | 5 = 0.5 not very | 2 = super efftc
            // X --> strong | Y down -- weak against
            #region Type chart
            weak_strgh_chart = new int[18, 18] 
            {              
                /*Normal*/  {1,1,1,1,1,1,1,1,1,1,1,1,5,0,1,1,5,1},
                /*Fire*/    {1,5,5,1,2,2,1,1,1,1,1,2,5,1,5,1,2,1},
                /*Water*/   {1,2,5,1,5,1,1,1,2,1,1,1,2,1,5,1,1,1},
                /*Elect*/   {1,1,2,5,5,1,1,1,0,2,1,1,1,1,5,1,1,1},
                /*Grass*/   {1,5,2,1,5,1,1,5,2,5,1,5,2,1,5,1,5,1},
                /*Ice*/     {1,5,5,1,2,5,1,1,2,2,1,1,1,1,2,1,5,1},
                /*Fighting*/{2,1,1,1,1,2,1,5,1,5,5,5,2,0,1,2,2,5},
                /*Poison*/  {1,1,1,1,2,1,1,5,5,1,1,1,5,5,1,1,0,2},
                /*Ground*/  {1,2,1,2,5,1,1,2,1,0,1,5,2,1,1,1,2,1},
                /*Flying*/  {1,1,1,5,2,1,2,1,1,1,1,2,5,1,1,1,5,1},
                /*Psychic*/ {1,1,1,1,1,1,2,2,1,1,5,1,1,1,1,0,5,1},
                /*Bug*/     {1,5,1,1,2,1,5,5,1,5,2,1,1,5,1,2,5,5},
                /*Rock*/    {1,2,1,1,1,2,5,1,5,2,1,2,1,1,1,1,5,1},
                /*Ghost*/   {0,1,1,1,1,1,1,1,1,1,2,1,1,2,1,5,1,1},
                /*Dragon*/  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,5,0},
                /*Dark*/    {1,1,1,1,1,1,5,1,1,1,2,1,1,2,1,5,1,5},
                /*Steel*/   {1,5,5,5,1,2,1,1,1,1,1,1,2,1,1,1,5,2},
                /*Fairy*/   {1,5,1,1,1,1,2,5,1,1,1,1,1,1,2,2,5,1}
            };
            #endregion
        }

        public void WeakAgainst()
        {
            // go trough all the types (down)
            for (int down= 0; down <= 17; down++)
            {
                if (weak_strgh_chart[down, type_] == 2)
                {
                    // add the name of the type to a list
                    string temp = types_[down];
                    weak_list.Add(temp );                    
                }
                else if (weak_strgh_chart[down, type_] == 0)
                {
                    string temp = types_[down];
                    noeff_list.Add(temp);
                }
                else if (weak_strgh_chart[down, type_] == 5)
                {
                    string temp = types_[down];
                    notvery_list.Add(temp);
                }
            }           
        }

        public void AttackAgainst()
        {
            //weak_strgh_chart[type_,0];
            for (int right = 0; right <= 17; right++)
            {
                if (weak_strgh_chart[type_,right] == 2)
                {
                    // add the type number(position)
                    string temp = types_[right];
                    strong_list.Add(temp);
                }
                
            }
        }

        public void DualType(List<int> dualtypes)//int pkm_type1, int pkm_type2)
        {
            int type1 = dualtypes.ElementAt(0);
            int type2 = dualtypes.ElementAt(1);

            for (int down = 0; down <= 17; down++)
            {
                int temp_down;
                //double notveryeff_;
                //if (weak_strgh_chart[down, type1] == 5 )
                //{
                //    notveryeff_= 0.5;
                //    temp_down = notveryeff_ * Convert.ToDouble( weak_strgh_chart[down, type2]);
                //}
                temp_down = weak_strgh_chart[down, type1] * weak_strgh_chart[down, type2];
                
                if (temp_down == 2 || temp_down == 4)
                {                    
                    // add the name of the type to a list
                    string temp = types_[down];
                    weak_list.Add(temp);
                }
                else if (temp_down == 0)
                {
                    string temp = types_[down];
                    noeff_list.Add(temp);
                }
                else if (temp_down== 5 || temp_down== 25 ||temp_down== 10 )
                {
                    string temp = types_[down];
                    notvery_list.Add(temp);
                }

                // check for strong against
                int temp_side = down;
                temp_side = weak_strgh_chart[type1,down] * weak_strgh_chart[type2,down];
                if (temp_side == 2)
                {
                    string temp = types_[down];
                    strong_list.Add(temp);
                }
            }

        }

        public List<string> SendWeak()
        {
            return weak_list;
        }
        public List<string> SendStrong()
        {
            return strong_list;
        }
        public List<string> SendNotVery()
        {
            return notvery_list;
        }
        public List<string> SendNoEffect()
        {
            return noeff_list;
        }


    }
}
