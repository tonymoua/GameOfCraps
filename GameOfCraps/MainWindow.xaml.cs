using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfCraps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int dice;
        int playerWins = 0;
        int houseWins = 0;
        int rolls = 0;
        int tempTotal = 0;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//roll dice
        {
            int dice1 = 0, dice2 = 0;
            //hide WINNER sign
            Winner.Visibility = Visibility.Hidden;

            dice1 = RandomNumber();
            //MessageBox.Show("" + dice1);

            Dice1.Text = "" + dice1;

            dice2 = RandomNumber();
            //MessageBox.Show("" + dice2);
            Dice2.Text = "" + dice2;

            int total = dice1 + dice2;
            Total.Text = "" + (total);
            checkWin(total);

            Bet.IsReadOnly = true;
        }

        private int RandomNumber()//random number
        {
            dice = 0;
            dice = random.Next(1,7);

            return dice;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)//Bet
        {
            try
            {
                if (int.Parse(Bet.Text) > int.Parse(Bank.Text))
                {
                    MessageBox.Show("Please enter a bet lower then what you have in the bank please");
                    //Bet.Text = "";
                    return;
                }
            }
            catch(Exception)
            {

            }
        }

        private void checkWin(int total)
        {
            if((total == 7 && rolls ==0)|| (total == 11 && rolls == 0))//roller wins
            {
                Winner.Visibility = Visibility.Visible;
                playerWins++;

                playerWin.Text = "" + playerWins;

                rolls = 0;
                RollDice.IsEnabled = false;
                newGame.IsEnabled = true;
                try
                {
                    Bank.Text = "" + (int.Parse(Bank.Text) + int.Parse(Bet.Text));
                }
                catch(Exception )
                {
                    return;
                }
            }
            if((total == 2 && rolls ==0 )|| (total == 3 && rolls == 0)|| (total ==12 && rolls == 0))// house wins
            {
                Winner.Visibility = Visibility.Visible;

                houseWins++;
                houseWin.Text = "" + houseWins;
                rolls = 0;
                RollDice.IsEnabled = false;
                newGame.IsEnabled = true;
                try
                {
                    Bank.Text = "" + (int.Parse(Bank.Text) - int.Parse(Bet.Text));
                }
                catch(Exception )
                {
                    return;
                }
                
            }
            if(total == 4 && rolls ==0)
            {
                point.Text = "" + total;
                tempTotal = total;
                rolls++;
                return;
            }
            if(total == 5 && rolls ==0)
            {
                point.Text = "" + total;
                tempTotal = total;
                rolls++;
                return;
            }
            if(total == 6 && rolls ==0)
            {
                point.Text = ""+ total;
                tempTotal = total;
                rolls++;
                return;
            }
            if(total == 8 && rolls ==0)
            {
                point.Text = "" + total;
                tempTotal = total;
                rolls++;
                return;
            }
            if(total == 9 && rolls == 0)
            {
                point.Text = ""+ total;
                tempTotal = total;
                rolls++;
                return;
            }
            if(total == 10 && rolls ==0)
            {
                point.Text = "" + total;
                tempTotal = total;
                rolls++;
                return;
            }
            if (rolls >0 && total == tempTotal)
            {
                Winner.Visibility = Visibility.Visible;
                playerWins++;

                playerWin.Text = "" + playerWins;
                RollDice.IsEnabled = false;
                newGame.IsEnabled = true;
                try
                {
                    Bank.Text = "" + (int.Parse(Bank.Text) + int.Parse(Bet.Text));
                }
                catch (Exception )
                {
                    return;
                }
                
            }
            if(rolls >= 1 && total == 7)
            {
                Winner.Visibility = Visibility.Visible;

                houseWins++;
                houseWin.Text = "" + houseWins;
                rolls = 0;
                RollDice.IsEnabled = false;
                newGame.IsEnabled = true;

                try
                {
                    Bank.Text = "" + (int.Parse(Bank.Text) - int.Parse(Bet.Text));
                }
                catch(Exception )
                {
                    return;
                }
                //MessageBox.Show();
            }
            
        }//end win

        private void newGame_Click(object sender, RoutedEventArgs e)//new game
        {
            RollDice.IsEnabled = true;
            Dice1.Text = "";
            Dice2.Text = "";
            Total.Text = "";
            point.Text = "";
            Winner.Visibility = Visibility.Hidden;
            rolls = 0;
            Bet.IsReadOnly = false;

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)//about
        {
            MessageBox.Show("Developer: Tony Moua\nVersion: 0.00001\n.NET Framework: 4.5.1 x64");
        }//end checkWin

        private void MenuItem_Click1(object sender, RoutedEventArgs e)//rules
        {
            MessageBox.Show("Go to menu and Click Start to begin.\nAt the start of a new game you can place your bet(your bets have to be less then what you have in the bank).\nOnce you hit zero in your bank you will then be asked to play again.\n1. Roll Dice\n2. On First Roll: if roll equals 7 or 11, roller wins.\nIf sum of roll equals 2, 3, or 12 the house wins\n if sum of roll equals 4,5,6,8,9,10 that sum becomes rollers point\n3. Continue: if next roll is rollers point number, roller gets a win. If sum of roll equals 7, house wins.");
        }//end checkWin

        private void clearGame(object sender, RoutedEventArgs e)//new game
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear data", "Clear", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                RollDice.IsEnabled = true;
                Dice1.Text = "";
                Dice2.Text = "";
                Total.Text = "";
                point.Text = "";
                Winner.Visibility = Visibility.Hidden;
                rolls = 0;
                playerWin.Text = "";
                houseWin.Text = "";
                Bank.Text = "" + 1000;
            }
        }//end checkWin

        private void start(object sender, RoutedEventArgs e)//start game
        {
            RollDice.IsEnabled = true;
            Bet.IsReadOnly = false;

        }//end checkWin
        private void exit(object sender, RoutedEventArgs e)//start game
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to Quit", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void BankZero(object sender, TextChangedEventArgs e)
        {
            if (int.Parse(Bank.Text) < 0)
            {
                Bank.Text = "" + 0;
            }
            if (int.Parse(Bank.Text) == 0)
            {
                MessageBoxResult result = MessageBox.Show("Did you want to lose more money?", "Play Again", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    RollDice.IsEnabled = true;
                    Dice1.Text = "";
                    Dice2.Text = "";
                    Total.Text = "";
                    point.Text = "";
                    Winner.Visibility = Visibility.Hidden;
                    rolls = 0;
                    playerWin.Text = "";
                    houseWin.Text = "";
                    Bank.Text = "" + 1000;
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            
        }//end exit
    }
}
