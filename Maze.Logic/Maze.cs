﻿namespace Maze.Logic
{
    public class MyMaze
    {
        private char[,] _maze;

        public MyMaze(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
        }

        public int N { get; }

        public int Obstacles { get; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        public void FillMaze()
        {
            FillBorders();
            FillObstacles();
            Path();
        }

        private void FillObstacles()
        {
            var random = new Random();
            int obstaclesCount = 0;
            do
            {
                var i = random.Next(1, N - 1);
                var j = random.Next(1, N - 1);
                if (!(i == 1 && j == 1 || i == N - 2 && j == N - 2))
                {
                    if (_maze[i , j] == ' ')
                    {
                        _maze[i, j] = '█';
                        obstaclesCount++;
                    }
                }
            } while (obstaclesCount < Obstacles);
        }

        private void FillBorders()
        {
            for (int i = 0; i < N; i++)
            {
                _maze[0, i] = '═';
            }
            for (int i = 0; i < N - 1; i++)
            {
                _maze[1, i] = ' ';
            }

            _maze[1, N - 1] = '║';
            for (int i = 2; i < N - 2; i++)
            {
                _maze[i, 0] = '║';
                for (int j = 1; j < N - 1; j++)
                {
                    _maze[i, j] = ' ';
                }
                _maze[i, N - 1] = '║';
            }
            _maze[N - 2, 0] = '║';
            for (int i = 1; i < N; i++)
            {
                _maze[N - 2, i] = ' ';
            }

            for (int i = 0; i < N; i++)
            {
                _maze[N - 1, i] = '═';
            }
        }

        private void Path()
        {
            for(int i = 1; i < N-1;i++) 
            {
                for(int j = 1;j < N;j++)
                {
                    if ((_maze[i,j] != '█') && (_maze[i, j] != '║'))
                    {
                        _maze[i, j] = '→';
                    }
                    else
                    {
                        if ((_maze[i+1,j-1] != '█') && (_maze[i + 1, j - 1] != '║'))
                        {
                            _maze[i + 1, j - 1] = '↓';
                            i ++;
                            j--;
                        }
                        else
                        {
                            if ((_maze[i, j - 2] != '█') && (_maze[i, j - 2] != '║'))
                            {
                                _maze[i, j - 2] = '←';
                                i ++;
                                j -= 2;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        public bool CouldGetOut()
        {
            var i = N;
            var j = N;
            if (_maze[i - 2, j - 1] == '→' || _maze[i - 2, j - 1] == '↓' || _maze[i - 2, j - 1] == '←')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}