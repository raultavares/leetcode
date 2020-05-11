using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _733.Flood_Fill
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize the image
            int[][] img = {
            new int[] {1,1,1},
            new int[] {1,1,0},
            new int[] {1,0,1}  };

            // flood it
            FloodFill(img, 1, 1, 2);
        }



        static public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            // get the original lookup color
            int curColor = image[sr][sc];
            
            // call the dfs in the initial point
            dfs(image, sr, sc, curColor, newColor);

            // this will have the matrix array already flooded
            return image;

        }

        static void dfs(int[][] img, int row, int col, int color, int newColor)
        {

            // first, check if boundaries are inside array limits horizontally and vertically
            if (row < 0 || col < 0 || row > img.Length - 1 || col > img[0].Length - 1)
                return;

            // check if current pixel is different from lookup color
            if (img[row][col] != color)
                return;

            // also check if it has been already visited, which means, already flooded with the newColor
            if (img[row][col] == newColor)
                return;

            // if all validations pass, flood the pixel with the new color
            img[row][col] = newColor;

            // check the CALL STACK from you compiler to see the values of row and col being passed to this function

            // call this same function going bottom
            dfs(img, row + 1, col, color, newColor);
            // call this same function going top
            dfs(img, row - 1, col, color, newColor);
            // call this same function going right           
            dfs(img, row, col + 1, color, newColor);
            // call this same function going  left
            dfs(img, row, col - 1, color, newColor);
        }
    }
}
