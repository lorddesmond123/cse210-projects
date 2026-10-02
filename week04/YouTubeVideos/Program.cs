using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the first video
        Video video1 = new Video(
            "Introduction to C#",
            "Programming Basics",
            420
        );

        video1.AddComment(new Comment(
            "David",
            "This was a great introduction to C#."
        ));

        video1.AddComment(new Comment(
            "Sarah",
            "I learned a lot from this video."
        ));

        video1.AddComment(new Comment(
            "Michael",
            "The examples were easy to understand."
        ));

        video1.AddComment(new Comment(
            "Grace",
            "I am going to practice these examples."
        ));

        // Create the second video
        Video video2 = new Video(
            "Learning Object-Oriented Programming",
            "Code Academy",
            560
        );

        video2.AddComment(new Comment(
            "James",
            "I finally understand what a class is."
        ));

        video2.AddComment(new Comment(
            "Linda",
            "The explanation of objects was helpful."
        ));

        video2.AddComment(new Comment(
            "Daniel",
            "This made object-oriented programming easier."
        ));

        video2.AddComment(new Comment(
            "Desmond",
            "I enjoyed this lesson."
        ));

        // Create the third video
        Video video3 = new Video(
            "How to Build Better Programs",
            "Tech Learning",
            735
        );

        video3.AddComment(new Comment(
            "John",
            "The tips in this video were useful."
        ));

        video3.AddComment(new Comment(
            "Emily",
            "I liked the practical examples."
        ));

        video3.AddComment(new Comment(
            "Robert",
            "This helped me understand program structure."
        ));

        video3.AddComment(new Comment(
            "Jessica",
            "Very informative video."
        ));

        // Create the fourth video
        Video video4 = new Video(
            "C# Classes and Objects",
            "Developer Guide",
            610
        );

        video4.AddComment(new Comment(
            "Peter",
            "The class examples were very clear."
        ));

        video4.AddComment(new Comment(
            "Anna",
            "I understand objects much better now."
        ));

        video4.AddComment(new Comment(
            "Chris",
            "Great explanation of the topic."
        ));

        video4.AddComment(new Comment(
            "Maria",
            "I will use this information in my project."
        ));

        // Put all videos into a list
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3,
            video4
        };

        // Display each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetDisplayText()}");
            }

            Console.WriteLine();
        }
    }
}