using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;
//Created by Ruan Jordaan 603551

namespace FitForge
{// begin namespace
    class Program
    {// begin class Program

        // begin global var
        static// strings
            string sName, sSurname, sGuardian, sID, sJoin_date, sFavourite_smoothie_flavour, sEmployment_status, sYears, sMonths, sDays = "";

        static //int
            int iAge, iRank, iSmoothies_purchased, iSmoothies_consumed, iSmoothies_month, iYears, iMonths, iDays = 0;

        static // double
           double dPR_treadmill = 0;

        static //bool
          bool bEmployed, bValidID, bQualify = false;
        // end global var

        //Menu (enum)
        enum Menu
        {// begin enum Menu
            Capture_member_detail = 1,
            Check_wellness_reward_qualification,
            Show_FitForge_stats,
            Exit
        }// end enum Menu

        //Display Menu(method)
        static void DisplayMenu()
        {// begin method DisplayMenu
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("==                                                ==");
            Console.WriteLine("==--------THE FITFORGE WELLNESS CENTRE APP--------==");
            Console.WriteLine("==                                                ==");
            Console.WriteLine("==  1. Capture Member Details                     ==");
            Console.WriteLine("==  2. Check Wellness Reward Qualification        ==");
            Console.WriteLine("==  3. Show FitForge Statistics                   ==");
            Console.WriteLine("==  4. Exit                                       ==");
            Console.WriteLine("==                                                ==");
            Console.WriteLine("==---Select an option from the Menu to continue---==");
            Console.WriteLine("==                                                ==");
            Console.WriteLine("====================================================");
        }// end method DisplayMenu

        //Capturing the members detials
        static Dictionary<string, string> UserDetails(Dictionary<string, string> User_Details)
        {// begin return method UserDetails
            // var 
            bool brun = true;
            string sInput = "";

            while (brun == true)
            {// begin while brun = true

                Console.Clear();
                Console.WriteLine("Welcome to capture member details");
                Console.WriteLine();

                Console.WriteLine("Please enter the member name"); // getting user name and validate before adding to the dictionary
                sName = Console.ReadLine();
                Console.WriteLine();

                if (sName.Length < 2 || sName.Length > 20)
                {// begin if sName < 2 or sName > 20

                    sName = "";
                    Console.WriteLine("Please enter the member name"); // getting user name and validate before adding to the dictionary
                    sName = Console.ReadLine().ToUpper();

                }// end if sName < 2 or sName> 20
                else
                {// begin else if sName !<2 or sName !> 20

                    User_Details.Add("Member Name :", sName); // add user name to the dictionary

                }// end else if sName !<2 or sName !> 20

                Console.WriteLine("Please enter the member surname");// getting user surname and validate before adding to the dictionary 
                sSurname = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (sSurname.Length < 2 || sSurname.Length > 20)
                {// begin if sSurname < 2 or sSurname > 20

                    sSurname = "";
                    Console.WriteLine("Please enter the member surname");
                    sSurname = Console.ReadLine().ToUpper();

                }// end if sSurname < 2 or sSurname> 20
                else
                {// begin else if sName !<2 or sName !> 20

                    User_Details.Add("Member Surname :", sSurname); // add member surname to the dictionary

                }// end else if sName !<2 or sName !> 20

                Console.WriteLine("Please enter the members ID number");// getting user ID number and validate befote adding to the dictionary
                sID = Console.ReadLine();
                Console.WriteLine();

                if (sID.Length > 13 || sID.Length < 13)
                {// begin if sID <13> 

                    sID = "";
                    Console.WriteLine("Please enter the members ID number");// getting user ID number and validate befote adding to the dictionary
                    sID = Console.ReadLine();

                }// end if sID<13>
                else
                {// begin else sID = valid 


                    User_Details.Add("Member ID Number", sID);
                }// end else sID = Valid

                Console.WriteLine("Please enter the member age");
                iAge = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (iAge < 18)
                {// begin if iAge < 18

                    Console.WriteLine("Please enter does the member have a guardian");
                    sGuardian = Console.ReadLine();
                    Console.WriteLine();

                    User_Details.Add("Member Age", iAge.ToString()); // adding user age <18 to Dictionary

                    Console.WriteLine("Please enter Guardian name");
                    sGuardian = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (sName.Length < 2 || sName.Length > 20)
                    {// begin if sGuardian < 2 or sGuardian > 20

                        sGuardian = "";
                        Console.WriteLine("Please enter Guardian name"); // getting user name and validate before adding to the dictionary
                        sGuardian = Console.ReadLine().ToUpper();

                    }// end if sGuardian < 2 or sGuardian> 20
                    else
                    {// begin else if sGuardian !<2 or sGuardian !> 20

                        User_Details.Add("Member Guardian Name :", sGuardian); // add user name to the dictionary

                    }// end else if sGuardian !<2 or sGuardian !> 20


                    Console.WriteLine("Please enter yes/ no if the guardian is employed");
                    sEmployment_status = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    if (sEmployment_status == "YES")
                    {// begin if Guardian = employed

                        bEmployed = true;

                    }// end if Guardian = employed 
                    else
                    {// begin elseGuardian != employed

                        bEmployed = false;

                    }// end else Guardian != employed
                }// end if iAge < 18
                else
                {// begin else iAge > 18

                    User_Details.Add("Member Age : ", iAge.ToString());

                }// end else iAge > 18

                Console.WriteLine("Please enter the member rank");
                iRank = int.Parse(Console.ReadLine());
                User_Details.Add("Member Rank :", iRank.ToString());

                Console.WriteLine("Please enter member join date in format yyyy/mm/dd");
                sJoin_date = Console.ReadLine();
                Console.WriteLine();
                sYears = sJoin_date.Substring(0, 4);
                sMonths = sJoin_date.Substring(5, 2);
                sDays = sJoin_date.Substring(8, 2);

                if (sMonths != "01" || sMonths != "02" || sMonths != "03" || sMonths != "04" || sMonths != "05" || sMonths != "06"
                    || sMonths != "07" || sMonths != "08" || sMonths != "09" ||
                    sMonths != "10" || sMonths != "11" || sMonths != "12"  )
                {// begin if sMonth is not valid

                    sJoin_date = "";
                    Console.WriteLine("Please enter a valid month");
                    Console.WriteLine("Please enter member join date in format yyyy/mm/dd");
                    Console.WriteLine();
                    sJoin_date = Console.ReadLine();
                    sYears = sJoin_date.Substring(0, 4);
                    sMonths = sJoin_date.Substring(5, 2);
                    sDays = sJoin_date.Substring(8, 2);

                }//end if sMonth is not valid
                else 
                {// begin else sMonth is valid
                    User_Details.Add("Join Date : ", sJoin_date);
                }// end else sMotnh is valid 

                Console.WriteLine("Please enter the member amount of smoothies purchased");
                iSmoothies_purchased = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (iSmoothies_purchased < 0)
                {// begin if iSmoothies purchaced < 0

                    iSmoothies_purchased = 0;
                    Console.WriteLine("Please enter the amount of smoothies the member purchased start at 0");
                    iSmoothies_purchased = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                }// end if iSmoothies purchased < 0
                else
                {// begin else iSmoothies Purchased >=0

                    User_Details.Add("Member Smoothies Purchased :", iSmoothies_purchased.ToString());


                }// end else iSmoothies Purchased >= 0

                Console.WriteLine("Please enter the amount of smoothies the member has consumed within the month");
                iSmoothies_month = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (iSmoothies_month < 0)
                {// begin if iSmoothies /month is <0

                    iSmoothies_month = 0;
                    Console.WriteLine("Please enter a vaild number greater than 0");
                    Console.WriteLine("Please enter the amount of smoothies the member has consumed within the month");
                    iSmoothies_month = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                }// end if iSmoothies/month <0
                else 
                { // begin else iSmoothies / month > 0 

                    User_Details.Add("Member Smoothies Month :", iSmoothies_month.ToString());

                }// end else iSmoothies / month > 0

                Console.WriteLine("Please enter member personal best on the treadmil in km");
                dPR_treadmill = double.Parse(Console.ReadLine());
                Console.WriteLine();

                if (dPR_treadmill <0.0)
                {// begin if Pr < 0.0

                    dPR_treadmill = 0;
                    Console.WriteLine("Please ensure the personal record is more than 0.0 km");
                    Console.WriteLine("Please enter member personal best on the treadmil in km");
                    dPR_treadmill = double.Parse(Console.ReadLine());
                    Console.WriteLine();

                }// end if PR <0.0
                else
                {// begin else Pr is valid

                    User_Details.Add("Member PR : km", dPR_treadmill.ToString());

                }// end else PR is valid

                Console.WriteLine("Please enter the member employement status (YES/NO)");
                sEmployment_status = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (sEmployment_status.ToUpper() == "YES")
                {// begin if Member employed = true

                    User_Details.Add("Member Employement Status :", sEmployment_status);

                }// end if Member employed = true 
                else if (sEmployment_status.ToUpper() == "no")
                {// begin else Member employment = false

                    User_Details.Add("Member Employement Status", sEmployment_status);

                }// end else Mmeber empoyment = false
                else if (sEmployment_status.ToUpper() != "YES" || sEmployment_status.ToUpper() != "NO")
                {//  begin else Member employment = incorrect input

                    sEmployment_status = "";
                    Console.WriteLine("Please enter Yes or No");
                    Console.WriteLine("Please enter the member employement status (YES/NO)");
                    sEmployment_status = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                }// end else Mmeber employment - incorrect input

                Console.WriteLine("Please enter the member favourite smoothie flavour");
                sFavourite_smoothie_flavour = Console.ReadLine();
                Console.WriteLine();

                if (sFavourite_smoothie_flavour == "")
                {// begin if smoothie flavour is empty

                    sFavourite_smoothie_flavour = "";
                    Console.WriteLine("Please enter a favourite smootie flavour");
                    sFavourite_smoothie_flavour = Console.ReadLine();
                    Console.WriteLine();
                
                }// begin if smoothie flavour is empty
                {// else begin
                    User_Details.Add("Member favourite smoothie flavour", sFavourite_smoothie_flavour);
                }// else end 

                Console.WriteLine("Please enter the member amount of smoothies consumed since joining");
                iSmoothies_consumed = int.Parse(Console.ReadLine());
                User_Details.Add("Member Amount Smoothies Consumed :", iSmoothies_consumed.ToString());

                    Console.WriteLine("Do you want to add another applicant (YES/NO) ?");
                    sInput = Console.ReadLine().ToUpper();
                    if (sInput.ToUpper() == "YES")
                    {// begin if sInput = yes
                        brun = false;
                    break;
                    }// end if sInput = yes
                    else
                    {// begin else if sInput = no
                        Console.Clear();
                        UserDetails(User_Details);
                    }// end else if sInput = no

            }// end while brun = true 

            return (User_Details);// return the Dictionary

        }// end return method UserDetails
        static void Qualify(Dictionary<string, string> User_Detials)
        {// begin method Qualify 
            bQualify = false;

            if (User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes")
            {// begin if Member employed = true
                bQualify = true;
            }// end if Member employed = true

            if (User_Detials.ContainsValue("Member Age").ToString() == "1" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "2" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "3" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "4" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "5" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "6" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "7" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "8" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "9" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "10" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "11" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "12" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "13" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "14" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "15" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "16" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed

            if (User_Detials.ContainsValue("Member Age").ToString() == "17" && User_Detials.ContainsValue("Member Employement Status").ToString() == "Yes") ;
            {// begin if member < 18 and guardian is employed
                bQualify = true;
            } // end if member < 18 and quardian iis employed



            /* if (User_Detials.ContainsValue("Member PR : km").ToString() >= "20") ;
            {// begin if PR on treadmil > 20 km
                bQualify = true;
            }// end if PR on tradmil > 20 */

            if (User_Detials.ContainsKey("Member Amount Smoothies Consumed :").ToString() == "4") ;
            {// begin if member consumed more than 4 smoothies / month
                bQualify = true;
            }// end if member consumed more than 4 smoothies / month

            if (User_Detials.ContainsKey("Member Amount Smoothies Consumed :").ToString() == "20" || User_Detials.ContainsKey("Member favourite smoothie flavour :").ToString() == "ChocoChurned Chaos");
            {// begin if member consumed more than 4 smoothies / month
                bQualify = false;
            }// end if member consumed more than 4 smoothies / month




        }// end method Qualify
        static void Main(string[] args)
        {// begin Main
                            Console.Clear();

                            // local variables
                            int ichoice;
                            bool brun;
                            // initialize the var

                            //string
                            sName = "";
                            sSurname = "";
                            sID = "";
                            sJoin_date = "";
                            sFavourite_smoothie_flavour = " ";
                            sEmployment_status = "";

                            //int
                            iAge = 0;
                            iRank = 0;
                            iSmoothies_purchased = 0;
                            iSmoothies_consumed = 0;
                            ichoice = 0; // var used in menu

                            //double
                            dPR_treadmill = 0;

                            // bool
                            bEmployed = false;
                            brun = true; // var used in menu

                            Dictionary<string, string> User_Details = new Dictionary<string, string>();
                            
                            while (brun == true)
                            {// begin while brun Main = true

                                DisplayMenu(); // Display Menu via method
                                ichoice = int.Parse(Console.ReadLine()); // getting user menu choice

                                Menu menu = (Menu)ichoice;
                                switch (menu)
                                {
                                    case Menu.Capture_member_detail:
                                   UserDetails(User_Details);
                                        break;

                                    case Menu.Check_wellness_reward_qualification:
                                        Console.Clear();

                                        Console.ReadLine();
                                        break;

                                    case Menu.Show_FitForge_stats:
                                        Console.Clear();
                                        Console.ReadLine();
                                        break;

                                    case Menu.Exit:
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        brun = false;
                                        break;
                                }


                            }// end while brun Main = true

                            Console.ReadLine();


        }// end Main


    }// end class Program
}// end namespace
