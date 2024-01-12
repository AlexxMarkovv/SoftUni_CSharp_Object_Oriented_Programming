﻿using CreateAttribute;

namespace AuthorProblem
{
    [Author("Viktor")]
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}