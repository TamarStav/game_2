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

namespace Wpf1_XO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int player = 0;
        char [,] mat= new char[3,3];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            Button b = e.OriginalSource as Button;
            int r = (int)b.GetValue(Grid.RowProperty);
            int c = (int)b.GetValue(Grid.ColumnProperty);
            if(b.Content.ToString()=="?")
            {
                if (player == 0)
                {
                    b.Content = "X";
                    player = 1;
                    mat[r, c] =  'X';
                    if (HasWin(r,c))
                        MessageBox.Show("winner");
                }
                    
                else
                {
                    b.Content = "O";
                    player = 0;
                    mat[r, c] = 'O';
                    if (HasWin(r, c))
                        MessageBox.Show("winner");
                }
                    
            }
        }

        private bool HasWin(double row,double col)
        {
            char c = mat[(int)row, (int)col];
            bool isWin1 = true, isWin2 = true, isWin3 = true, isWin4 = true,alachson1=false,alachson2=false;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (!(mat[(int)row, i] == c))
                    isWin1 = false;
            }

            for(int i = 0; i < mat.GetLength(0); i++)
            {
                if (!(mat[i,(int)col] == c))
                     isWin2 = false;
            }
            if ((row==0 && col==0) || (col==mat.GetLength(0)-1 && row== mat.GetLength(0)-1) || ((col== mat.GetLength(0)/2 )&& (row== mat.GetLength(0)/2)))
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    if (!(mat[i, i] == c))
                        isWin3 = false;
                }
                alachson1 = true;
            }
            if ((row == mat.GetLength(0)-1 && col == 0) || (row == 0 && col == mat.GetLength(0)-1 )|| (col == mat.GetLength(0) / 2 && row == mat.GetLength(0) / 2))
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    if (!(mat[i, mat.GetLength(0) - i-1] == c))
                        isWin4 = false;
                }
                alachson2 = true;
            }
            if(alachson1)
                return isWin1 || isWin2 || isWin3;
            else
                if (alachson2)
                    return isWin1 || isWin2 || isWin4;
            return isWin1 || isWin2;
        }
        
    }
}
