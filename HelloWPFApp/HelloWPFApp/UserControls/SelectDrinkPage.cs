using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.IO;
using System.Windows.Input;
using System.Windows.Controls.Ribbon;
using System.Windows.Automation.Peers;
using System.Collections.ObjectModel;

namespace HelloWPFApp.UserControls
{
    public partial class UserSelection : UserControl
    {
        public Visibility Visible { get; private set; }

        public Visibility Collapsed { get; private set; }
       // public object Dictionaries { get; private set; }
        public TextBox ActiveControl { get; private set; }

        public ObservableCollection<MyCommandWrapper> MyCommands {get; set;}
        MyCommands.Add(new MyCommandWrapper(){Command = MyTestCommmand1, DisplayName = "Test 1"});
        public void SelectDrinkPage()
        {
            InitializeComponent();          
        }

        public class MyCommandWrapper
        {
            public ICommand Command {get; set;}
            public string DisplayName {get; set;}
        }

        public int CreateButtons()
        {
            //string x = "";
            //string y = "";
            int button_count = 0;

            string DrinksList = File.ReadAllText("C:\\Users\\khern\\Desktop\\C#\\HelloWPFApp\\HelloWPFApp\\Drinks_List\\Drinks_List.txt");
            string[] x = File.ReadAllLines("C:\\Users\\khern\\Desktop\\C#\\HelloWPFApp\\HelloWPFApp\\Drinks_List\\Drinks_List.txt");
            string[] lines = DrinksList.Split(Environment.NewLine);
            string[] drink_name = new string[x.Count() / 4];
            Button newButton = new Button();
            ThicknessConverter thickcon = new ThicknessConverter();
            newButton.Height = 25;
            newButton.Width = 80;
           // newButton.Location = 
            //MessageBox.Show(x.Count().ToString());
            for (int a = 0; a < x.Count(); a += 4)
            {

                //MessageBox.Show(a.ToString());
                drink_name[button_count] = lines[a].ToString();
                button_count += 1;
                //MessageBox.Show(lines.ToString());

            }
            // int ButtonPosX = Int16.Parse(lines[lines.Length-2].ToString());
            // int ButtonPosY = Int16.Parse(lines[lines.Length-1].ToString());
            for (int b = 2; b < x.Count() - 2; b += 4)
            {
                //int ButtonPosX = Int16.Parse(lines[b].ToString());
                // int ButtonPosY = Int16.Parse(lines[b+1].ToString());
                string location = "{0}, {1}, 0, 0";
                string data = string.Format(location, lines[b], lines[b + 1]);
                // MessageBox.Show(data);
                // MessageBox.Show(b.ToString());

                Thickness buttThick = (Thickness)thickcon.ConvertFromString(data);
                newButton.Margin = buttThick;
            }

            for (int c = 1; c < button_count; c += 1)
            {
                //variable with number of buttons then make for statement to make each button visible after select button is clicked

                newButton.Name = "drink" + c;
                newButton.Content = drink_name[c];

                newButton.Click += DrinkConfirm;
                newButton.Visibility = Visibility.Visible;
                
                //UserSelection.Add(newButton);

                //this.grid.Children.Add(newButton);
               // this.grid.Children.Remove(newButton);
                MessageBox.Show(newButton.Name);
                // grid.Children.Remove(newButton);
                // grid.Children.Add(newButton);
                //MessageBox.Show(newButton.Visibility.ToString());
                //return;
            }
            return button_count;
           // MessageBox.Show(newButton.Margin.ToString());
            //return;
            //UserSelection.SelectDrinkPage.ScrollViewer.Add(newButton);
        }
        /*public void Thing(string drink_name)
        {
            string dictName = drink_name;
            //Makes a dictionary list to keep track of drink contents. Will have software modify each element when creating drinks
            //Will have to set variable for dictionary name as name inputed for drink creation
            dictName.Add("Jack",2);
            dictName.Add("Coke",3);
            dictName.Add("c",0);
            dictName.Add("d",0); 
            dictName.Add("e",0);
        }*/
        public void CreateDrinkButton(string DrinkName, string Num_Shots)
        {
            string drink_name = "";
            string num_shots = "";
            string NextPosY = "";
            string DrinksList = File.ReadAllText("C:\\Users\\khern\\Desktop\\C#\\HelloWPFApp\\HelloWPFApp\\Drinks_List\\Drinks_List.txt");
            string[] lines = DrinksList.Split(Environment.NewLine);

            Button newButton = new Button();
            ThicknessConverter thickcon = new ThicknessConverter();
            newButton.Height = 25;
            newButton.Width = 80;

            drink_name = DrinkName;
            num_shots = Num_Shots;

            int ButtonPosX = Int16.Parse(DrinksList[DrinksList.Count()-2].ToString());
            int ButtonPosY = Int16.Parse(lines[lines.Length-1].ToString());
            //string location = "{0}, {1}, 0, 0";

            if(ButtonPosY.ToString() == "100")
            {
                NextPosY = "175";
            }
            else
            {
                NextPosY = "100";
            }
            File.AppendAllText("C:\\Users\\khern\\Desktop\\C#\\HelloWPFApp\\HelloWPFApp\\Drinks_List\\Drinks_List.txt", drink_name + "\n" + num_shots + (ButtonPosX+200) + "\n"+ NextPosY +"\n");

            // string data = string.Format(location, (ButtonPosX+200), NextPosY);

            //Thickness buttThick = (Thickness)thickcon.ConvertFromString(location);
            // newButton.Margin = buttThick;

            newButton.Name = drink_name;
            newButton.Content = drink_name;

            newButton.Click += DrinkConfirm;


        }

        

        public void DrinkDescription(string[] DrinkArray_shots)
        {
            int z = 0;
            string txtBlk = "";
            
            foreach (string x in DrinkArray_shots)
            {
                
                 string msg = "Drink: {0}, Number of Shots: {1} \n";
                 string drnk = "";
                 switch (z)
                {
                    case 0:
                        drnk = "Vodka";
                        break;

                    case 1:
                        drnk = "Jack";
                        break;

                    case 2:
                        drnk = "Coke";
                        break;

                    case 3:
                        drnk = "Sprite";
                        break;

                    case 4:
                        drnk = "Tequila";
                        break;
                }

                 if(x != "0")
                {
                    string data = string.Format(msg, drnk, x);
                    txtBlk += data;
                }
                 
                 
                    //MessageBox.Show(data);
                    z += 1;
            }
                scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                Title.Visibility = Visibility.Collapsed;
                Label1.Visibility = Visibility.Collapsed;
                drink1.Visibility = Visibility.Collapsed;
                drink2.Visibility = Visibility.Collapsed;
                drink3.Visibility = Visibility.Collapsed;
                drink4.Visibility = Visibility.Collapsed;
                drink5.Visibility = Visibility.Collapsed;
                drink6.Visibility = Visibility.Collapsed;
                drink7.Visibility = Visibility.Collapsed;
                drink8.Visibility = Visibility.Collapsed;
                drink9.Visibility = Visibility.Collapsed;
                drink10.Visibility = Visibility.Collapsed;
               
                Drinks.Text = txtBlk;
                Drinks.Visibility = Visibility.Visible;

                ConfirmDrink.Visibility = Visibility.Visible;
                Cancel.Visibility = Visibility.Visible;
            

        }

        public void Organizer(string drink_name)
        { 
            string[] DrinkArray_shots = { "a", "a", "a", "a", "a" };

            string DrinksList = File.ReadAllText("C:\\Users\\khern\\Desktop\\C#\\HelloWPFApp\\HelloWPFApp\\Drinks_List\\Drinks_List.txt");
            string[] lines = DrinksList.Split(Environment.NewLine);

            for (int a = 0; a < lines.Length; a++)
            {
                if (lines[a] == drink_name)
                {
                    string drink_comb = lines[a + 1];
                    for (int b = 0; b < drink_comb.Length; b++)
                    {   
                        DrinkArray_shots[b] = drink_comb[b].ToString();
                        MessageBox.Show(DrinkArray_shots[b]);
                    }
                }
            }
            

            DrinkDescription(DrinkArray_shots);
        }
        
        private void DrinkConfirm(object sender, RoutedEventArgs e)
        {
            string drink_name = "";
            string button_name = (sender as Button).Name.ToString();
            switch (button_name)
            {
                case "drink1":
                    drink_name = "JackCoke";
                    break;

                case "drink2":
                    drink_name = "VodkaSprite";
                    break;

                case "drink3":
                    drink_name = "TequilaShot";
                    break;

                default:
                    drink_name = "JackCoke";
                    break;
            }


            //MessageBox.Show((sender as Button).Name.ToString());

            Organizer(drink_name);
           // Drinks.Text = 
           // Drinks.Visibility = Visibility.Visible;
            //ConfirmDrink.Visibility = Visibility.Visible;
           // Cancel.Visibility = Visibility.Visible;

        }

        private void TextBoxFocus(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("Here");
            switch ((sender as TextBox).Name.ToString())
            {
                case "TextBox1":
                    TextBox1.Focus();
                    break;

                case "TextBox2":
                    TextBox2.Focus();
                    break;

                case "TextBox3":
                    TextBox3.Focus();
                    break;

                case "TextBox4":
                    TextBox4.Focus();
                    break;

                case "TextBox5":
                    TextBox5.Focus();
                    break;

                case "NameDrink":
                    NameDrink.Focus();
                    break;
            }
        }
        private void Drink1_Click(object sender, RoutedEventArgs e)
        {
            Drinks.Visibility = Visibility.Collapsed;
            Drinks.Text = "Preparing Your Drink";
            Drinks.Visibility = Visibility.Visible;
            ConfirmDrink.Visibility = Visibility.Collapsed;
            Cancel.Visibility = Visibility.Collapsed;

            //MessageBox.Show("Here0");

           /* string drink_name = "";
            string button_name = (sender as Button).Name.ToString();
            switch (button_name)
            {
                case "drink1":
                    drink_name = "JackCoke";
                    break;

                case "drink2":
                    drink_name = "VodkaSprite";
                    break;

                case "drink3":
                    drink_name = "TequilaShot";
                    break;

                default:
                    drink_name = "JackCoke";
                    break;
            }

            
            //MessageBox.Show((sender as Button).Name.ToString());

            Organizer(drink_name);
           */
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
         //   stack.Visibility = Visibility.Collapsed;
          //  grid.Visibility = Visibility.Collapsed;
          //  int count = CreateButtons();
         //   MessageBox.Show(count.ToString());
            //function called if Select Drink is clicked
            //Title.Text = "New SCreen";
            
            Button1.Visibility = Visibility.Collapsed;//Main Screen button
            Button2.Visibility = Visibility.Collapsed;//Main Screen button

           // Button3.Visibility = Visibility.Visible;
           // Button4.Visibility = Visibility.Visible;
            BackButton.Visibility = Visibility.Visible;
            Label1.Visibility = Visibility.Visible;

          //  for(int x=1; x<count; x += 1)
          //  {
               
          //  }
            scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            //MessageBox.Show("HERE");
            //scroller.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            //for()
            MessageBox.Show("Here");
            drink1.Visibility = Visibility.Visible;
            drink2.Visibility = Visibility.Visible;
            drink3.Visibility = Visibility.Visible;
            drink4.Visibility = Visibility.Visible;
            drink5.Visibility = Visibility.Visible;
            drink6.Visibility = Visibility.Visible;
            drink7.Visibility = Visibility.Visible;
            drink8.Visibility = Visibility.Visible;
            drink9.Visibility = Visibility.Visible;
            drink10.Visibility = Visibility.Visible;
            
            Drinks.Visibility = Visibility.Collapsed;
            ConfirmDrink.Visibility = Visibility.Collapsed;
            Cancel.Visibility = Visibility.Collapsed;

           
            //  sp.Visibility = Visibility.Visible;
            // scroller.Visibility = Visibility.Visible;
            //MessageBox.Show("Button1 Clicked");
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //function called if Create a Drink is clicked
            Button1.Visibility = Visibility.Collapsed;
            Button2.Visibility = Visibility.Collapsed;

            BackButton.Visibility = Visibility.Visible;
            FinishButton.Visibility = Visibility.Visible;

            TextBox1.Visibility = Visibility.Visible;
            TextBox2.Visibility = Visibility.Visible;
            TextBox3.Visibility = Visibility.Visible;
            TextBox4.Visibility = Visibility.Visible;
            TextBox5.Visibility = Visibility.Visible;

            NameDrink.Visibility = Visibility.Visible;

            //this.ActiveControl = TextBox1;
            TextBox1.Focus();



            // MessageBox.Show("Button2 Clicked");
        }
        
     
        private void DoneButton(object sender, RoutedEventArgs e)
        {
            string Num_Shots = "";
            if (TextBox1.Text != "")
            {
                int num_shots = Int16.Parse(TextBox1.Text);
                Num_Shots += num_shots;
                //MessageBox.Show(num_shots.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Entry In Drink1");
            }
            if (TextBox2.Text != "")
            {
                int num_shots = Int16.Parse(TextBox2.Text);
                Num_Shots += num_shots;
                // MessageBox.Show(num_shots.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Entry In Drink2");
            }
            if (TextBox3.Text != "")
            {
                int num_shots = Int16.Parse(TextBox3.Text);
                Num_Shots += num_shots;
                // MessageBox.Show(num_shots.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Entry In Drink3");
            }
            if (TextBox4.Text != "")
            {
                int num_shots = Int16.Parse(TextBox4.Text);
                Num_Shots += num_shots;
                // MessageBox.Show(num_shots.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Entry In Drink4");
            }
            if (TextBox5.Text != "")
            {
                int num_shots = Int16.Parse(TextBox5.Text);
                Num_Shots += num_shots;
                //MessageBox.Show(num_shots.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Entry In Drink5");
            }
            if ((NameDrink.Text != "Name Your Drink!") && (NameDrink.Text != ""))
            {
                string DrinkName = NameDrink.Text.ToString();
                //MessageBox.Show(Num_Shots);

                CreateDrinkButton(DrinkName, Num_Shots);
            }
           
            
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackButton.Visibility = Visibility.Collapsed;

            scroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

            BackButton.Visibility = Visibility.Collapsed;
            Label1.Visibility = Visibility.Collapsed;

            /*drink1.Visibility = Visibility.Collapsed;
            drink2.Visibility = Visibility.Collapsed;
            drink3.Visibility = Visibility.Collapsed;
            drink4.Visibility = Visibility.Collapsed;
            drink5.Visibility = Visibility.Collapsed;
            drink6.Visibility = Visibility.Collapsed;
            drink7.Visibility = Visibility.Collapsed;
            drink8.Visibility = Visibility.Collapsed;
            drink9.Visibility = Visibility.Collapsed;
            drink10.Visibility = Visibility.Collapsed;
            */
            Button1.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;

            Drinks.Visibility = Visibility.Collapsed;

            FinishButton.Visibility = Visibility.Collapsed;
            TextBox1.Visibility = Visibility.Collapsed;
            TextBox2.Visibility = Visibility.Collapsed;
            TextBox3.Visibility = Visibility.Collapsed;
            TextBox4.Visibility = Visibility.Collapsed;
            TextBox5.Visibility = Visibility.Collapsed;

            TextBox1.Text = "0";
            TextBox2.Text = "0";
            TextBox3.Text = "0";
            TextBox4.Text = "0";
            TextBox5.Text = "0";
        }

    }
}
//int DictCount = JackCoke.Count;

/*string val = "";
  string val2 = "";

  foreach(string line in lines)
  {
    int start = line.IndexOf(drink_name);
    int end_delimiter = line.IndexOf('$');
    int begin_delimiter = line.IndexOf('!');

    if(begin_delimiter >= 0)
    {
        if(start >= 0)
         {
            MessageBox.Show("Drink Found");

         }
        else
         {
            MessageBox.Show("NONE");
         }
    }


  }
  MessageBox.Show(DrinksList);
  Thing(drink_name);


  foreach (KeyValuePair<string, int> drink in y)
  {
        val = drink.Key;
        val2 = drink.Value.ToString();

        DrinkArray_drink[i] = val;
        DrinkArray_shots[i] = val2;
        i += 1;
  }
*/