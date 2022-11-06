using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    public static class Day02
    {
        public static int Part1(List<Box> boxes)
        {
            int area = 0;
            boxes.ForEach(b => area += (b.GetTotalArea() + b.GetSmallesSideArea()));
            return area;
        }

        public static int Part2(List<Box> boxes)
        {
            int ribbonTotLength = 0;
            foreach (var box in boxes)
            {
                var bow = box.GetVolyme();
                var ribbon = Day02.GetRibbonLength(box);
                ribbonTotLength += (bow + ribbon);
            }

            return ribbonTotLength;
        }


        public static int GetArea(Box box) {
            //2*l*w + 2*w*h + 2*h*l
            int[] sides = {
                2 * box.Lenght * box.Width,
                2 * box.Width * box.Height,
                2 * box.Height * box.Lenght,
            };

            return sides.Sum() + (sides.Min()/2);
        }


        public class Box
        {
            public int Lenght { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int TopArea{ get; set; }
            public int BottomArea { get; set; }
            public int FrontArea { get; set; }
            public int BackArea { get; set; }
            public int LeftArea { get; set; }
            public int RightArea { get; set; }
            public Box(int lenght, int widht, int height)
            {
                Lenght = lenght;
                Width = widht;
                Height = height;
                TopArea = lenght * widht;
                BottomArea = lenght * widht;
                FrontArea = lenght * height;
                BackArea = lenght * height;
                LeftArea = height * widht;
                RightArea = height * widht;
            }

            public int GetTotalArea()
            {
                return TopArea + BottomArea + FrontArea + BackArea + LeftArea + RightArea;
            }

            public int GetSmallesSideArea()
            {
                return new int[] { TopArea, BottomArea, FrontArea, BackArea, LeftArea, RightArea }.Min();
            }

            public int GetVolyme()
            {
                return Lenght*Width*Height;
            }

        }

        public static Box GetBox(string input)
        {
            string[] data = input.Split('x');
            Box box = new Box(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
            return box;
        }

        public static int GetRibbonLength(Box box)
        {
            var sides = new int[] { box.Lenght, box.Height, box.Width }.OrderBy(s => s).ToArray();
            return (sides[0]*2) + (sides[1]*2);
        }



    }
}
