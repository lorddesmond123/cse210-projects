using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * W06 Eternal Quest Program
         *
         * Creativity / Exceeding Requirements:
         *
         * I added a Quest Level system as an additional gamification
         * feature. The player starts at Level 1 and gains another
         * level for every 500 points earned.
         *
         * The current level is displayed with the player's score.
         * The program also displays a special level-up message whenever
         * the player reaches a new level.
         *
         * This feature is intended to make the goal-tracking experience
         * more motivating by giving the user another achievement to
         * work toward while completing their goals.
         */

        GoalManager manager = new GoalManager();

        manager.Start();
    }
}